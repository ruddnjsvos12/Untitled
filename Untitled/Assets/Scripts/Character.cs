using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Character : MonoBehaviour
{
    NavMeshAgent _navi;

    public NavMeshAgent navi
    {
        get
        {
            if (_navi == null)
                _navi = GetComponent<NavMeshAgent>();
            return _navi;
        }
    }

    // 인스턴스가 생성될 때
    private void Awake()
    {
        InitAwake();
    }
    
    // 랜더링 되기 직전에
    void Start()
    {
        InitStart();
    }

    //게임오브젝트가 활성화
    private void OnEnable()
    {

    }

    // 게임오브젝트가 비활성화
    private void OnDisable()
    {
        
    }

    virtual public void InitAwake()
    {
        _navi = GetComponent<NavMeshAgent>();
    }

    virtual public void InitStart()
    {
        
    }


    // Update is called once per frame
    void Update()
    {

        UpdateDo();
        /*
        Vector3 origin = transform.position;
        origin.y = origin.y + 2.0f;

        //origin.x = origin.x + transform.forward.x;
        //origin.z = origin.z + transform.forward.z;

        Vector3 direction = origin;
        direction.y = -direction.y;

        RaycastHit[] floorhit = Physics.RaycastAll(origin, -Vector3.up);

        foreach (RaycastHit hits in floorhit)
        {
            if (hits.collider.tag.Contains("Stair"))
            {
                Vector3 now = transform.position;
                now.y = hits.point.y;
                transform.position = now;
                Debug.Log(transform.position);
            }

            Debug.DrawLine(origin, direction, Color.red);
        }

        //월드 좌표계로 바꿔주는 함수 transform.TransformPoint();
        //다시 로컬 좌표계로 바꿔주려면 앞에 Inverse 붙이기

        /*
        Vector3 origin = new Vector3(transform.position.x, transform.position.y+1.5f, transform.position.z);
        Vector3 direction = Vector3.down;
        if (Physics.Raycast(origin, direction))
        {
            Debug.DrawLine(origin, direction, Color.red);
        }
        */
    }

    virtual public void UpdateDo()
    {
        /*
        if (transform.position != vEnd)
        {
            transform.position = Vector3.MoveTowards(transform.position, vEnd, fSpeed * Time.deltaTime);

            
            Quaternion targetRotation = Quaternion.LookRotation(vDir);
            transform.rotation = Quaternion.RotateTowards(transform.rotation,
                                                          targetRotation,
                                                          180.0f * Time.deltaTime);
            
        }
        float step = 10f * Time.deltaTime;
        Vector3 newDir =
            Vector3.RotateTowards(transform.forward, vDir.normalized, step, 0.0f);
        transform.rotation = Quaternion.LookRotation(newDir);
        
        // Debug.DrawLine(transform.position, vEnd, Color.blue);
        */
    }
}
