using UnityEngine;
using UnityEngine.UI;

public class ButtonConnecter : MonoBehaviour
{
    public Button retryButton;

    void Start()
    {
        Connect();
    }

    //#.��ư ����
    void Connect(){
        retryButton.onClick.AddListener(() => GameManager.Instance.DeadSceneLoad());
    }
}
