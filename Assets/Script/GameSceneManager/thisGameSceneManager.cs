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

        //#.���� ����
        bgmSoundSlider.value = GameManager.Instance.bgmSoundValue;
        effectSoundSlider.value = GameManager.Instance.effectSoundValue;
    }

    void Update()
    {
        //#.���� ��ư
        if(Input.GetKeyDown(KeyCode.Escape)){
            SettingButton();
        }

        //#.���� ����
        bgm.volume = bgmSoundSlider.value;
        playerSound.volume = effectSoundSlider.value;
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
