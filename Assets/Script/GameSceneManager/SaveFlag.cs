using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveFlag : MonoBehaviour
{
    public int CheckpointValue;
    public Transform flag;
    bool isSave;  // 세이브 되었는가?
    float Height; // 높이
    float maxHeight => 1.25f + this.transform.position.y; // 최고높이
    float minHeight => -2f   + this.transform.position.y; // 최저높이

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
        // 플레이어와 닿을 시
        if(other.gameObject.tag == "Player")
        {
            Debug.Log("save!");
            GameManager.Instance.CheckpointSet(CheckpointValue);
            isSave = true;
        }    
    }
}
