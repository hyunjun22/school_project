using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaxiTrigger : MonoBehaviour
{
    PlayerController playercontroller;
    public Rigidbody2D taxi_rigid;

    void Awake()
    {
        playercontroller = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    //#.Ʈ���ſ� �浹
    void OnTriggerEnter2D(Collider2D other){
        
        // �÷��̾�� �ε��� ���� ����
        if(other.gameObject.tag == "Player")
        {
            taxi_rigid.gameObject.SetActive(true);
            taxi_rigid.velocity = new Vector2(-20f, 0);
        }

    }
}
