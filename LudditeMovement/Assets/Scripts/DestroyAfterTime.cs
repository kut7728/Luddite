using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterTime : MonoBehaviour
{
    public float delay = 5f; // 삭제까지의 시간 (초)
    public GameObject target; // 삭제할 대상 GameObject

    void Start()
    {
        if (target == null)
        {
            target = gameObject; // 타겟이 설정되지 않은 경우, 이 스크립트가 붙은 GameObject를 타겟으로 설정
        }
        Destroy(target, delay); // 지정된 시간이 지나면 타겟 GameObject를 삭제
    }
}

