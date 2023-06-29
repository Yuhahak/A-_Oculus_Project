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

    public static Vector2 startPos; // ������ġ
    public float detectRange; //���� ����

    public GameObject CoinSet;

    public void OnDrawGizmos()
    {
        //���̾� ���Ǿ �׸���. (�׸� ��ġ, ������)
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
        transform.localScale = new Vector3(1f, 1f, 1f);
    }

    void IPointerUpHandler.OnPointerUp(PointerEventData eventData)
    {
        int layerMask = 1 << 6; //6�� ���̾�
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
