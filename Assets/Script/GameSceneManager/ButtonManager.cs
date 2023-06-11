using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    public Button retryButton;
    public Button RestartButton;
    public GameObject Board;

    void Start()
    {
        Connect();
        Board.SetActive(false);
    }

    void Update()
    {
        //#.설정 버튼
        if(Input.GetKeyDown(KeyCode.Escape)){
            SettingButton();
        }
    }

    //#.버튼 연결
    void Connect(){
        retryButton.onClick.AddListener(() => GameManager.Instance.DeadSceneLoad());
        RestartButton.onClick.AddListener(() => GameManager.Instance.GameSceneLoad());
    }

    //#.설정 버튼
    public void SettingButton(){
        if(Board.activeSelf){
            Board.SetActive(false);
        } else {
            Board.SetActive(true);
        }
    }

    public void leaveButton()
    {
        Debug.Log("leave");
        Application.Quit();
    }
}
