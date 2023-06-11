using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficLight : MonoBehaviour
{
    PlayerController playercontroller;
    private new BoxCollider2D collider;
    private new SpriteRenderer renderer;
    public Rigidbody2D Trap_rigid; // 함정의 리지드바디
    public Vector2 direction; // 방향
    public float Force;       // 힘의 크기
    public Sprite redTraffic;
    public Sprite greenTraffic;
    public bool isRed;

    void Awake()
    {
        playercontroller = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        collider = gameObject.GetComponent<BoxCollider2D>();
        renderer = gameObject.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        TrafficColor();
    }

    void TrafficColor()
    {
        if(isRed){
            renderer.sprite = redTraffic;
            collider.enabled = false;
        } else {
            renderer.sprite = greenTraffic;
            collider.enabled = true;
        }
    }

    // 스프라이트 전환
    public void ChangeLight()
    {
        isRed = isRed ? false : true; // 바꾸기
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
