using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bus : MonoBehaviour
{
    Rigidbody2D rigid;
    float startline, endline;
    public float walkSpeed; // 걷는 속도
    public float distance;  // 거리
    float currentX;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    void Start(){
        rigid.velocity = Vector2.left * walkSpeed;
        currentX = transform.position.x;
    }

    void Update()
    {
        startline = currentX - distance;
        endline   = currentX + distance;

        // 좌우로 움직이기
        if(startline > transform.position.x)
        {
            rigid.velocity = Vector2.right * walkSpeed;
        }
        else if(endline < transform.position.x)
        {
            rigid.velocity = Vector2.left * walkSpeed;
        }

        // 좌우 반전
        if(rigid.velocity.x < 0f){
            transform.eulerAngles = Vector3.zero;
        }
        else if(rigid.velocity.x > 0f) {
            transform.eulerAngles = new Vector3(0, 180f, 0); // 180도 회전
        }
                
    }
}
