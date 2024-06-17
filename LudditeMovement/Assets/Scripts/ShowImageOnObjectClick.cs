using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShowImageTextMeshProAndDeleteObject : MonoBehaviour
{
    public Image imageToShow; // 보여줄 이미지
    public TextMeshProUGUI textMeshProToShow; // 보여줄 TextMeshProUGUI
    public GameObject objectToDelete; // 삭제할 오브젝트

    void Start()
    {
        // 시작 시 이미지와 TextMeshPro를 비활성화
        if (imageToShow != null)
        {
            imageToShow.gameObject.SetActive(false);
        }
        if (textMeshProToShow != null)
        {
            textMeshProToShow.gameObject.SetActive(false);
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // 마우스 왼쪽 버튼 클릭
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider != null && hit.collider.gameObject == gameObject) // 이 스크립트가 붙어 있는 오브젝트를 클릭했을 때
                {
                    // 이미지와 TextMeshPro를 동시에 활성화
                    if (imageToShow != null)
                    {
                        imageToShow.gameObject.SetActive(true);
                    }
                    if (textMeshProToShow != null)
                    {
                        textMeshProToShow.gameObject.SetActive(true);
                    }

                    // 다른 오브젝트를 삭제
                    if (objectToDelete != null)
                    {
                        Destroy(objectToDelete);
                    }
                }
            }
        }
    }
}
