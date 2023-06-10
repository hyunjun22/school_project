using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bus : MonoBehaviour
{
    Rigidbody2D rigid;
    float startline, endline;
    public float walkSpeed; // �ȴ� �ӵ�
    public float distance;  // �Ÿ�

    float currentX;
    Vector2 direction; // ����

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

        // �¿�� �����̱�
        if(startline > transform.position.x)
        {
            direction = Vector2.right;
            rigid.velocity = direction * walkSpeed;
        }
        else if(endline < transform.position.x)
        {
            direction = Vector2.left;
            rigid.velocity = direction * walkSpeed;
        }

        // �¿� ����
        if(rigid.velocity.x < 0f){
            transform.eulerAngles = Vector3.zero;
        }
        else if(rigid.velocity.x > 0f) {
            transform.eulerAngles = new Vector3(0, 180f, 0); // 180�� ȸ��
        }
                
    }

    // �¿� ��ȯ
    void ChangeMovement(){
        direction *= -1f;
        rigid.velocity = direction * walkSpeed;
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Bus" || other.gameObject.tag == "FakeBus"){
            ChangeMovement();
        }
    }
}
