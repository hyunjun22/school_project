using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Taxi : MonoBehaviour
{
    Rigidbody2D rigid;

    void Awake(){
        rigid = GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.tag != "Ground")
        {
            Debug.Log("Stop");
            rigid.velocity = Vector2.zero;
            this.gameObject.tag = "Untagged"; // 태그를 변경한다.
        }
    }
}
