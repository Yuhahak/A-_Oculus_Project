using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Block_Drag : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    public Block_Manager block_;

    public static Vector2 startPos; // 시작위치
    public float detectRange; //감지 범위
    public Vector2 oringPos; //캔디 초기화 위치

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

        if (hits.Length > 0) //접시가 감지되었을 때
        {
            switch (hits[0].transform.name)
            {
                case "Frame_Left":
                    if(gameObject.name == "Circle_1")
                    {
                        gameObject.SetActive(false);
                        block_.circle_Left.SetActive(true);
                    }
                    else if(gameObject.name == "Rhombus_3")
                    {
                        gameObject.SetActive(false);
                        block_.rhombus_Left.SetActive(true);
                    }
                    else if (gameObject.name == "Square_1")
                    {
                        gameObject.SetActive(false);
                        block_.Square_Left.SetActive(true);
                    }
                    else
                    {
                        StartCoroutine(Nope());
                        GetComponent<RectTransform>().position = oringPos;
                    }
                    break;
                case "Frame_Right":
                    if (gameObject.name == "Circle_3")
                    {
                        gameObject.SetActive(false);
                        block_.circle_Right.SetActive(true);
                    }
                    else if(gameObject.name == "Rhombus_1")
                    {
                        gameObject.SetActive(false);
                        block_.rhombus_Right.SetActive(true);
                    }
                    else if (gameObject.name == "Square_2")
                    {
                        gameObject.SetActive(false);
                        block_.Square_Right.SetActive(true);
                    }
                    else
                    {
                        StartCoroutine(Nope());
                        GetComponent<RectTransform>().position = oringPos;
                    }
                    break;
            }
        }

        else
        {
            GetComponent<RectTransform>().position = oringPos;
        }
    }



    IEnumerator Nope()
    {
        block_.None.SetActive(true);
        yield return new WaitForSeconds(0.25f);
        block_.None.SetActive(false);
    }
}
