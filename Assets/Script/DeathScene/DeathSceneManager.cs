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
        timer -= 1f * Time.deltaTime; // 1�ʿ� 1�� �����ȴ�.

        if(timer < 0f){
            GameManager.Instance.GameSceneLoad(); // ���Ӿ� �ε�
        }
    }
}
