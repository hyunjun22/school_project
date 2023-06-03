using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingTrap : MonoBehaviour
{
    PlayerController playercontroller;
    public Rigidbody2D FallingObject; // ���
    public float fallingSpeed;

    void Awake()
    {
        playercontroller = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    //#.Ʈ���ſ� �浹
    void OnTriggerEnter2D(Collider2D other){
        
        // �÷��̾�� �ε��� ���� ����
        if(other.gameObject.tag == "Player")
        {
            playercontroller.fall(fallingSpeed * -1f);
            FallingObject.velocity = new Vector2(0, fallingSpeed * -1f);
        }

    }
}