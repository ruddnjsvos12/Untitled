using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    Vector3 vEnd = Vector3.zero;
    Vector3 vDir = Vector3.zero;
    Vector3 origin = Vector3.zero;
    float fSpeed = 2.0f;

    public override void InitAwake()
    {
        base.InitAwake();
    }

    public override void InitStart()
    {
        base.InitStart();
    }
    /*
    public bool MousePick()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100))
        {
            if (!hit.collider.tag.Contains("Terrain"))
                return false;

            Debug.Log(hit.collider.name);

            // 마우스 클릭한 지점
            vEnd = hit.point;

            // 방향 벡터 (회전 또는 기타 각도계산에 사용)
            vDir = vEnd - transform.position;

            return true;
        }
        return false;
    }

    */


    public override void UpdateDo()
    {
        base.UpdateDo();

        if (Input.GetMouseButton(0))
        {
            if (Utility.MousePick(ref vEnd))
            {
                navi.destination = vEnd;
            }
        }
    }
}
