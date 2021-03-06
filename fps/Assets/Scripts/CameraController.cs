using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    private float rotateSpeedX  = 3f;       // 좌/우 회전 속도
    private float rotateSpeedY  = 5f;       // 상/하 회전 속도
    private float limitMinX     = -80;      // 내려다 볼 수 있는 한계 각도
    private float limitMaxX     = 50;       // 올려다 볼 수 있는 한계 각도
    private float eulerAngleX;
    private float eulerAngleY;
    
     // 마우스를 좌/우로 움직이는 mouseX 값을 y축에 대입하는 이유: 카메라의 좌우로 회전하면 Y축이 변화함
     // 마우스를 상/하로 움직이는 mouseY 값을 x축에 대입하는 이유: 카메라가 상하로 회전하면 X축이 변화함
     // 단 X축은 위로 회전시 -(음수), 아래로 회전 시 +(양수)가 되기 때문에 -=를 사용해서 반전시킨다.
    public void RotateTo(float mouseX, float mouseY)
    {
        // 좌우 회전
        eulerAngleY += mouseX * rotateSpeedX;
        // 상하 회전
        eulerAngleX -= mouseY * rotateSpeedY;

        // 카메라의 상하 회전각을 -80(min) <= eulerAngleX <= 50(max) 으로 제한한다.
        // Mathf.Clamp(float value, float min, float max);
        eulerAngleX = Mathf.Clamp(eulerAngleX, limitMinX, limitMaxX);

        // 카메라의 rotation값에 쿼터니언으로 대입
        transform.rotation = Quaternion.Euler(eulerAngleX, eulerAngleY, 0);
    }
}

/*
 * File : CameraController.cs
 * Desc
 *  : 플레이어 카메라 컨트롤 스크립트
 */