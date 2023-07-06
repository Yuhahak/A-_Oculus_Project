using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Candy_Drag : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    public static Vector2 startPos; // 시작위치
    public float detectRange; //감지 범위

    void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)
    {
        startPos = eventData.position;
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
        int layerMask = 1 << 6; //7번 레이어
        var hits = Physics.SphereCastAll(transform.position, detectRange, Vector3.up, 0, layerMask);

        if (hits.Length > 0) //접시가 감지되었을 때
        {
            Debug.Log(hits[0].transform.name);
        }
    }

    //스테이트를 자기 이름으로 바꿔주기
    //닿으면 각자의 리스트에 추가
    // 각 카운트가 3개일 때 엔딩
}
