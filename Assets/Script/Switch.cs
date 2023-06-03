using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    public TaxiTrigger trafficLight;
    private new BoxCollider2D collider;
    private new SpriteRenderer renderer;
    private bool stopButton = false; // ���� ��ư�� �������ִ°�?

    void Awake()
    {
        collider = trafficLight.gameObject.GetComponent<BoxCollider2D>();
        renderer = trafficLight.gameObject.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // ���� ��ư�� ���������� ��
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
