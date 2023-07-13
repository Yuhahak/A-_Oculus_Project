using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class Candy_Drag : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    public static Vector2 startPos; // 시작위치
    public float detectRange; //감지 범위
    public Vector2 oringPos; //캔디 초기화 위치

    public GameObject candy; // 감지된 그릇

    public static Candy_Drag instance;


    private void Awake()
    {
        instance = this;
    }

    public enum CandyState
    {
        None, Home, Home1, Home2, Home3
    }

    public CandyState candyState = CandyState.None;

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
            Debug.Log(hits[0].transform.name);

            switch (hits[0].transform.name)  // 감지된게 캔디홈이면 상태를 캔디홈으로 바꿔 중복호출 방지
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
                        case CandyState.Home3:
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
                        case CandyState.Home3:
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
                        case CandyState.Home3:
                            {
                                candy.GetComponent<Candy_Detect>().CancelCandy(gameObject);
                                candy = hits[0].transform.gameObject;
                                candy.GetComponent<Candy_Detect>().AddCandy(gameObject);
                                candyState = CandyState.Home2;
                                break;
                            }

                    }
                    break;
                case "Candy_Home_3":
                    switch (candyState)
                    {
                        case CandyState.None:
                            {
                                candy = hits[0].transform.gameObject;
                                candy.GetComponent<Candy_Detect>().AddCandy(gameObject);
                                candyState = CandyState.Home3;
                                break;
                            }
                        case CandyState.Home:
                            {
                                candy.GetComponent<Candy_Detect>().CancelCandy(gameObject);
                                candy = hits[0].transform.gameObject;
                                candy.GetComponent<Candy_Detect>().AddCandy(gameObject);
                                candyState = CandyState.Home3;
                                break;
                            }
                        case CandyState.Home1:
                            {
                                candy.GetComponent<Candy_Detect>().CancelCandy(gameObject);
                                candy = hits[0].transform.gameObject;
                                candy.GetComponent<Candy_Detect>().AddCandy(gameObject);
                                candyState = CandyState.Home3;
                                break;
                            }
                        case CandyState.Home2:
                            {
                                candy.GetComponent<Candy_Detect>().CancelCandy(gameObject);
                                candy = hits[0].transform.gameObject;
                                candy.GetComponent<Candy_Detect>().AddCandy(gameObject);
                                candyState = CandyState.Home3;
                                break;
                            }

                    }
                    break;
            }
            //Debug.Log(hits[0].transform.name);
        }
        else
        {
            switch (candyState)  //감지되지 않았을 때
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
                case CandyState.Home3:
                    {
                        candyState = CandyState.None;
                        break;
                    }
            }
        }


        if(candyState == CandyState.None)  // 캔디 상태가 None이면 원래 위치, 리스트에서 빼기
        {
            GetComponent<RectTransform>().position = oringPos;
            if (candy != null)
            {
                candy.GetComponent<Candy_Detect>().CancelCandy(gameObject);
            }

        }
    }


    public void FailGame()  //게임 실패
    {
        candy.GetComponent<Candy_Detect>().ClearCandy();
        Candy_Manager.instance.ReCandy();
        Candy_Manager.instance.isOver = false;

    }


    // 각 카운트가 3개일 때 엔딩
}
