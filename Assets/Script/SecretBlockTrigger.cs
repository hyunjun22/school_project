using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecretBlockTrigger : MonoBehaviour
{
    public GameObject secretObj;
    private new SpriteRenderer renderer;
    private new BoxCollider2D collider;

    void Awake()
    {
        renderer = secretObj.transform.GetComponent<SpriteRenderer>();
        collider = secretObj.transform.GetComponent<BoxCollider2D>();
    }

    void Start()
    {
        collider.enabled = false;
        renderer.enabled = false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            if(!transform.DotTest(other.transform, Vector2.down))
                return;

            collider.enabled = true;
            renderer.enabled = true;
        }
    }
}
