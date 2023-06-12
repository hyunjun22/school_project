using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Taxi : MonoBehaviour
{
    Rigidbody2D rigid;
    AudioSource audiosound;

    void Awake(){
        rigid = GetComponent<Rigidbody2D>();
        audiosound = GetComponent<AudioSource>();
    }

    void OnEnable() {
        audiosound.volume = GameManager.Instance.effectSoundValue;
    }

    void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.tag != "Ground")
        {
            Debug.Log("Stop");
            rigid.velocity = Vector2.zero;
        }
    }
}
