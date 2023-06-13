using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Singleton 싱글톤
    public static GameManager Instance {get; private set;}

    public int world {get; private set;}
    public int stage {get; private set;}
    public int lives {get; private set;}

    [HideInInspector] public Vector2 SpawnPoint; // 시작 위치
    private int Checkpoint; // 체크 포인트 위치값
    public float bgmSoundValue; // 배경음악 사운드 크기
    public float effectSoundValue; // 효과음 사운드 크기

    private void Awake()
    {
        // 싱글톤을 위한 기본 세팅
        if(Instance != null){
            DestroyImmediate(gameObject);
        } else {
            Instance = this;
            DontDestroyOnLoad(gameObject); // 게임씬을 옮길 때 사라지지 않음
        }
    }

    public void CheckpointSet(int value)
    {
        Checkpoint = value;

        switch(Checkpoint)
        {
            case 0:
                SpawnPoint = new Vector2(-9.5f, 2f);
                break;
            case 1:
                SpawnPoint = new Vector2(75f, 2f);
                break;
        }
    }

    public int GetCheckpoint()
    {
        return Checkpoint;
    }

    public void StartSceneLoad(){
        SceneManager.LoadScene("StartScene");        
    }

    public void GameSceneLoad(){
        SceneManager.LoadScene("GameScene");
    }

    public void DeadSceneLoad(){
        SceneManager.LoadScene("DeathScene");
    }

    public void EndingSceneLoad(){
        SceneManager.LoadScene("EndingScene");
    }
}