using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager2 : MonoBehaviour
{
    public TMP_Text dialogueText; // Text 대신 TMP_Text를 사용합니다.

    private Queue<string> sentences;

    void Start() {
        sentences = new Queue<string>();
    }
    
    public void StartDialogue (Dialogue dialogue){
        Debug.Log("Starting conversation with " + dialogue.name);

        sentences.Clear();
        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();

    }

    public void DisplayNextSentence(){
        if (sentences.Count == 0){
            EndDialogue();
            return;
        }
        string sentence = sentences.Dequeue();
        Debug.Log(sentence);

    }

    void EndDialogue() {
        Debug.Log("End of conversation.");
    }
    
}
