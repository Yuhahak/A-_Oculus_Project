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

    public static Vector2 startPos; // ������ġ
    private Vector2 originPos; // ó�� ��ġ 
    public float detectRange; //���� ����

    private bool CoinSet;
    public GameObject CoinHome;
    private string DiceName;

    private bool CheckDice = true;

    public void OnDrawGizmos()
    {
        //���̾� ���Ǿ �׸���. (�׸� ��ġ, ������)
        Gizmos.DrawWireSphere(transform.position, detectRange);
    }

    // Start is called before the first frame update
    void Start()
    {
        originPos = GetComponent<RectTransform>().position; //����� ��ġ �ʱ�ȭ

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

        switch (coinState) // ������ ���� ��ġ��
        {
            case CoinState.None:
                GetComponent<RectTransform>().position = originPos;
                break;
            case CoinState.SetCoin:
                GetComponent<RectTransform>().position = originPos;
                coinState = CoinState.None;
                break;
        }

            if (hits.Length > 0) //�����Ȱ� ������
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

