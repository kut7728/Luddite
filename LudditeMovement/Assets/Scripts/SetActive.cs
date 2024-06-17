using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetActive : MonoBehaviour
{
    public GameObject Target;

    // 버튼 클릭 시 호출될 함수
    public void ToggleTarget()
    {
        Target.SetActive(!Target.activeSelf); // Target GameObject의 활성화 상태를 토글함
    }

    // 마우스 우클릭 시 호출될 함수
    void Update()
    {
        if (Input.GetMouseButtonDown(1)) // 마우스 오른쪽 버튼을 클릭했을 때
        {
            Target.SetActive(false); // Target GameObject를 비활성화함
        }
    }
}