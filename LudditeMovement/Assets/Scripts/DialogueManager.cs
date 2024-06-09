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
    public float delayBetweenLines = 5.0f; // 각 대사 사이의 지연 시간 (초)

    void Start()
    {
        StartCoroutine(DisplayDialogue());
    }

    private IEnumerator DisplayDialogue()
    {
        foreach (string dialogue in dialogues)
        {
            dialogueText.text = dialogue;
            yield return new WaitForSeconds(delayBetweenLines); // 지연 시간만큼 대기
        }
        dialogueText.text = ""; // 모든 대사가 끝나면 텍스트를 비웁니다.
    }
}
