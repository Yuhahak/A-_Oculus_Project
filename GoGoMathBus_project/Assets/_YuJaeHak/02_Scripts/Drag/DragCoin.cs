using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragCoin : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler, IPointerDownHandler, IPointerUpHandler
{

    public enum CoinState
    {
        None, SetCoin
    }

    public CoinState coinState = CoinState.None;

    public static Vector2 startPos; // 시작위치
    public float detectRange; //감지 범위

    public GameObject CoinSet;

    public void OnDrawGizmos()
    {
        //와이어 스피어를 그린다. (그릴 위치, 반지름)
        Gizmos.DrawWireSphere(transform.position, detectRange);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
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
        transform.localScale = new Vector3(1f, 1f, 1f);
    }

    void IPointerUpHandler.OnPointerUp(PointerEventData eventData)
    {
        int layerMask = 1 << 6; //6번 레이어
        var hits = Physics.SphereCastAll(transform.position, detectRange, Vector3.up, 0, layerMask);

        if (hits.Length > 0)
        {

            switch (hits[0].transform.name)
            {
                case "CoinHome":
                    switch (coinState)
                    {
                        case CoinState.None:
                            transform.position = new Vector3(CoinSet.transform.position.x, CoinSet.transform.position.y, transform.position.z);
                            transform.localScale = new Vector3(CoinSet.transform.localScale.x, CoinSet.transform.localScale.y, CoinSet.transform.localScale.z);
                            break;

                        case CoinState.SetCoin:
                            break;
                    }
                    break;


            }
        }
    }
}
