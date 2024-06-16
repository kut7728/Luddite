using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogueOnKeyPress : MonoBehaviour
{
    public TextMeshProUGUI dialogueText; // 텍스트메쉬프로 UI 텍스트
    public string[] dialogues=
    {
        "시민1:아이들의 노동착취를 중단하라!",
        "시민2:과도한 노동시간을 줄여라!",
        "시민3:인간적인 노동환경을 보장하라!",
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
