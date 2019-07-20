using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Inventory : MonoBehaviour, IPointerDownHandler, IBeginDragHandler,
    IDragHandler, IEndDragHandler, IPointerUpHandler
{
    public Image MoveIcon;
    public List<InventorySlot> slotList = new List<InventorySlot>();
    int iWorkingSlot = -1;

    void Start()
    {
        ResourceManager.instance.LoadIcon();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        MoveIcon.gameObject.SetActive(true);
        MoveIcon.rectTransform.position = eventData.position;

        Vector2 uiPos = eventData.position;
        Debug.Log("uiPos : " + uiPos);

        for (int i = 0; i < slotList.Count; i++)
        {
            Debug.Log(slotList[i].rc);
            // 해당영역안에 point가 존재하는가

            /*if (slotList[i].rc.Contains(uiPos))
            {
                Debug.Log(i.ToString()+ "번째 슬롯을 선택");
            }*/
            //위의 방식으로 구현하고 밑에 조건문 없앨 수 있도록 해보기

            if(uiPos.x >= slotList[i].rc.x && 
               uiPos.x <= slotList[i].rc.x + slotList[i].rc.width &&
               uiPos.y <= slotList[i].rc.y && 
               uiPos.y >= slotList[i].rc.y - slotList[i].rc.height)
            {
                string sprName = slotList[i].GetIconName();
                MoveIcon.sprite = ResourceManager.instance.GetSprite(sprName);
                slotList[i].OffIcon();
                iWorkingSlot = i;
                break;
            }
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {

        Vector2 uiPos = eventData.position;
        int nTmpIndex = -1;
        for (int i = 0; i < slotList.Count; i++)
        {
            if (uiPos.x >= slotList[i].rc.x &&
               uiPos.x <= slotList[i].rc.x + slotList[i].rc.width &&
               uiPos.y <= slotList[i].rc.y &&
               uiPos.y >= slotList[i].rc.y - slotList[i].rc.height)
            {
                nTmpIndex = i;
                break;
            }

        }
        if(nTmpIndex == iWorkingSlot && nTmpIndex != -1)
        {
            slotList[iWorkingSlot].icon.gameObject.SetActive(true);
            MoveIcon.sprite = null;
            MoveIcon.gameObject.SetActive(false);
            iWorkingSlot = -1;
        }
    }
    
    public void OnBeginDrag(PointerEventData eventData)
    {
        MoveIcon.rectTransform.position = eventData.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        MoveIcon.rectTransform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Vector2 uiPos = eventData.position;
        for (int i = 0; i < slotList.Count; i++)
        {
            if (uiPos.x >= slotList[i].rc.x &&
               uiPos.x <= slotList[i].rc.x + slotList[i].rc.width &&
               uiPos.y <= slotList[i].rc.y &&
               uiPos.y >= slotList[i].rc.y - slotList[i].rc.height)
            {
                Debug.Log("내려놓는 슬롯" + i.ToString());

                if(slotList[i].icon.sprite == null)
                {
                    string strWorkSpr = slotList[iWorkingSlot].icon.sprite.name;
                    // 내려놓은 곳이 비어있음
                    slotList[i].icon.sprite =
                        ResourceManager.instance.GetSprite(strWorkSpr);

                    slotList[i].icon.gameObject.SetActive(true);

                    // 작업중인 슬롯을 비워놓는다,

                    slotList[iWorkingSlot].icon.sprite = null;
                    slotList[iWorkingSlot].icon.gameObject.SetActive(false);
                }
                else
                {
                    string strWorkSpr = slotList[iWorkingSlot].icon.sprite.name;
                    string tmpSpr = slotList[i].icon.sprite.name;
                    slotList[iWorkingSlot].icon.gameObject.SetActive(true);

                    slotList[i].icon.sprite =
                        ResourceManager.instance.GetSprite(strWorkSpr);
                    slotList[iWorkingSlot].icon.sprite =
                        ResourceManager.instance.GetSprite(tmpSpr); ;
                    slotList[i].icon.gameObject.SetActive(true);
                }

                MoveIcon.sprite = null;
                MoveIcon.gameObject.SetActive(false);
                iWorkingSlot = -1;
                return;
            }

        }

        //영역 밖에서 내려놓았을때
        //영역 안에서 작업했다면 이미 return 됐으므로 아래 코드로는 진입 불가
        slotList[iWorkingSlot].icon.gameObject.SetActive(true);
        MoveIcon.sprite = null;
        MoveIcon.gameObject.SetActive(false);
        iWorkingSlot = -1;

    }

    void Update()
    {
        
    }


}
