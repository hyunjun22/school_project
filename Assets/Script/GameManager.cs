using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Singleton 싱글톤
    public static GameManager Instance {get; private set;}

    public int world {get; private set;}
    public int stage {get; private set;}
    public int lives {get; private set;}

    Transform playerTrans; // 플레이어 좌표
    public Vector2 SpawnPoint; // 시작 위치

    private void Awake()
    {
        // 싱글톤을 위한 기본 세팅
        if(Instance != null){
            DestroyImmediate(gameObject);
        } else {
            Instance = this;
            DontDestroyOnLoad(gameObject); // 게임씬을 옮길 때 사라지지 않음
        }

        playerTrans = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void Start(){
        playerTrans.transform.position = SpawnPoint;
    }

    public void StartSceneLoad(){
        SceneManager.LoadScene("StartScene");        
    }

    public void GameSceneLoad(){
        SceneManager.LoadScene("GameScene");
        playerTrans.transform.position = SpawnPoint;
    }

    public void DeadSceneLoad(){
        SceneManager.LoadScene("DeathScene");
    }
}