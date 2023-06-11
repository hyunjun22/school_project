using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    public Button retryButton;
    public GameObject Board;

    void Start()
    {
        Connect();
    }

    //#.��ư ����
    void Connect(){
        retryButton.onClick.AddListener(() => GameManager.Instance.DeadSceneLoad());
    }

    //#.���� ��ư
    public void SettingButton(){
        if(Board.activeSelf){
            Board.SetActive(false);
        } else {
            Board.SetActive(true);
        }
    }
}
