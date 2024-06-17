using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogueManager55 : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;
    public string[] dialogues = new string[]
    {
        "여성: 할당량을 채우려면 끊임없이 일해야해...",
        "여성: 남편이 해고당한 이후부터, 내 일당이 없으면 온가족이 꼼짝없이 굶게되니까..",
        "네드: 공장장들은 어린 아이들에게도 거리낌 없이 높은 강도의 노동을 시켰어..",
        "공장장: 올해도 역대급 실적이구만!",
        "증기기관이 도입된 이후 숙련공들을 해고하고 인건비를 많이 아꼈어..",
        "특히 어린아이들은 절반의 임금으로도 군말없이 일해준단 말이지.."
    };
    private int currentDialogueIndex = 0;
    private bool isDisplaying = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && !isDisplaying)
        {
            DisplayNextDialogue();
        }
    }

    void DisplayNextDialogue()
    {
        if (currentDialogueIndex < dialogues.Length)
        {
            StartCoroutine(DisplayDialogue(dialogues[currentDialogueIndex]));
            currentDialogueIndex++;
        }
        else
        {
            currentDialogueIndex = 0; // Reset to the first dialogue if all dialogues are displayed
        }
    }

    IEnumerator DisplayDialogue(string dialogue)
    {
        isDisplaying = true;
        dialogueText.text = dialogue;
        dialogueText.gameObject.SetActive(true);
        yield return new WaitForSeconds(3f);
        dialogueText.gameObject.SetActive(false);
        isDisplaying = false;
    }
}
