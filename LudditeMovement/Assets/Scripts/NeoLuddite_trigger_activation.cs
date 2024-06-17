using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NeoLuddite_trigger_activation : MonoBehaviour
{
    // 오브젝트 태그와 이미지 매핑을 위한 딕셔너리
    private Dictionary<string, Image> objectImageMap;

    // 오브젝트 태그와 이미지 페어를 설정할 수 있는 공개 변수
    [System.Serializable]
    public struct ObjectImagePair
    {
        public string objectTag;
        public Image imageToShow;
    }

    public ObjectImagePair[] objectImagePairs; // 오브젝트와 이미지 페어 배열

    void Start()
    {
        // 딕셔너리 초기화
        objectImageMap = new Dictionary<string, Image>();

        // 배열을 순회하며 딕셔너리에 매핑
        foreach (var pair in objectImagePairs)
        {
            if (pair.imageToShow != null)
            {
                pair.imageToShow.gameObject.SetActive(false); // 이미지 초기 비활성화
                objectImageMap[pair.objectTag] = pair.imageToShow;
            }
        }
    }

    void Update()
    {
        // 마우스 왼쪽 버튼 클릭 감지
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                // 클릭된 오브젝트의 태그 확인
                if (objectImageMap.ContainsKey(hit.collider.tag))
                {
                    // 해당 태그의 이미지의 활성화 상태를 토글
                    Image image = objectImageMap[hit.collider.tag];
                    image.gameObject.SetActive(!image.gameObject.activeSelf);
                }
            }
        }
    }
}
