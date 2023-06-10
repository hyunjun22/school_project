using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveFlag : MonoBehaviour
{
    public int CheckpointValue;

    private void OnTriggerEnter2D(Collider2D other) {
        // �÷��̾�� ���� ��
        if(other.gameObject.tag == "Player")
        {
            Debug.Log("save!");
            GameManager.Instance.CheckpointSet(CheckpointValue);
        }    
    }
}
