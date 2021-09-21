using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float       moveSpeed   = 5f;           // 이동 속도
    [SerializeField]
    private float       jumpForce   = 3f;           // 뛰는 힘
    private float       gravity     = -9.81f;       // 중력 계수
    private Vector3     moveDir     = Vector3.zero; // 이동 방향

    [SerializeField]
    private Transform           cameraTransform;
    private CharacterController characterController;
    void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void FixedUpdate()
    {
        // 바닥에 닿지 않았을 때 (점프 중) 중력가속도에 의해 점차 빠르게 내려옴
        if(characterController.isGrounded == false)
        {
            // 중력계수를 시간에 지남에 따라 더해 떨어질 때 중력가속도 재현
            moveDir.y += gravity * Time.fixedDeltaTime;
        }

        // 방향 * 속도 * 시간 으로 움직임 제어
        characterController.Move(moveDir * moveSpeed * Time.fixedDeltaTime);
    }

    // 3차원 이동 방향 설정
    public void MoveTo(Vector3 _moveDir)
    {
        // moveDir = new Vector3(_moveDir.x, moveDir.y, _moveDir.z);
        Vector3 movedis = cameraTransform.rotation * _moveDir;
        moveDir = new Vector3(movedis.x, moveDir.y, movedis.z);
    }

    // 점프 함수
    public void JumpTo()
    {
        // 캐릭터가 바닥에 발을 딛고있고 있으면
        if (characterController.isGrounded == true)
        {
            // moveDir.y값에 jumpForce(= 3)를 대입
            moveDir.y = jumpForce;
        }
    }
}

/*
 * File : PlayerMovement.cs
 * Desc 
 *  : 플레이어 이동 스크립트
 *  
 */