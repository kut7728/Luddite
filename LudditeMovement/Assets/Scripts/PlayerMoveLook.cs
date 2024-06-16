using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveLook : MonoBehaviour
{
    public CharacterController controller;
    public bool MouseDisabled = true;


    public float speed = 10f;
    public float mouseSensitivity = 2f;


    public Transform playerTransform;
    public Transform cameraTransform;

    float xRotation = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        Movement();
        CameraLook();
        SwitchDetection();
    }

    void Movement()
    {
        // Vector3 moveVector = new Vector3(0, 0, 1*speed);
        // controller.Move(moveVector); //unity caractercontroller.move 로 검색

        float keyX = Input.GetAxis("Horizontal");
        float keyZ = Input.GetAxis("Vertical");      // 화살표나 wasd 로 움직이면 값이 바뀜

        
        Vector3 move = playerTransform.right * keyX + playerTransform.forward * keyZ;
        // Debug.Log(move);
        controller.Move(move * speed * Time.deltaTime);   //deltatime은 컴퓨터의 처리속도에 맞추기 위해서 집어넣음, 한프레임 다음에 한프레임 처리 - 라는 느낌?

    }

    void CameraLook()
    {
        // float mouseX = Input.GetAxis("Mouse X");
        // float mouseY = Input.GetAxis("Mouse Y");  //유니티가 값을 string으로 저장함, 코드 이상한거 아님 ㄷㄷ;;
        // Debug.Log(mouseX + "," + mouseY);

        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        xRotation -= mouseY;  //마우스의 상하 이동은 카메라 고개의 x축 이동과 연결됨
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); //아무리 마우스를 확 움직여도 어느 정도만 시점이 바뀌도록 제한

        cameraTransform.localEulerAngles = Vector3.right * xRotation;  
        //transform은 자기자신의 정보 가져옴, 따라서 카메라에 스크립트 넣어야 함, 로컬오일러 앵글은 유니티의 rotation 값
        // vertor3.right 는 Vector3(1, 0, 0,) 과 동일

        playerTransform.Rotate(Vector3.up * mouseX);
        // vecvor3.up 은 Vector3(0, 1, 0) 과 동일
        // 마우스의 좌우 이동에 따라 본체(캡슐)의 y축 이동과 연결
    }

    void SwitchDetection()
    {
        if (Input.GetKeyDown(KeyCode.E)) {
            if (MouseDisabled) {
                Cursor.lockState = CursorLockMode.None;
                MouseDisabled = false;
            } else {
                Cursor.lockState = CursorLockMode.Locked;
                MouseDisabled = true;
            }
            
        }
    }

}
