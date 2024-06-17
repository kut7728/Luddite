using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShowTextOnCollision : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro; // 출력할 TextMeshProUGUI
    public string displayText = "충돌했습니다!"; // 표시할 텍스트

    void Start()
    {
        // 시작 시 TextMeshProUGUI를 비활성화
        if (textMeshPro != null)
        {
            textMeshPro.gameObject.SetActive(false);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // 다른 오브젝트와 충돌했을 때
        if (other.CompareTag("Player")) // 예를 들어 "Player" 태그를 가진 오브젝트와 충돌할 때만 작동하도록 설정
        {
            // TextMeshProUGUI를 활성화하고 텍스트 설정
            if (textMeshPro != null)
            {
                textMeshPro.text = displayText;
                textMeshPro.gameObject.SetActive(true);
            }
        }
    }
}

