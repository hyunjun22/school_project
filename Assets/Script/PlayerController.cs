using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private new Camera camera;
    private Rigidbody2D rigid;
    private Vector2 velocity;

    private float inputAxis;
    public float moveSpeed;     // 움직임 속도
    public bool grounded;       // 땅에 붙어있는지 안붙어있는지
    public bool jumping;        // 점프했는지 안했는지

    //#.레이캐스트 사용 변수
    private LayerMask layerMask;
    private float radius = 0.25f;    // 반지름 길이(원)
    private float distance = 0.85f;  // 거리

    //#.점프&중력 사용 변수
    private float maxJumpHeight = 5f; // 최대 점프 거리
    private float maxJumpTime = 1f;   // 최대 점프 시간
    private float jumpForce => (2f * maxJumpHeight) / (maxJumpTime / 2f); // 점프 파워
    private float gravity => (-2f * maxJumpHeight) / Mathf.Pow((maxJumpTime / 2f), 2);

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        camera = Camera.main;
    }

    void Update()
    {   
        PlayerMovement(); // 플레이어 움직임
        GroundedCheck();  // 바닥에 붙었는 지 체크
        Jump();           // 점프
        ApplyGravity();   // 중력
    }

    void FixedUpdate(){
        LimitMovement();
    }

    //#.플레이어 움직임
    void PlayerMovement()
    {
        // 좌우 움직임
        inputAxis = Input.GetAxisRaw("Horizontal");
        velocity.x = inputAxis * moveSpeed;            
    
        rigid.velocity = velocity;
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
        }            
        else
        {
            grounded = false; 
        }
    }

    //#.점프
    void Jump(){

        // 바닥에 붙어있지 않으면 실행X
        if(!grounded)
            return;

        velocity.y = Mathf.Max(velocity.y, 0f); // 둘 중 큰 값을 반환한다.
        jumping = velocity.y > 0f;

        if(Input.GetButtonDown("Jump"))
        {
            velocity.y = jumpForce;
            jumping = true; // 점프함
        }
    }

    //#.중력 적용
    void ApplyGravity(){
        bool falling = velocity.y < 0f || !Input.GetButton("Jump");
        float multiplier = falling ? 2f : 1f;

        velocity.y += gravity * multiplier * Time.deltaTime;
        velocity.y = Mathf.Max(velocity.y, gravity / 2f);
    }

    //#.움직임 제한하기(카메라)
    void LimitMovement(){
        Vector2 position = rigid.position;
        position += velocity * Time.fixedDeltaTime;

        Vector2 leftEdge = camera.ScreenToWorldPoint(Vector2.zero);
        Vector2 rightEdge= camera.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        position.x = Mathf.Clamp(position.x, leftEdge.x + 0.5f, rightEdge.x - 0.5f);

        rigid.MovePosition(position);
    }
}
