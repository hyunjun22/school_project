using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    public TaxiTrigger trafficLight;
    private new BoxCollider2D collider;
    private new SpriteRenderer renderer;
    private bool stopButton = false; // 멈춤 버튼이 눌러져있는가?

    void Awake()
    {
        collider = trafficLight.gameObject.GetComponent<BoxCollider2D>();
        renderer = trafficLight.gameObject.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // 멈춤 버튼이 눌러져있을 때
        if(stopButton){
            collider.enabled = false;
            renderer.color = Color.red;
        }
        else
        {
            collider.enabled = true;
            renderer.color = Color.green;
        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            if(!stopButton)
                stopButton = true;
            else
                stopButton = false;
        }
    }
}
