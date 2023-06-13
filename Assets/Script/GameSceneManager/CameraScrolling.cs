using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScrolling : MonoBehaviour
{
    public float limit_left;  // 카메라가 왼쪽으로 움직일 수 있는 최대값
    public float limit_right; // 카메라가 오른쪽으로 움직일 수 있는 최대값

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

        // 플레이어의 x값을 카메라가 따라가기
        Vector3 cameraPosition = transform.position;
        cameraPosition.x = player.position.x;

        // 리미트 정하기
        cameraPosition.x = cameraPosition.x > limit_left ? cameraPosition.x : limit_left;
        cameraPosition.x = cameraPosition.x < limit_right ? cameraPosition.x : limit_right;

        // 반환
        transform.position = cameraPosition;
    }
}
