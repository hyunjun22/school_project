using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingTrap : MonoBehaviour
{
    PlayerController playercontroller;
    public Rigidbody2D Stairs; // ���

    void Start()
    {
        playercontroller = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    //#.Ʈ���ſ� �浹
    void OnTriggerEnter2D(Collider2D other){
        
        // �÷��̾�� �ε��� ���� ����
        if(other.gameObject.tag == "Player")
        {
            float fallingSpeed = -20f;
            playercontroller.fall(fallingSpeed);
            Stairs.velocity = new Vector2(0, fallingSpeed);
        }

    }
}