using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThornTrap : MonoBehaviour
{
    Animator animator;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Player")
        {
            animator.SetTrigger("Thorn");
        }
    }
}
