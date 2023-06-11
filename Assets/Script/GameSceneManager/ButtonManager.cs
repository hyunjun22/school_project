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

    //#.버튼 연결
    void Connect(){
        retryButton.onClick.AddListener(() => GameManager.Instance.DeadSceneLoad());
    }

    //#.설정 버튼
    public void SettingButton(){
        if(Board.activeSelf){
            Board.SetActive(false);
        } else {
            Board.SetActive(true);
        }
    }
}
