using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Balloon_Drag : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    public Balloon_Manager balloon_;

    public static Vector2 startPos; // 시작위치
    public float detectRange; //감지 범위
    public Vector2 oringPos; //초기화 위치


    private void Start()
    {
        oringPos = GetComponent<RectTransform>().position;
    }

    private void Update()
    {

    }

    void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)
    {
        startPos = eventData.position;
        gameObject.transform.SetAsLastSibling();
    }

    //드래그 중
    void IDragHandler.OnDrag(PointerEventData eventData)
    {
        Vector2 currentPos = eventData.position; //현재 위치
        transform.position = currentPos;
    }

    //드래그 종료
    void IEndDragHandler.OnEndDrag(PointerEventData eventData)
    {
        //메인카메라의 화면에서 마우스 커서의 위치를 담는다.
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

    }

    void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
    {

    }


    void IPointerUpHandler.OnPointerUp(PointerEventData eventData)
    {
        int layerMask = 1 << 6; //6번 레이어
        var hits = Physics.SphereCastAll(transform.position, detectRange, Vector3.up, 0, layerMask);

        if (hits.Length > 0) //그릇이 감지되었을 때
        {
            switch (hits[0].transform.name)
            {
                case "Balloon_Frame":  // Stage_1
                    if (gameObject.name == "Balloon_Brown") //들고 있는 물체의 이름이 맞다면
                    {
                        gameObject.SetActive(false);  //들고 있는건 끄고
                        balloon_.Stage_1_isOk = true;  // 클리어 true
                    }
                    else //초기화
                    {
                        GetComponent<RectTransform>().position = oringPos;
                    }

                    break;
                case "Balloon_Frame_1":  // Stage_2
                    if (gameObject.name == "Balloon_Pink") //들고 있는 물체의 이름이 맞다면
                    {
                        gameObject.SetActive(false);  //들고 있는건 끄고
                        balloon_.Stage_2_isOk = true;  // 클리어 true
                    }
                    else //초기화
                    {
                        GetComponent<RectTransform>().position = oringPos;
                    }
                    break;
                case "Balloon_Frame_2":  // Stage_2
                    if (gameObject.name == "Balloon_Yellow") //들고 있는 물체의 이름이 맞다면
                    {
                        gameObject.SetActive(false);  //들고 있는건 끄고
                        balloon_.Stage_3_isOk = true;  // 클리어 true
                    }
                    else //초기화
                    {
                        GetComponent<RectTransform>().position = oringPos;
                    }
                    break;
            }
        }
        else //감지되지 않으면 초기화
        {
            GetComponent<RectTransform>().position = oringPos;
        }

    }
}
