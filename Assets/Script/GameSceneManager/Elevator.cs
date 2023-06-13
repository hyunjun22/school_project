using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    Animator animator;
    bool isOpen; // ���� ���ȴ°�?
    public RectTransform spacebar;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        animator.SetBool("open", isOpen);

        if(isOpen){
            if(Input.GetKeyDown(KeyCode.Space)){
                GameManager.Instance.EndingSceneLoad();
            }
            spacebar.gameObject.SetActive(true);
        } else {
            spacebar.gameObject.SetActive(false);
        }

        // UI text�� ���� ������Ʈ�� ��ġ���� ����ϰ� �����
        spacebar.transform.position = new Vector2(transform.position.x, transform.position.y + 2f);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Player")
            isOpen = true;
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.tag == "Player")
            isOpen = false;
    }
}
