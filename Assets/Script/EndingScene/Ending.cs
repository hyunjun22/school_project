using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Ending : MonoBehaviour
{
    public RectTransform EndingCredit;
    public RectTransform buttonBundle;
    public Transform Player;
    public float speed;
    private float speed2;
    public float rotatePower; // ȸ�� ��
    private float rotateValue;
    public float timer;
    float valueY;

    //#.��ư
    public Button endingCredit;

    void Start()
    {
        timer = 0;
        speed2 = speed;
    }

    void Update()
    {
        

        // ���� ũ���� �ø���
        valueY = EndingCredit.position.y + speed * Time.deltaTime;
        EndingCredit.position = new Vector2(0, valueY);

        // �÷��̾� ȸ��
        rotateValue += rotatePower * Time.deltaTime;
        Player.localEulerAngles = new Vector3(0, 0, -rotateValue);

        // 5130 ������ ����
        if(EndingCredit.anchoredPosition.y > 5200f){
            ButtonUp();
            speed = 0f;
        }
    }

    void ButtonUp(){
        timer += Time.deltaTime;
        valueY = buttonBundle.position.y + speed2 * Time.deltaTime;
        buttonBundle.position = new Vector2(0, valueY);

        if(buttonBundle.anchoredPosition.y > -56f)
            speed2 = 0f;
    }

    public void leave(){
        Application.Quit();
    }

    public void EndingCreditReturn(){
        SceneManager.LoadScene("EndingScene");
    }
}
