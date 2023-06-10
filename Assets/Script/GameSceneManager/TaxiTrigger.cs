using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaxiTrigger : MonoBehaviour
{
    PlayerController playercontroller;
    public Rigidbody2D Trap_rigid; // ������ ������ٵ�
    public Vector2 direction; // ����
    public float Force;       // ���� ũ��

    void Awake()
    {
        playercontroller = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    //#.Ʈ���ſ� �浹
    void OnTriggerEnter2D(Collider2D other){
        
        // �÷��̾�� �ε��� ���� ����
        if(other.gameObject.tag == "Player")
        {
            Trap_rigid.gameObject.SetActive(true);
            Trap_rigid.velocity = direction * Force;
        }

    }
}
