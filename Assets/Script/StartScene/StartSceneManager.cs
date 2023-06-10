using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartSceneManager : MonoBehaviour
{
    public Transform Logo;
    private SpriteRenderer LogoSpr;
    public SpriteRenderer background;
    public float speed;
    float fadeCount = 1;

    void Awake()
    {
        LogoSpr = Logo.gameObject.GetComponent<SpriteRenderer>();
        GameManager.Instance.CheckpointSet(0); // üũ����Ʈ �ʱ�ȭ
    }

    void Update()
    {
        MoveLogo();
    }

    //#.�ΰ� �����̱�
    void MoveLogo()
    {
        // �ΰ� ������ �Ϸ�� ��
        if(Logo.position.y > 1){
            FadeOut();        
            return;
        }
        Logo.position += Vector3.up * speed * Time.deltaTime;
    }

    void FadeOut()
    {   
        // ���̵� �ƿ� ���� ��
        if(fadeCount < 0){
            background.gameObject.SetActive(false);
            Logo.gameObject.SetActive(false);
            return;
        }

        fadeCount -= 0.2f * Time.deltaTime;
        background.color = new Color(0,0,0, fadeCount);
        LogoSpr.color    = new Color(1,1,1, fadeCount);
    }
}
