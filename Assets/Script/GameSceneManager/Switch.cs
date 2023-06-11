using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    public TrafficLight trafficLight;
    private new BoxCollider2D collider;
    private new SpriteRenderer renderer;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            trafficLight.ChangeLight();
        }
    }
}
