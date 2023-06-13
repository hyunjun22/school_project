using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Singleton �̱���
    public static GameManager Instance {get; private set;}

    public int world {get; private set;}
    public int stage {get; private set;}
    public int lives {get; private set;}

    [HideInInspector] public Vector2 SpawnPoint; // ���� ��ġ
    private int Checkpoint; // üũ ����Ʈ ��ġ��
    public float bgmSoundValue; // ������� ���� ũ��
    public float effectSoundValue; // ȿ���� ���� ũ��

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