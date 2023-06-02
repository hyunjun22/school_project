using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private new Camera camera;
    private Rigidbody2D rigid;
    private Vector2 velocity;

    private float inputAxis;
    public float moveSpeed;     // ������ �ӵ�
    public bool grounded;       // ���� �پ��ִ��� �Ⱥپ��ִ���
    public bool jumping;        // �����ߴ��� ���ߴ���

    //#.����ĳ��Ʈ ��� ����
    private LayerMask layerMask;
    private float radius = 0.25f;    // ������ ����(��)
    private float distance = 0.85f;  // �Ÿ�

    //#.����&�߷� ��� ����
    private float maxJumpHeight = 5f; // �ִ� ���� �Ÿ�
    private float maxJumpTime = 1f;   // �ִ� ���� �ð�
    private float jumpForce => (2f * maxJumpHeight) / (maxJumpTime / 2f); // ���� �Ŀ�
    private float gravity => (-2f * maxJumpHeight) / Mathf.Pow((maxJumpTime / 2f), 2);

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        camera = Camera.main;
    }

    void Update()
    {   
        PlayerMovement(); // �÷��̾� ������
        GroundedCheck();  // �ٴڿ� �پ��� �� üũ
        Jump();           // ����
        ApplyGravity();   // �߷�
    }

    void FixedUpdate(){
        LimitMovement();
    }

    //#.�÷��̾� ������
    void PlayerMovement()
    {
        // �¿� ������
        inputAxis = Input.GetAxisRaw("Horizontal");
        velocity.x = inputAxis * moveSpeed;            
    
        rigid.velocity = velocity;
    }

    //#.�ٴڿ� �پ��ִ� �� üũ
    void GroundedCheck()
    {
        // ����ĳ��Ʈ�� �ٴڰ� �浹 ����
        layerMask = LayerMask.GetMask("ground");
        RaycastHit2D hit = Physics2D.CircleCast(rigid.position, radius, Vector2.down, distance, layerMask);

        // ����ĳ��Ʈ ���� �ð������� ǥ���ϱ�
        Vector3 startLine = new Vector3(rigid.position.x, rigid.position.y - distance + radius, 0);
        Vector3 endLine   = new Vector3(rigid.position.x, rigid.position.y - distance - radius, 0);
        Debug.DrawLine(startLine, endLine, Color.red, 0.1f);

        // �ٴ� �浹
        if(hit.collider){
            grounded = true;
        }            
        else
        {
            grounded = false; 
        }
    }

    //#.����
    void Jump(){

        // �ٴڿ� �پ����� ������ ����X
        if(!grounded)
            return;

        velocity.y = Mathf.Max(velocity.y, 0f); // �� �� ū ���� ��ȯ�Ѵ�.
        jumping = velocity.y > 0f;

        if(Input.GetButtonDown("Jump"))
        {
            velocity.y = jumpForce;
            jumping = true; // ������
        }
    }

    //#.�߷� ����
    void ApplyGravity(){
        bool falling = velocity.y < 0f || !Input.GetButton("Jump");
        float multiplier = falling ? 2f : 1f;

        velocity.y += gravity * multiplier * Time.deltaTime;
        velocity.y = Mathf.Max(velocity.y, gravity / 2f);
    }

    //#.������ �����ϱ�(ī�޶�)
    void LimitMovement(){
        Vector2 position = rigid.position;
        position += velocity * Time.fixedDeltaTime;

        Vector2 leftEdge = camera.ScreenToWorldPoint(Vector2.zero);
        Vector2 rightEdge= camera.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        position.x = Mathf.Clamp(position.x, leftEdge.x + 0.5f, rightEdge.x - 0.5f);

        rigid.MovePosition(position);
    }
}
