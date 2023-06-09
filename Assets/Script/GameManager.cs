using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Singleton �̱���
    public static GameManager Instance {get; private set;}

    public int world {get; private set;}
    public int stage {get; private set;}
    public int lives {get; private set;}

    Transform playerTrans; // �÷��̾� ��ǥ
    public Vector2 SpawnPoint; // ���� ��ġ

    private void Awake()
    {
        // �̱����� ���� �⺻ ����
        if(Instance != null){
            DestroyImmediate(gameObject);
        } else {
            Instance = this;
            DontDestroyOnLoad(gameObject); // ���Ӿ��� �ű� �� ������� ����
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