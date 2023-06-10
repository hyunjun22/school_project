using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Singleton �̱���
    public static GameManager Instance {get; private set;}

    public int world {get; private set;}
    public int stage {get; private set;}
    public int lives {get; private set;}

    public Vector2 SpawnPoint = new Vector2(-9.5f, 2f); // ���� ��ġ

    private void Awake()
    {
        // �̱����� ���� �⺻ ����
        if(Instance != null){
            DestroyImmediate(gameObject);
        } else {
            Instance = this;
            DontDestroyOnLoad(gameObject); // ���Ӿ��� �ű� �� ������� ����
        }
    }

    void Start(){
        
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
}