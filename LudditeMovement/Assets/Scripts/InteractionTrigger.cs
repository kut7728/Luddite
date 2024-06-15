using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // TextMeshPro 네임스페이스 추가

public class InteractionTrigger : MonoBehaviour
{
    public TMP_Text interactionText; // 상호작용 메시지를 출력할 TextMeshPro 텍스트
    public GameObject player; // 플레이어 오브젝트
    public float interactionDistance = 3f; // 상호작용 가능 거리
    public MonoBehaviour scriptToActivate; // 스페이스바를 눌렀을 때 활성화할 스크립트

    private bool isPlayerInRange = false; // 플레이어가 범위 내에 있는지 여부

    void Start()
    {
        // 초기에는 메시지 숨기기
        interactionText.gameObject.SetActive(false);
    }

    void Update()
    {
        // 플레이어와의 거리 계산
        float distance = Vector3.Distance(player.transform.position, transform.position);

        if (distance <= interactionDistance)
        {
            isPlayerInRange = true;
            interactionText.gameObject.SetActive(true);
            interactionText.text = "스페이스바를 눌러 상호작용";

            // 스페이스바를 눌렀을 때 스크립트 활성화
            if (Input.GetKeyDown(KeyCode.Space) && scriptToActivate is IActivatable activatable)
            {
                activatable.Activate();
            }
        }
        else
        {
            isPlayerInRange = false;
            interactionText.gameObject.SetActive(false);
        }
    }
}



