using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Rect rc;
    RectTransform tr;

    public Image icon;

    private void Awake()
    {
        tr = GetComponent<RectTransform>();
        // 자신의 영역정보를 구성
        // RectTransform rect정보가 포함되어 있으나
        // 영역정보를 좌상단과 우하단, 일괄적으로 다시 구성

        rc.x = tr.position.x - tr.rect.width / 2;
        rc.y = tr.position.y + tr.rect.height /2;
        rc.width = tr.rect.width;
        rc.height = tr.rect.height;

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public string GetIconName()
    {
        return icon.sprite.name;
    }

    public void OffIcon()
    {
        icon.gameObject.SetActive(false);
    }

    public void OnIcon()
    {
        icon.gameObject.SetActive(true);
    }

    void Update()
    {
        
    }
}
