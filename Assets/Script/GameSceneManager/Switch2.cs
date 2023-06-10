using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch2 : MonoBehaviour
{
    public Rigidbody2D Trap_rigid; // ������ ������ٵ�
    public Vector2 direction; // ����
    public float Force;       // ���� ũ��

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            // ���� �Ⱥε����� X
            if(!transform.DotTest(other.transform, Vector2.down))
                return;

            Trap_rigid.gameObject.SetActive(true);
            Trap_rigid.velocity = direction * Force;
        }
    }
}
