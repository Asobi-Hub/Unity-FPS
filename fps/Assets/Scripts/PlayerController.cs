using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private KeyCode             JumpKey = KeyCode.Space;
    [SerializeField]
    private CameraController    cameraController;    
    private PlayerMovement      playerMovement;
    private void Start()
    {
        // 해당 오브젝트의 PlayerMovement 컴포넌트를 가져옴
        playerMovement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        // a d의 입력시 -1 or 1로 변환
        float x = Input.GetAxisRaw("Horizontal");
        // w s의 입력시 1 or -1로 변환
        float z = Input.GetAxisRaw("Vertical");
        
        // 움직이는 방향
        Vector3 moveDir = new Vector3(x, 0, z);

        playerMovement.MoveTo(moveDir);

        // Spacebar 입력시 점프
        if (Input.GetKeyDown(JumpKey))
        {
            playerMovement.JumpTo();
        }

        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        cameraController.RotateTo(mouseX, mouseY);
    }

}
/*
 * File : PlayerController.cs
 * 
 * Desc :
 *      플레이어의 모든 조작(컨트롤)을 담당하는 스크립트.
 *      
 */
