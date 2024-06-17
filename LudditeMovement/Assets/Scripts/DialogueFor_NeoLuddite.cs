using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement; // 씬 전환을 위한 네임스페이스


public class DialogueFor_NeoLuddite : MonoBehaviour
{
    public TextMeshProUGUI dialogueText; // 텍스트메쉬프로 UI 텍스트
    public GameObject dialogueUI; // 대화 UI 오브젝트
    public string[] dialogues =
    {
        "네드 : 인공지능의 등장으로 인한 현대판 러다이트 운동의 태동이 얼마 남지 않았을지도 몰라...",
"누군가는 우리들을 보고 신기술에 적응하지 못하는 도태된 사람들이라고 생각할 수도 있어.",
"하지만 충분한 법적 보호망이 갖춰지지 않은 사회에서 신기술의 발전은 누군가를 벼랑끝에 내몰리게 할 수도 있어.",
"벼랑끝에 내몰리고 아무도 우리의 이야기를 들어주지 않을때 우리는 러다이트 운동을 결심했어.",
"너희는 우리의 이야기를 교훈삼아 약자의 희생없이 신기술을 받아들일 수 있는 성숙한 사회가 되기를 기도할게...",

    }; // 대사 배열


    private int currentDialogueIndex = 0; // 현재 출력할 대사 인덱스
    private Coroutine displayTextCoroutine; // 텍스트 출력 코루틴 참조
    private bool isLastDialogueDisplayed = false; // 마지막 대사가 출력되었는지 여부

    public string nextSceneName = "Scene_8_Outro"; // 전환할 다음 씬 이름


    void Start()
    {
        dialogueText.text = ""; // 초기화 시 텍스트를 빈 문자열로 설정
        dialogueUI.SetActive(false); // UI를 시작할 때 비활성화
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (isLastDialogueDisplayed)
            {
                // 마지막 대사가 이미 출력된 상태에서 F 키를 누르면 UI를 비활성화
                dialogueUI.SetActive(false);
                isLastDialogueDisplayed = false; // 상태 초기화
            }
            else if (currentDialogueIndex < dialogues.Length)
            {
                // 기존 텍스트 출력 코루틴이 실행 중이면 멈춤
                if (displayTextCoroutine != null)
                {
                    StopCoroutine(displayTextCoroutine);
                }

                // 대사 출력 코루틴 시작
                displayTextCoroutine = StartCoroutine(DisplayDialogue(dialogues[currentDialogueIndex]));

                // 다음 대사로 인덱스 증가
                currentDialogueIndex++;


                // 새로운 텍스트 지우기 코루틴 시작
                // clearTextCoroutine = StartCoroutine(ClearTextAfterDelay(3f));

                // 마지막 대사가 출력되었는지 확인
                if (currentDialogueIndex >= dialogues.Length)
                {
                    isLastDialogueDisplayed = true;
                    // 마지막 대사 출력 시 오디오 클립 재생 시작
                    StartCoroutine(TransitionToNextSceneAfterDelay(3f));

                }
            }
        }
    }

    IEnumerator TransitionToNextSceneAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(nextSceneName); // 다음 씬 로드
    }


    IEnumerator DisplayDialogue(string dialogue)
    {
        dialogueUI.SetActive(true); // 대사가 시작될 때 UI 활성화
        dialogueText.text = ""; // 텍스트 초기화
        foreach (char letter in dialogue.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(0.05f); // 각 문자 출력 후 잠시 대기
        }

    }



}
