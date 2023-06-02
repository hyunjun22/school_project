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
            rigid.velocity = Vector2.right * walkSpeed;
        }
        else if(endline < transform.position.x)
        {
            rigid.velocity = Vector2.left * walkSpeed;
        }

        // �¿� ����
        if(rigid.velocity.x < 0f){
            transform.eulerAngles = Vector3.zero;
        }
        else if(rigid.velocity.x > 0f) {
            transform.eulerAngles = new Vector3(0, 180f, 0); // 180�� ȸ��
        }
                
    }
}
