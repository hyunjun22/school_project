using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathSceneManager : MonoBehaviour
{

    float timer = 0f;

    void Start()
    {
        
    }

    void Update()
    {
        LoadGameScene();
    }

    void LoadGameScene(){
        timer += 1f * Time.deltaTime; // 1초에 1씩 증가된다.

        if(timer > 3f){
            GameManager.Instance.GameSceneLoad(); // 게임씬 로드
        }
    }
}
