using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rigid;
    private Vector2 velocity;
    private float inputAxis;
    
    public bool jumping { get; private set; }
    public float moveSpeed;     // ������ �ӵ�
    public bool grounded;       // ���� �پ����� �Ⱥپ�����

    //#.����ĳ��Ʈ ��� ����
    private LayerMask layerMask;
    private float radius = 0.25f;    // ������ ����(��)
    private float distance = 0.85f; // �Ÿ�

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        
    }

    void Update()
    {   
        PlayerMovement();
        GroundedCheck();
    }

    //#.�÷��̾� ������
    void PlayerMovement()
    {
        // �¿� ������
        inputAxis = Input.GetAxisRaw("Horizontal");
        velocity.x = inputAxis * moveSpeed;
    
        rigid.velocity = velocity;

        // �̲����� ���� (���� �پ����� ����)
        if(inputAxis == 0 && grounded){
            velocity.x = 0;
        }
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
            Debug.Log("Hit");
        }            
        else
        {
            grounded = false; 
            Debug.Log("Not Hit");
        }
    }

    
}
