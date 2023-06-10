using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingTrap : MonoBehaviour
{
    PlayerController playercontroller;
    public Rigidbody2D FallingObject; // 계단
    public float fallingSpeed;

    void Awake()
    {
        playercontroller = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    //#.트리거와 충돌
    void OnTriggerEnter2D(Collider2D other){
        
        // 플레이어와 부딪힐 때만 실행
        if(other.gameObject.tag == "Player")
        {
            playercontroller.fall(fallingSpeed * -1f);
            FallingObject.velocity = new Vector2(0, fallingSpeed * -1f);
        }

    }
}