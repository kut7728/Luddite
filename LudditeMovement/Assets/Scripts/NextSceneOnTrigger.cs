using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class NextSceneOnTrigger : MonoBehaviour
{
    public TextMeshProUGUI messageText; // 텍스트메시프로 UI 요소를 참조
    public string displayMessage = "Press Space to interact"; // 표시할 메시지
    public GameObject dialogueUI; // 대화 UI 오브젝트

    private bool isPlayerInTrigger = false;

    private void Start()
    {
        // 시작 시 텍스트 메시지를 비웁니다.
        if (messageText != null)
        {
            messageText.text = "";
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInTrigger = true;
            dialogueUI.SetActive(true);
            // 플레이어가 콜라이더에 들어오면 메시지를 표시합니다.
            if (messageText != null)
            {
                messageText.text = displayMessage;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInTrigger = false;
            // 플레이어가 콜라이더에서 나가면 메시지를 지웁니다.
            if (messageText != null)
            {
                messageText.text = "";
            }
        }
    }

    private void Update()
    {
        if (isPlayerInTrigger && Input.GetKeyDown(KeyCode.Space))
        {
            LoadNextScene();
        }
    }

    private void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;

        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
        else
        {
            Debug.Log("마지막 씬입니다. 더 이상 씬이 없습니다.");
        }
    }
}


