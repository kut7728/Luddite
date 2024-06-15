using System.Collections;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public TMP_Text dialogueText; // Text 대신 TMP_Text를 사용합니다.
    private string[] dialogues = 
    {
        "자본가: 이건 제 부탁에 대한 작은 성의입니다.",
        "정치인: 너무 걱정하지 않으셔도 됩니다.",
        "정치인: 이 법안이면 시위대는 얼마 안 가 조용해질 겁니다.",
        "네드: 노동자들은 자신들에게 인간다운 삶을 보장해달라고 거리로 나섰지만",
        "투표권도 없는 그들의 목소리가 영국 의회에 닿지는 못했지..",
        "내드: 오히려 자본가들이 정치인들과 결탁하여 1799년 '단결금지법'을 제정하면서 노동자들을 더욱 탄압하기 시작했어..",
    };
    public float delayBetweenLines = 2.0f; // 각 대사 사이의 지연 시간 (초)
    public float letterDelay = 0.05f; // 각 글자 사이의 지연 시간 (초)

    void Start()
    {
        StartCoroutine(DisplayDialogue());
    }

    private IEnumerator DisplayDialogue()
    {
        foreach (string dialogue in dialogues)
        {
            yield return StartCoroutine(TypeSentence(dialogue));
            yield return new WaitForSeconds(delayBetweenLines); // 지연 시간만큼 대기
        }
        dialogueText.text = ""; // 모든 대사가 끝나면 텍스트를 비웁니다.
    }

    private IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(letterDelay);
        }
    }
}
