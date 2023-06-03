using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaxiTrigger : MonoBehaviour
{
    PlayerController playercontroller;
    public Rigidbody2D Trap_rigid; // 함정의 리지드바디
    public Vector2 direction; // 방향
    public float Force;       // 힘의 크기

    void Awake()
    {
        playercontroller = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    //#.트리거와 충돌
    void OnTriggerEnter2D(Collider2D other){
        
        // 플레이어와 부딪힐 때만 실행
        if(other.gameObject.tag == "Player")
        {
            Trap_rigid.gameObject.SetActive(true);
            Trap_rigid.velocity = direction * Force;
        }

    }
}
