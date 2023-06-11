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
        //#.���� ��ư
        if(Input.GetKeyDown(KeyCode.Escape)){
            SettingButton();
        }
    }

    //#.��ư ����
    void Connect(){
        retryButton.onClick.AddListener(() => GameManager.Instance.DeadSceneLoad());
        RestartButton.onClick.AddListener(() => GameManager.Instance.GameSceneLoad());
    }

    //#.���� ��ư
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
