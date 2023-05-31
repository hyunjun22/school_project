using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rigid;
    private Vector2 velocity;
    private float inputAxis;
    
    public CircleCollider2D ground_circle;
    public bool jumping { get; private set; }
    public float moveSpeed;             // ??? ??
    public bool grounded; // ??? ???? ? ????? ?


    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        
    }

    void Update()
    {   
        PlayerMovement();
    }

    void PlayerMovement()
    {
        rigid.velocity = velocity;


        // ??? ???
        inputAxis = Input.GetAxisRaw("Horizontal");
        velocity.x = inputAxis * moveSpeed;
    
        // ???? ??? (?? ???? ?)
        if(inputAxis == 0){
            velocity.x = 0;
        }
    }
}
