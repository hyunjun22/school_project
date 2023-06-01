using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rigid;
    private Vector2 velocity;
    private float inputAxis;
    
    public bool jumping { get; private set; }
    public float moveSpeed;     // 움직임 속도
    public bool grounded;       // 땅에 붙었는지 안붙었는지

    //#.레이캐스트 사용 변수
    private LayerMask layerMask;
    private float radius = 0.25f;    // 반지름 길이(원)
    private float distance = 0.85f; // 거리

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        
    }

    void Update()
    {   
        PlayerMovement();
        GroundedCheck();
    }

    //#.플레이어 움직임
    void PlayerMovement()
    {
        // 좌우 움직임
        inputAxis = Input.GetAxisRaw("Horizontal");
        velocity.x = inputAxis * moveSpeed;
    
        rigid.velocity = velocity;

        // 미끄러짐 방지 (땅에 붙어있을 때만)
        if(inputAxis == 0 && grounded){
            velocity.x = 0;
        }
    }

    //#.바닥에 붙어있는 지 체크
    void GroundedCheck()
    {
        // 레이캐스트로 바닥과 충돌 감지
        layerMask = LayerMask.GetMask("ground");
        RaycastHit2D hit = Physics2D.CircleCast(rigid.position, radius, Vector2.down, distance, layerMask);

        // 레이캐스트 범위 시각적으로 표시하기
        Vector3 startLine = new Vector3(rigid.position.x, rigid.position.y - distance + radius, 0);
        Vector3 endLine   = new Vector3(rigid.position.x, rigid.position.y - distance - radius, 0);
        Debug.DrawLine(startLine, endLine, Color.red, 0.1f);

        // 바닥 충돌
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
