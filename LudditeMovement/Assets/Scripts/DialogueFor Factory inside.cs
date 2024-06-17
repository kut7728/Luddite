using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogueOnKeyPressfac : MonoBehaviour
{
    public TextMeshProUGUI dialogueText; // 텍스트메쉬프로 UI 텍스트
    public string[] dialogues=
    {
        "여성: 할당량을 채우려면 끊임없이 일해야해...",
        "여성: 남편이 해고당한 이후부터, 내 일당이 없으면 온가족이 꼼짝없이 굶게되니까..",
        "네드: 공장장들은 어린 아이들에게도 거리낌 없이 높은 강도의 노동을 시켰어..",
        "공장장: 올해도 역대급 실적이구만!",
        "증기기관이 도입된 이후 숙련공들을 해고하고 인건비를 많이 아꼈어..",
        "특히 어린아이들은 절반의 임금으로도 군말없이 일해준단 말이지..",
        "Space 바를 눌러 다음 씬으로 이동",
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
