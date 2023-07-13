using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class Candy_Drag : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    public static Vector2 startPos; // ������ġ
    public float detectRange; //���� ����
    public Vector2 oringPos; //ĵ�� �ʱ�ȭ ��ġ

    public GameObject candy; // ������ �׸�

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

    //�巡�� ��
    void IDragHandler.OnDrag(PointerEventData eventData)
    {
        Vector2 currentPos = eventData.position; //���� ��ġ
        transform.position = currentPos;
    }

    //�巡�� ����
    void IEndDragHandler.OnEndDrag(PointerEventData eventData)
    {
        //����ī�޶��� ȭ�鿡�� ���콺 Ŀ���� ��ġ�� ��´�.
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

    }


    void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
    {

    }

    void IPointerUpHandler.OnPointerUp(PointerEventData eventData)
    {
        int layerMask = 1 << 6; //6�� ���̾�
        var hits = Physics.SphereCastAll(transform.position, detectRange, Vector3.up, 0, layerMask);

        if (hits.Length > 0) //���ð� �����Ǿ��� ��
        {
            Debug.Log(hits[0].transform.name);

            switch (hits[0].transform.name)  // �����Ȱ� ĵ��Ȩ�̸� ���¸� ĵ��Ȩ���� �ٲ� �ߺ�ȣ�� ����
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
            switch (candyState)  //�������� �ʾ��� ��
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


        if(candyState == CandyState.None)  // ĵ�� ���°� None�̸� ���� ��ġ, ����Ʈ���� ����
        {
            GetComponent<RectTransform>().position = oringPos;
            if (candy != null)
            {
                candy.GetComponent<Candy_Detect>().CancelCandy(gameObject);
            }

        }
    }


    public void FailGame()  //���� ����
    {
        candy.GetComponent<Candy_Detect>().ClearCandy();
        Candy_Manager.instance.ReCandy();
        Candy_Manager.instance.isOver = false;

    }


    // �� ī��Ʈ�� 3���� �� ����
}
