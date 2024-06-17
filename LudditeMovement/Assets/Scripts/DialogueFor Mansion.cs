using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogueOnKeyPressmansion : MonoBehaviour
{
    public TextMeshProUGUI dialogueText; // 텍스트메쉬프로 UI 텍스트
    public string[] dialogues=
    {
        "자본가:이건 제 부탁에 대한 작은 성의입니다.",
        "정치인:너무 걱정하지 않으셔도 됩니다",
        "이 법안이면 시위대는 얼마안가 조용해질 겁니다",
        "네드:노동자들은 자신들에게 인간적인 삶을 보장해 달라고",
        "거리로 나섰지만 투표권도 없는 그들의 목소리가 영국 의회에 닿는 일은 없었지..",
        "오히려 자본가들이 정치인들과 결탁하여 ",
        "1799년 단결금지법을 제정하면서 노동자들을 더욱 심하게 탄압하기 시작했어..",
        "space 바를 눌러 다음 씬 이동",
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
