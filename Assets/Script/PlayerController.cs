using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private new Camera camera;
    private Rigidbody2D rigid;
    private new CapsuleCollider2D collider;
    private Vector2 velocity;
    private Animator animator;

    private float inputAxis;
    public float moveSpeed;     // ������ �ӵ�

    //#.����
    public bool grounded;       // ���� �پ��ִ��� �Ⱥپ��ִ���
    public bool jumping;        // �����ߴ��� ���ߴ���
    public bool Untouchable;    // �ǵ��� ���ϴ� ����
    public bool Rolling;        // ȸ�� ����
    public bool moving;         // �����̰� �ִ���
    public bool defaultHit;     // ������ �ε�������

    //#.����ĳ��Ʈ ��� ����
    private LayerMask layerMask;
    private RaycastHit2D hitCircle;
    private float radius = 0.1f;    // ������ ����(��)
    private float distance = 0.75f;  // �Ÿ�

    //#.����&�߷� ��� ����
    private float maxJumpHeight = 6f; // �ִ� ���� �Ÿ�
    private float maxJumpTime = 1f;   // �ִ� ���� �ð�
    private float jumpForce => (2f * maxJumpHeight) / (maxJumpTime / 2f); // ���� �Ŀ�
    private float gravity => (-2f * maxJumpHeight) / Mathf.Pow((maxJumpTime / 2f), 2);
    
    //#.ȸ��
    private float rotateValue = 0f;


    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        collider = GetComponent<CapsuleCollider2D>();
        animator = GetComponent<Animator>();
        camera = Camera.main;
    }

    void Start()
    {
        grounded = true;
        defaultHit = true;
    }

    void Update()
    {
        rigid.velocity = velocity; // �ӵ� ��ȯ�ϱ�


        RollingMethod();  // ȸ��

        // ����ó�� ���¶�� �ؿ� �Լ��� ���� ����
        if(Untouchable)
            return;

        PlayerMovement(); // �÷��̾� ������
        GroundedCheck();  // �ٴڿ� �پ��� �� üũ
        Jump();           // ����
        ApplyGravity();   // �߷�
        PlayerAnimation();
    }

    void FixedUpdate(){
        // ����ó�� ���¶�� �ؿ� �Լ��� ���� ����
        if(Untouchable)
            return;

        LimitMovement();
    }

    //#.�÷��̾� ������
    void PlayerMovement()
    {
        // �¿� ������
        inputAxis = Input.GetAxisRaw("Horizontal");
        velocity.x = inputAxis * moveSpeed;

        // �¿� �����ӿ� ���� ȸ��
        if(velocity.x > 0f){
            transform.eulerAngles = Vector3.zero;
        }
        else if(velocity.x < 0f) {
            transform.eulerAngles = new Vector3(0, 180f, 0); // 180�� ȸ��
        }

        
    }

    //#.�ٴڿ� �پ��ִ� �� üũ
    void GroundedCheck()
    {
        // ����ĳ��Ʈ�� �ٴڰ� �浹 ����
        layerMask = LayerMask.GetMask("ground");
        hitCircle = Physics2D.CircleCast(rigid.position, radius, Vector2.down, distance, layerMask);

        // ����ĳ��Ʈ ���� �ð������� ǥ���ϱ�
        Vector3 startLine = new Vector3(rigid.position.x, rigid.position.y - distance + radius, 0);
        Vector3 endLine   = new Vector3(rigid.position.x, rigid.position.y - distance - radius, 0);
        Debug.DrawLine(startLine, endLine, Color.red, 0.1f);

        // hitCircle�� OnCollider2D���� ���
        if(hitCircle.collider && defaultHit){
            grounded = true;
        } else {
            grounded = false;
        }
    }

    //#.����
    void Jump(){

        // �ٴڿ� �پ����� ������ ����X or �ǵ��� ���ϴ� ���¸� ����X
        if(!grounded || Untouchable)
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

    //#.��������
    public void fall(float fallingSpeed){
        Untouchable = true;
        collider.enabled = false; // ĸ�� �ݶ��̴� off
        
        // �ӵ� ����
        velocity.x = 0f;
        velocity.y = fallingSpeed;
    }

    //#.ȸ����Ű��
    void RollingMethod(){
        
        // ȸ�� ������ ���� ����
        if(!Rolling)
            return;

        rotateValue += 250f * Time.deltaTime;

        transform.localEulerAngles = new Vector3(0, 0, rotateValue);
    }

    //#.ġ�δ� (�ýÿ�)
    public void hit(float hitForce, Transform other){
        Untouchable = true;
        Rolling = true;
        collider.enabled = false;

        // ���ư���
        velocity = transform.direction(other) * hitForce;
    }

    //#.�浹
    void OnCollisionEnter2D(Collision2D other){
        // �ýÿ� �浹 ��
        if(other.gameObject.tag == "Taxi"){
            Debug.Log("taxi hit!");
            hit(7f, other.transform);
        }
        
        // ������ �浹 ��
        if(other.gameObject.tag == "Bus"){
            Debug.Log("Bus hit!");
            hit(3f, other.transform);
        }

        // ���߿� �ִ� ���� �浹 ��
        if(transform.DotTest(other.transform, Vector2.up))
        {
            // �ýÿ� ������ ����
            if(other.gameObject.tag == "Taxi" || other.gameObject.tag == "Bus")
                return;

            Debug.Log("air Block hit!");
            velocity.y = 0;
        }

        // �浹üũ
        defaultHit = true; // ���𰡿� �ε�����.
       
    }

    //#.�浹���� ���
    void OnCollisionExit2D(Collision2D other){
        defaultHit = false;
    }

    void PlayerAnimation()
    {
        // moving ���� (�����̰� �ִ� �� �ƴ� ��)
        if(velocity.x < 0.01f && velocity.x > -0.01f)
            moving = false;
        else
            moving = true;

        animator.SetBool("moving", moving);
    }


}
