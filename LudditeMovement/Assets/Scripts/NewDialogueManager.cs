using System.Collections;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public TMP_Text dialogueText; // Text 대신 TMP_Text를 사용합니다.
    private string[] dialogues = 
    {
        "Hello, this is the first line of the dialogue.",
        "Here comes the second line.",
        "And finally, this is the third line."
    };
    public float displayDuration = 5.0f; // 대사가 표시되는 시간 (초)
    private bool isDisplaying = false; // 대사가 표시 중인지 확인하는 변수

    void Start()
    {
        dialogueText.gameObject.SetActive(false); // 시작 시 대사창을 비활성화
    }

    void OnTriggerEnter(Collider other)
    {
        if (!isDisplaying)
        {
            StartCoroutine(DisplayDialogue());
        }
    }

    private IEnumerator DisplayDialogue()
    {
        isDisplaying = true;
        dialogueText.gameObject.SetActive(true);

        foreach (string dialogue in dialogues)
        {
            dialogueText.text = dialogue;
            yield return new WaitForSeconds(displayDuration); // 지연 시간만큼 대기
        }

        dialogueText.text = "";
        yield return new WaitForSeconds(displayDuration); // 모든 대사가 끝난 후 대사창을 유지할 시간
        dialogueText.gameObject.SetActive(false);

        isDisplaying = false;
    }
}
