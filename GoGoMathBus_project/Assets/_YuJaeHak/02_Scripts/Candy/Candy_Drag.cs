using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Candy_Drag : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    public static Vector2 startPos; // 시작위치
    public float detectRange; //감지 범위
    private Vector2 oringPos; //물고기 초기화 위치

    public GameObject candy;


    public enum CandyState
    {
        None, Home, Home1, Home2
    }

    CandyState candyState = CandyState.None;

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
            switch (hits[0].transform.name)
            {
                case "Candy_Home":
                    switch (candyState)
                    {
                        case CandyState.None:
                            {
                                candy = hits[0].transform.gameObject;
                                candy.GetComponent<Candy_Detect>().AddCandy(gameObject);
                                candyState = CandyState.Home;
                                break;
                            }
                        case CandyState.Home1:
                            {
                                candy.GetComponent<Candy_Detect>().CancelCandy(gameObject);
                                candy = hits[0].transform.gameObject;
                                candy.GetComponent<Candy_Detect>().AddCandy(gameObject);
                                candyState = CandyState.Home;
                                break;
                            }
                        case CandyState.Home2:
                            {
                                candy.GetComponent<Candy_Detect>().CancelCandy(gameObject);
                                candy = hits[0].transform.gameObject;
                                candy.GetComponent<Candy_Detect>().AddCandy(gameObject);
                                candyState = CandyState.Home;
                                break;
                            }

                    }
                    break;
                case "Candy_Home_1":
                    switch (candyState)
                    {
                        case CandyState.None:
                            {
                                candy = hits[0].transform.gameObject;
                                candy.GetComponent<Candy_Detect>().AddCandy(gameObject);
                                candyState = CandyState.Home1;
                                break;
                            }
                        case CandyState.Home:
                            {
                                candy.GetComponent<Candy_Detect>().CancelCandy(gameObject);
                                candy = hits[0].transform.gameObject;
                                candy.GetComponent<Candy_Detect>().AddCandy(gameObject);
                                candyState = CandyState.Home1;
                                break;
                            }
                        case CandyState.Home2:
                            {
                                candy.GetComponent<Candy_Detect>().CancelCandy(gameObject);
                                candy = hits[0].transform.gameObject;
                                candy.GetComponent<Candy_Detect>().AddCandy(gameObject);
                                candyState = CandyState.Home1;
                                break;
                            }

                    }
                    break;
                case "Candy_Home_2":
                    switch (candyState)
                    {
                        case CandyState.None:
                            {
                                candy = hits[0].transform.gameObject;
                                candy.GetComponent<Candy_Detect>().AddCandy(gameObject);
                                candyState = CandyState.Home2;
                                break;
                            }
                        case CandyState.Home:
                            {
                                candy.GetComponent<Candy_Detect>().CancelCandy(gameObject);
                                candy = hits[0].transform.gameObject;
                                candy.GetComponent<Candy_Detect>().AddCandy(gameObject);
                                candyState = CandyState.Home2;
                                break;
                            }
                        case CandyState.Home1:
                            {
                                candy.GetComponent<Candy_Detect>().CancelCandy(gameObject);
                                candy = hits[0].transform.gameObject;
                                candy.GetComponent<Candy_Detect>().AddCandy(gameObject);
                                candyState = CandyState.Home2;
                                break;
                            }

                    }
                    break;
            }
            //Debug.Log(hits[0].transform.name);
        }
        else
        {
            switch (candyState)
            {
                case CandyState.Home:
                    {
                        candyState = CandyState.None;
                        break;
                    }
                case CandyState.Home1:
                    {
                        candyState = CandyState.None;
                        break;
                    }
                case CandyState.Home2:
                    {
                       candyState = CandyState.None;
                        break;
                    }
            }
        }


        if(candyState == CandyState.None)
        {
            GetComponent<RectTransform>().position = oringPos;
            if (candy != null)
            {
                candy.GetComponent<Candy_Detect>().CancelCandy(gameObject);
            }

        }
    }


    // 각 카운트가 3개일 때 엔딩
}
