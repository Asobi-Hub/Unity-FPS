using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private KeyCode             JumpKey = KeyCode.Space;        // ���� Ű
    [SerializeField]
    private CameraController    cameraController;
    private PlayerMovement      playerMovement;
    private void Start()
    {
        // �ش� ������Ʈ�� PlayerMovement ������Ʈ�� ������
        playerMovement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        // a d�� �Է½� -1 or 1�� ��ȯ
        float x = Input.GetAxisRaw("Horizontal");
        // w s�� �Է½� 1 or -1�� ��ȯ
        float z = Input.GetAxisRaw("Vertical");
        
        // �����̴� ����
        Vector3 moveDir = new Vector3(x, 0, z);

        playerMovement.MoveTo(moveDir);

        // Spacebar �Է½� ����
        if (Input.GetKeyDown(JumpKey))
        {
            playerMovement.JumpTo();
        }

        // ���콺 x y�� �Է�
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        cameraController.RotateTo(mouseX, mouseY);
    }

}
/*
 * File : PlayerController.cs
 * 
 * Desc
 *  : �÷��̾��� ��� ����(��Ʈ��)�� ����ϴ� ��ũ��Ʈ.
 *      
 */
