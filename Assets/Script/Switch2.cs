using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch2 : MonoBehaviour
{
    public Rigidbody2D Trap_rigid; // 함정의 리지드바디
    public Vector2 direction; // 방향
    public float Force;       // 힘의 크기

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            // 위로 안부딪히면 X
            if(!transform.DotTest(other.transform, Vector2.down))
                return;

            Trap_rigid.gameObject.SetActive(true);
            Trap_rigid.velocity = direction * Force;
        }
    }
}
