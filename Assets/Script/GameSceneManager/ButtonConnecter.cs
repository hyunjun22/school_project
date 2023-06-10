using UnityEngine;
using UnityEngine.UI;

public class ButtonConnecter : MonoBehaviour
{
    public Button retryButton;

    void Start()
    {
        Connect();
    }

    //#.버튼 연결
    void Connect(){
        retryButton.onClick.AddListener(() => GameManager.Instance.DeadSceneLoad());
    }
}
