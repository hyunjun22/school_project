using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    public TrafficLight trafficLight;
    private AudioSource audioSource;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            trafficLight.ChangeLight();

            // ����� ���
            audioSource.volume = GameManager.Instance.effectSoundValue;
            audioSource.Play();
        }
    }
}
