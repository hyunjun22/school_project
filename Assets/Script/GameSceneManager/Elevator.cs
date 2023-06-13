using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    Animator animator;
    bool isOpen; // 문이 열렸는가?
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

        // UI text와 게임 오브젝트의 위치값을 비슷하게 만든다
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
