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
        timer += 1f * Time.deltaTime; // 1�ʿ� 1�� �����ȴ�.

        if(timer > 3f){
            GameManager.Instance.GameSceneLoad(); // ���Ӿ� �ε�
        }
    }
}
