using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveFlag : MonoBehaviour
{
    public int CheckpointValue;
    public Transform flag;
    bool isSave;  // ���̺� �Ǿ��°�?
    float Height; // ����
    float maxHeight => 1.25f + this.transform.position.y; // �ְ����
    float minHeight => -2f   + this.transform.position.y; // ��������
    public AudioSource myAudio;

    void Awake(){
        myAudio = GetComponent<AudioSource>();
    }

    void Start()
    {
        if(GameManager.Instance.GetCheckpoint() == 1){
            isSave = true;
            flag.position = new Vector2(flag.position.x, maxHeight);
        } else {
            isSave = false;
            flag.position = new Vector2(flag.position.x, minHeight);
        }
        
        Height = flag.position.y;
    }

    void Update()
    {
        if(isSave && maxHeight > Height)
        {
            Height += 1f * Time.deltaTime;
            flag.position = new Vector2(flag.position.x, Height);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        // �÷��̾�� ���� ��
        if(other.gameObject.tag == "Player")
        {
            // �����
            if(!isSave){
                myAudio.volume = GameManager.Instance.effectSoundValue;
                myAudio.Play();
            }

            Debug.Log("save!");
            GameManager.Instance.CheckpointSet(CheckpointValue);
            isSave = true;
        }    
    }
}
