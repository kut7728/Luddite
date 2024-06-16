using System.Collections;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using TMPro;

/// <summary>
/// F 키를 눌렀을 때 대사를 순서대로 표시하고 일정 시간 후에 대사를 지우는 스크립트입니다.
/// </summary>
public class DialogueOnKeyPress2 : MonoBehaviour
{
    [Tooltip("대사를 표시할 TextMeshProUGUI 컴포넌트")]
    public TextMeshProUGUI dialogueText;

    [Tooltip("표시할 대사 문자열 배열")]
    public string[] dialogues =
    {
        "나는 네드 러드…",
        "지금 동료들과 함께 공장의 기계들을..",
        "가차없이 부수고 있는 중이야.",
        "너는 내가 왜,",
        "이런 짓을 벌이는지 궁금하니…?",
        "때는 시간을 거슬러 6개월 전이었어…."
    };

    private int currentDialogueIndex = 0; // 현재 출력할 대사 인덱스
    private Coroutine clearTextCoroutine; // 텍스트 지우기 코루틴 참조

    void Start()
    {
        // 초기화 시 텍스트를 빈 문자열로 설정
        dialogueText.text = "";
    }

    void Update()
    {
        // F 키가 눌렸는지 확인
        if (Input.GetKeyDown(KeyCode.F))
        {
            // 현재 대사 출력
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

    /// <summary>
    /// 일정 시간 후에 대사를 지우는 코루틴입니다.
    /// </summary>
    /// <param name="delay">텍스트를 지우기 전까지 기다릴 시간 (초 단위)</param>
    /// <returns>코루틴의 IEnumerator</returns>
    private IEnumerator ClearTextAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        // 대사 텍스트 지우기
        dialogueText.text = "";
        
        // 코루틴 참조를 null로 설정
        clearTextCoroutine = null;
    }
}
