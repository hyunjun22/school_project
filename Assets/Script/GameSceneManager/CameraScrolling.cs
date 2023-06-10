using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScrolling : MonoBehaviour
{
    public float limit_left;  // ī�޶� �������� ������ �� �ִ� �ִ밪
    public float limit_right; // ī�޶� ���������� ������ �� �ִ� �ִ밪

    Transform player;
    PlayerController playerCon;
    

    void Awake()
    {
        player = GameObject.FindWithTag("Player").transform;
        playerCon = player.gameObject.GetComponent<PlayerController>();
    }

    void LateUpdate()
    {
        if(playerCon.Untouchable)
            return;

        // �÷��̾��� x���� ī�޶� ���󰡱�
        Vector3 cameraPosition = transform.position;
        cameraPosition.x = player.position.x;

        cameraPosition.x = cameraPosition.x > limit_left ? cameraPosition.x : limit_left;

        // ��ȯ
        transform.position = cameraPosition;
    }
}
