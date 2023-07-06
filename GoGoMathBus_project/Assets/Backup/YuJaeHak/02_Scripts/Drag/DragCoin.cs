using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
    private Vector2 originPos; // 처음 위치 
    public float detectRange; //감지 범위

    private bool CoinSet;
    public GameObject CoinHome;
    private string DiceName;

    private bool CheckDice = true;

    public void OnDrawGizmos()
    {
        //와이어 스피어를 그린다. (그릴 위치, 반지름)
        Gizmos.DrawWireSphere(transform.position, detectRange);
    }

    // Start is called before the first frame update
    void Start()
    {
        originPos = GetComponent<RectTransform>().position; //물고기 위치 초기화

    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(CC());
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

        switch (coinState) // 놨을때 원래 위치로
        {
            case CoinState.None:
                GetComponent<RectTransform>().position = originPos;
                break;
            case CoinState.SetCoin:
                GetComponent<RectTransform>().position = originPos;
                coinState = CoinState.None;
                break;
        }

            if (hits.Length > 0) //감지된게 있으면
            {

            switch (hits[0].transform.name)
                {
                    case "CoinHome":
                        {
                            switch (coinState)
                            {
                                case CoinState.None:
                                    transform.position = new Vector3(CoinHome.transform.position.x, CoinHome.transform.position.y, transform.position.z);
                                    transform.localScale = new Vector3(CoinHome.transform.localScale.x, CoinHome.transform.localScale.y, CoinHome.transform.localScale.z);
                                    coinState = CoinState.SetCoin;
                                    CoinManager.instance.coinBaseState = CoinManager.CoinBaseState.KeepCoin;
                                    DiceName = gameObject.name;
                                    break;

                                case CoinState.SetCoin:
                                    break;
                            }
                            break;

                        }
                }
            }
        }

    IEnumerator CC()
    {
        for (int i = 0; i < 6; i++)
        {
            if(CoinManager.instance.Coin[i].transform.localScale != new Vector3(1f, 1f, 1f))
            {
                
            }
        }
        yield return new WaitForSeconds(0.1f);
    }

}

