using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueFor_NeoLuddite : MonoBehaviour
{
    public TextMeshProUGUI dialogueText; // 텍스트메쉬프로 UI 텍스트
    public GameObject dialogueUI; // 대화 UI 오브젝트
    public string[] dialogues =
    {
        "네드 : 우리의 투쟁은 정부의 강경한 대응으로 수많은 희생끝에 결국 실패로 돌아갔지만 긍정적인 사회 변화를 이끌어 냈어...",
        "재판관 : 노동자들이 공정한 노동 조건을 누리고, 인간다운 생활을 할 수 있도록 보장받아야합니다.",
        "따라서, 본 법원은 원고들의 청구를 인용하여 노동자들의 단체 교섭권과 단결권, 그리고 노동조합 설립을 인정합니다."
    }; // 대사 배열
    public AudioSource audioSource; // AudioSource 컴포넌트
    public AudioClip[] audioClips; // 재생할 오디오 클립 배열
    public Animator[] npcAnimators; // NPC들의 Animator 컴포넌트 배열
    public string npcTag = "NPC"; // NPC 오브젝트의 태그

    private int currentDialogueIndex = 0; // 현재 출력할 대사 인덱스
    private Coroutine clearTextCoroutine; // 텍스트 지우기 코루틴 참조
    private Coroutine displayTextCoroutine; // 텍스트 출력 코루틴 참조
    private bool isLastDialogueDisplayed = false; // 마지막 대사가 출력되었는지 여부

    void Start()
    {
        dialogueText.text = ""; // 초기화 시 텍스트를 빈 문자열로 설정
        dialogueUI.SetActive(false); // UI를 시작할 때 비활성화
        AssignNPCAnimators(); // NPC 애니메이터 자동 할당
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

                // 기존 텍스트 지우기 코루틴이 실행 중이면 멈춤
                if (clearTextCoroutine != null)
                {
                    StopCoroutine(clearTextCoroutine);
                }
                // 새로운 텍스트 지우기 코루틴 시작
                // clearTextCoroutine = StartCoroutine(ClearTextAfterDelay(3f));

                // 마지막 대사가 출력되었는지 확인
                if (currentDialogueIndex == 3)
                {
                    
                    // 마지막 대사 출력 시 오디오 클립 재생 시작
                    StartCoroutine(PlayAudioClipsSequentially());
                    isLastDialogueDisplayed = true;
                }
                if (currentDialogueIndex == 4)
                {
                    isLastDialogueDisplayed = false;
                    PlayNPCAnimations();
                }
                if (currentDialogueIndex == 6)
                {
                    isLastDialogueDisplayed = true;
                }
            }
        }
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

    IEnumerator ClearTextAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        dialogueText.text = "";
        clearTextCoroutine = null; // 코루틴 참조를 null로 설정
    }

    IEnumerator PlayAudioClipsSequentially()
    {
        foreach (AudioClip clip in audioClips)
        {
            audioSource.clip = clip;
            audioSource.Play();
            yield return new WaitForSeconds(clip.length);
        }
        
    }

    void AssignNPCAnimators()
    {
        GameObject[] npcObjects = GameObject.FindGameObjectsWithTag(npcTag); // 태그를 가진 모든 NPC 오브젝트 찾기
        npcAnimators = new Animator[npcObjects.Length];
        for (int i = 0; i < npcObjects.Length; i++)
        {
            npcAnimators[i] = npcObjects[i].GetComponent<Animator>(); // Animator 컴포넌트 할당
            npcAnimators[i].applyRootMotion = false; // 루트 모션 비활성화
        }
    }

    void PlayNPCAnimations()
    {
        foreach (Animator animator in npcAnimators)
        {
            animator.SetTrigger("PlayAnimation"); // 애니메이션 트리거 설정 (애니메이션 이름은 필요에 따라 변경)
        }
    }

    
}
