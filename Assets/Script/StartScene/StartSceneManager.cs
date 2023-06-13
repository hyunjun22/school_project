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
        GameManager.Instance.CheckpointSet(0); // 체크포인트 초기화
        GameManager.Instance.bgmSoundValue = 1;   // 사운드 1로 초기화
        GameManager.Instance.effectSoundValue = 1;
    }

    void Update()
    {
        MoveLogo();

        if(Input.GetKeyDown(KeyCode.Space)){
            GameManager.Instance.GameSceneLoad();
        }
    }

    //#.로고 움직이기
    void MoveLogo()
    {
        // 로고 움직임 완료될 시
        if(Logo.position.y > 1){
            FadeOut();        
            return;
        }
        Logo.position += Vector3.up * speed * Time.deltaTime;
    }

    void FadeOut()
    {   
        // 페이드 아웃 종료 시
        if(fadeCount < 0){
            background.gameObject.SetActive(false);
            Logo.gameObject.SetActive(false);
            return;
        }

        fadeCount -= 0.2f * Time.deltaTime;
        background.color = new Color(0,0,0, fadeCount);
    }
}
