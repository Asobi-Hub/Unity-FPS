using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float       moveSpeed   = 5f;           // �̵� �ӵ�
    [SerializeField]
    private float       jumpForce   = 3f;           // �ٴ� ��
    private float       gravity     = -9.81f;       // �߷� ���
    private Vector3     moveDir     = Vector3.zero; // �̵� ����

    [SerializeField]
    private Transform           cameraTransform;
    private CharacterController characterController;
    void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void FixedUpdate()
    {
        // �ٴڿ� ���� �ʾ��� �� (���� ��) �߷°��ӵ��� ���� ���� ������ ������
        if(characterController.isGrounded == false)
        {
            // �߷°���� �ð��� ������ ���� ���� ������ �� �߷°��ӵ� ����
            moveDir.y += gravity * Time.fixedDeltaTime;
        }

        // ���� * �ӵ� * �ð� ���� ������ ����
        characterController.Move(moveDir * moveSpeed * Time.fixedDeltaTime);
    }

    // 3���� �̵� ���� ����
    public void MoveTo(Vector3 _moveDir)
    {
        // moveDir = new Vector3(_moveDir.x, moveDir.y, _moveDir.z);
        Vector3 movedis = cameraTransform.rotation * _moveDir;
        moveDir = new Vector3(movedis.x, moveDir.y, movedis.z);
    }

    // ���� �Լ�
    public void JumpTo()
    {
        // ĳ���Ͱ� �ٴڿ� ���� ����ְ� ������
        if (characterController.isGrounded == true)
        {
            // moveDir.y���� jumpForce(= 3)�� ����
            moveDir.y = jumpForce;
        }
    }
}

/*
 * File : PlayerMovement.cs
 * Desc 
 *  : �÷��̾� �̵� ��ũ��Ʈ
 *  
 */