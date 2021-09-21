using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    private float rotateSpeedX  = 3f;
    private float rotateSpeedY  = 5f;
    private float limitMinX     = -80;
    private float limitMaxX     = 50;
    private float eulerAngleX;
    private float eulerAngleY;
    
     // ���콺�� ��/��� �����̴� mouseX ���� y�࿡ �����ϴ� ����: ī�޶��� �¿�� ȸ���ϸ� Y���� ��ȭ��
     // ���콺�� ��/�Ϸ� �����̴� mouseY ���� x�࿡ �����ϴ� ����: ī�޶� ���Ϸ� ȸ���ϸ� X���� ��ȭ��
     // �� X���� ���� ȸ���� -(����), �Ʒ��� ȸ�� �� +(���)�� �Ǳ� ������ -=�� ����ؼ� ������Ų��.
    public void RotateTo(float mouseX, float mouseY)
    {
        // �¿� ȸ��
        eulerAngleY += mouseX * rotateSpeedX;
        // ���� ȸ��
        eulerAngleX -= mouseY * rotateSpeedY;

        // ī�޶��� ���� ȸ������ -80(min) <= eulerAngleX <= 50(max) ���� �����Ѵ�.
        // Mathf.Clamp(float value, float min, float max);
        eulerAngleX = Mathf.Clamp(eulerAngleX, limitMinX, limitMaxX);

        transform.rotation = Quaternion.Euler(eulerAngleX, eulerAngleY, 0);
    }
}
