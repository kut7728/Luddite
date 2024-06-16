using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Collections;

public class DialogueOnKeyPress2 : MonoBehaviour
{
    public TextMeshProUGUI dialogueText; // 텍스트메쉬프로 UI 텍스트
    public string[] dialogues=
    {
        "나는 네드 러드…",
        "지금 동료들과 함께 공장의 기계들을 가차없이 부수고 있는 중이야.",
        "너는 내가 왜 이런 짓을 벌이는지 궁금하니…?",
        "때는 시간을 거슬러 6개월 전이었어….",
    }; // 대사 배열
    private int currentDialogueIndex = 0; // 현재 출력할 대사 인덱스
    private Coroutine clearTextCoroutine; // 텍스트 지우기 코루틴 참조

    void Start()
    {
        dialogueText.text = ""; // 초기화 시 텍스트를 빈 문자열로 설정
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            // 대사 출력
            dialogueText.text = dialogues[currentDialogueIndex];
            // 다음 대사로 인덱스 증가, 모든 대사가 출력되면 다시 처음으로 돌아감
            currentDialogueIndex = (currentDialogueIndex + 1) % dialogues.Length;

            // 기존 코루틴이 실행 중이면 멈춤
            if (clearTextCoroutine != null)
            {
                StopCoroutine(clearTextCoroutine);
            }
            // 새로운 코루틴 시작
            clearTextCoroutine = StartCoroutine(ClearTextAfterDelay(3f));
        }
    }

    IEnumerator ClearTextAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        dialogueText.text = "";
        clearTextCoroutine = null; // 코루틴 참조를 null로 설정
    }
}
