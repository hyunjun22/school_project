using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficLight : MonoBehaviour
{
    PlayerController playercontroller;
    private new BoxCollider2D collider;
    private new SpriteRenderer renderer;
    public Rigidbody2D Trap_rigid; // ������ ������ٵ�
    public Vector2 direction; // ����
    public float Force;       // ���� ũ��
    public Sprite redTraffic;
    public Sprite greenTraffic;
    public bool isRed;

    void Awake()
    {
        playercontroller = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        collider = gameObject.GetComponent<BoxCollider2D>();
        renderer = gameObject.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        TrafficColor();
    }

    void TrafficColor()
    {
        if(isRed){
            renderer.sprite = redTraffic;
            collider.enabled = false;
        } else {
            renderer.sprite = greenTraffic;
            collider.enabled = true;
        }
    }

    // ��������Ʈ ��ȯ
    public void ChangeLight()
    {
        isRed = isRed ? false : true; // �ٲٱ�
    }

    //#.Ʈ���ſ� �浹
    void OnTriggerEnter2D(Collider2D other){
        
        // �÷��̾�� �ε��� ���� ����
        if(other.gameObject.tag == "Player")
        {
            Trap_rigid.gameObject.SetActive(true);
            Trap_rigid.velocity = direction * Force;
        }

    }
}
