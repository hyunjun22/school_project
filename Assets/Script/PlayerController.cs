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
    public float moveSpeed;     // 움직임 속도

    //#.상태
    public bool grounded;       // 땅에 붙어있는지 안붙어있는지
    public bool jumping;        // 점프했는지 안했는지
    public bool Untouchable;    // 건들지 못하는 상태
    public bool Rolling;        // 회전 상태
    public bool moving;         // 움직이고 있는지
    public bool defaultHit;     // 무엇에 부딪혔는지

    //#.레이캐스트 사용 변수
    private LayerMask layerMask;
    private RaycastHit2D hitCircle;
    private float radius = 0.1f;    // 반지름 길이(원)
    private float distance = 0.75f;  // 거리

    //#.점프&중력 사용 변수
    private float maxJumpHeight = 6f; // 최대 점프 거리
    private float maxJumpTime = 1f;   // 최대 점프 시간
    private float jumpForce => (2f * maxJumpHeight) / (maxJumpTime / 2f); // 점프 파워
    private float gravity => (-2f * maxJumpHeight) / Mathf.Pow((maxJumpTime / 2f), 2);
    
    //#.회전
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
        rigid.velocity = velocity; // 속도 반환하기


        RollingMethod();  // 회전

        // 언터처블 상태라면 밑에 함수들 전부 무시
        if(Untouchable)
            return;

        PlayerMovement(); // 플레이어 움직임
        GroundedCheck();  // 바닥에 붙었는 지 체크
        Jump();           // 점프
        ApplyGravity();   // 중력
        PlayerAnimation();
    }

    void FixedUpdate(){
        // 언터처블 상태라면 밑에 함수들 전부 무시
        if(Untouchable)
            return;

        LimitMovement();
    }

    //#.플레이어 움직임
    void PlayerMovement()
    {
        // 좌우 움직임
        inputAxis = Input.GetAxisRaw("Horizontal");
        velocity.x = inputAxis * moveSpeed;

        // 좌우 움직임에 따라서 회전
        if(velocity.x > 0f){
            transform.eulerAngles = Vector3.zero;
        }
        else if(velocity.x < 0f) {
            transform.eulerAngles = new Vector3(0, 180f, 0); // 180도 회전
        }

        
    }

    //#.바닥에 붙어있는 지 체크
    void GroundedCheck()
    {
        // 레이캐스트로 바닥과 충돌 감지
        layerMask = LayerMask.GetMask("ground");
        hitCircle = Physics2D.CircleCast(rigid.position, radius, Vector2.down, distance, layerMask);

        // 레이캐스트 범위 시각적으로 표시하기
        Vector3 startLine = new Vector3(rigid.position.x, rigid.position.y - distance + radius, 0);
        Vector3 endLine   = new Vector3(rigid.position.x, rigid.position.y - distance - radius, 0);
        Debug.DrawLine(startLine, endLine, Color.red, 0.1f);

        // hitCircle은 OnCollider2D에서 사용
        if(hitCircle.collider && defaultHit){
            grounded = true;
        } else {
            grounded = false;
        }
    }

    //#.점프
    void Jump(){

        // 바닥에 붙어있지 않으면 실행X or 건들지 못하는 상태면 실행X
        if(!grounded || Untouchable)
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

    //#.떨어지기
    public void fall(float fallingSpeed){
        Untouchable = true;
        collider.enabled = false; // 캡슐 콜라이더 off
        
        // 속도 설정
        velocity.x = 0f;
        velocity.y = fallingSpeed;
    }

    //#.회전시키기
    void RollingMethod(){
        
        // 회전 상태일 때만 실행
        if(!Rolling)
            return;

        rotateValue += 250f * Time.deltaTime;

        transform.localEulerAngles = new Vector3(0, 0, rotateValue);
    }

    //#.치인다 (택시에)
    public void hit(float hitForce, Transform other){
        Untouchable = true;
        Rolling = true;
        collider.enabled = false;

        // 날아가기
        velocity = transform.direction(other) * hitForce;
    }

    //#.충돌
    void OnCollisionEnter2D(Collision2D other){
        // 택시와 충돌 시
        if(other.gameObject.tag == "Taxi"){
            Debug.Log("taxi hit!");
            hit(7f, other.transform);
        }
        
        // 버스와 충돌 시
        if(other.gameObject.tag == "Bus"){
            Debug.Log("Bus hit!");
            hit(3f, other.transform);
        }

        // 공중에 있는 블럭과 충돌 시
        if(transform.DotTest(other.transform, Vector2.up))
        {
            // 택시와 버스는 제외
            if(other.gameObject.tag == "Taxi" || other.gameObject.tag == "Bus")
                return;

            Debug.Log("air Block hit!");
            velocity.y = 0;
        }

        // 충돌체크
        defaultHit = true; // 무언가에 부딪혔다.
       
    }

    //#.충돌에서 벗어남
    void OnCollisionExit2D(Collision2D other){
        defaultHit = false;
    }

    void PlayerAnimation()
    {
        // moving 세팅 (움직이고 있는 지 아닌 지)
        if(velocity.x < 0.01f && velocity.x > -0.01f)
            moving = false;
        else
            moving = true;

        animator.SetBool("moving", moving);
    }


}
