using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DeathSceneManager : MonoBehaviour
{

    float timer = 3f;
    public TextMeshProUGUI text;

    void Update()
    {
        LoadGameScene();

        text.text = timer.ToString("F0");
    }

    void LoadGameScene(){
        timer -= 1f * Time.deltaTime; // 1초에 1씩 증가된다.

        if(timer < 0f){
            GameManager.Instance.GameSceneLoad(); // 게임씬 로드
        }
    }
}
