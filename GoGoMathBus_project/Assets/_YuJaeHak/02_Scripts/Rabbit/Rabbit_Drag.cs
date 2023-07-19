using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class Rabbit_Drag : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    public Rabbit_Manager rabbit;

    public static Vector2 startPos; // 시작위치
    public float detectRange; //감지 범위
    public Vector2 oringPos; //캔디 초기화 위치

    public GameObject carrotPrefab; // 당근 프리팹

    private int i = 0;
    private int i_1 = 0;
    private int i_2 = 0;
    private int i_3 = 0;

    // Start is called before the first frame update
    void Start()
    {
        oringPos = GetComponent<RectTransform>().position;


    }

    // Update is called once per frame
    void Update()
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
                case "Carrot_Ans":
                    GetComponent<RectTransform>().position = oringPos;
                    rabbit.carrotList[i].SetActive(true);
                    i++;
                    break;
                case "Carrot_Ans_1":
                    GetComponent<RectTransform>().position = oringPos;
                    rabbit.carrotList_1[i_1].SetActive(true);
                    i_1++;
                    break;
                case "Carrot_Ans_2":
                    GetComponent<RectTransform>().position = oringPos;
                    rabbit.carrotList_2[i_2].SetActive(true);
                    i_2++;
                    break;
                case "Carrot_Ans_3":
                    GetComponent<RectTransform>().position = oringPos;
                    rabbit.carrotList_3[i_3].SetActive(true);
                    i_3++;
                    break;
            }
        }
        else
        {
            GetComponent<RectTransform>().position = oringPos;
        }
    }
}
