using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    public Transform chaTr;
    
    Vector3 oldCha;
    Vector3 oldChaAngle;
    float fAngularSpeed = 10f;
    const float fWheelSpeed = 20f;
    const float fZoomMin = 26;
    const float fZoomMax = 100;

    void Start()
    {
        oldCha = chaTr.position;
        
    }
    
    void Update()
    {


    }

    private void LateUpdate()
    {
        // 위치 업데이트
        Vector3 delta = chaTr.position - oldCha;
        Vector3 newCamPos = transform.position + delta;
        transform.position = newCamPos;

        oldCha = chaTr.position;

        // 회전 업데이트

        Vector3 deltaAngle = chaTr.eulerAngles - oldChaAngle;
        Vector3 newAngle = transform.eulerAngles + deltaAngle;


        if (deltaAngle.sqrMagnitude > 0.01)
        {
            /*
            transform.RotateAround(chaTr.transform.position,
                Vector3.up, Time.deltaTime * fAngularSpeed);

            transform.RotateAround(chaTr.transform.position,
                Vector3.up, Time.deltaTime * fAngularSpeed);

            */
        }

        oldChaAngle = chaTr.eulerAngles;

        float fWheel = Input.GetAxis("Mouse ScrollWheel");
        if (fWheel != 0) //back
        {
            float cur = Camera.main.fieldOfView;
            cur += fWheel * fWheelSpeed;
            Camera.main.fieldOfView = Mathf.Clamp(cur, fZoomMin, fZoomMax); // min에서 max 까지의 값만 허용
        }
    }
}
