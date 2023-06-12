using UnityEngine;
using UnityEngine.UI;

public class thisGameSceneManager : MonoBehaviour
{
    //#.button
    public Button retryButton;
    public Button RestartButton;
    public GameObject Board;

    //#.sound
    private AudioSource bgm;
    public Slider bgmSoundSlider;
    public Slider effectSoundSlider;
    public AudioSource playerSound;

    void Awake()
    {
        bgm = GetComponent<AudioSource>();
        playerSound = GameObject.FindGameObjectWithTag("Player").GetComponent<AudioSource>();
    }

    void Start()
    {
        Connect();
        Board.SetActive(false);

        //#.사운드 세팅
        bgmSoundSlider.value = GameManager.Instance.bgmSoundValue;
        effectSoundSlider.value = GameManager.Instance.effectSoundValue;
    }

    void Update()
    {
        //#.설정 버튼
        if(Input.GetKeyDown(KeyCode.Escape)){
            SettingButton();
        }

        //#.사운드 조절
        bgm.volume = bgmSoundSlider.value;
        playerSound.volume = effectSoundSlider.value;
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
            GameManager.Instance.bgmSoundValue = bgmSoundSlider.value;
            GameManager.Instance.effectSoundValue = effectSoundSlider.value;            
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
