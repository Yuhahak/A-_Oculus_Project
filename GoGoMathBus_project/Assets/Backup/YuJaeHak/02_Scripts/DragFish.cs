using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Unity.VisualScripting;

public class DragFish : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    public CasFishManager CasFishManager;
    public static Vector2 startPos; // ������ġ

    //����� ����
    public enum FishState
    {
        None, RedDish, BlueDish
    }
    public FishState fishState = FishState.None;
    public List<Image> FishSprite = new List<Image>(); //����� �̹���
    private Vector2 oringPos; //����� �ʱ�ȭ ��ġ
    public List<Transform> fishParent = new List<Transform>(); //������� �θ�

    public float detectRange; //���� ����

    public GameObject dish;
    private void Start()
    {
        oringPos = transform.localPosition; //����� ��ġ �ʱ�ȭ
    }

    private void Update()
    {
        int layerMask = 1 << 7; //7�� ���̾�
        var hits = Physics.SphereCastAll(transform.position, detectRange, Vector3.up, 0, layerMask);

        if (hits.Length > 0) //���ð� �����Ǿ��� ��
        {
            switch (hits[0].transform.name)
            {
                case "FishDetectRed":
                    switch (fishState)
                    {
                        case FishState.None:
                            {
                                dish = hits[0].transform.gameObject;
                                dish.GetComponent<FishDetect>().AddFish(gameObject);
                                fishState = FishState.RedDish;
                                break;
                            }
                        case FishState.BlueDish:
                            {
                                dish.GetComponent<FishDetect>().CancelFish(gameObject);
                                hits[0].transform.GetComponent<FishDetect>().AddFish(gameObject);
                                dish = hits[0].transform.gameObject;
                                fishState = FishState.RedDish;
                                break;
                            }
                    }
                    break;
            
                case "FishDetectBlue":
                    {
                        switch (fishState)
                        {
                            case FishState.None:
                                {
                                    dish = hits[0].transform.gameObject;
                                    dish.GetComponent<FishDetect>().AddFish(gameObject);
                                    fishState = FishState.BlueDish;
                                    break;
                                }
                            case FishState.RedDish:
                                {
                                    dish.GetComponent<FishDetect>().CancelFish(gameObject);
                                    hits[0].transform.GetComponent<FishDetect>().AddFish(gameObject);
                                    dish = hits[0].transform.gameObject;
                                    fishState = FishState.BlueDish;
                                    break;
                                }
                        }
                    }
                    break;
                default:
                    break;  
            }
        }
        //���ð� ���ڵ��� �ʾ��� ��
        else
        {
            switch (fishState)
            {
                case FishState.RedDish:
                    {
                        //dish.GetComponent<FishDetect>().CancelFish(gameObject);
                        fishState = FishState.None;
                        break;
                    }
                case FishState.BlueDish:
                    {
                        //dish.GetComponent<FishDetect>().CancelFish(gameObject);
                        fishState = FishState.None;
                        break;
                    }
            }
        }
    }

    //�巡�� ����
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
        CasFishManager.FishDragStart(gameObject);
    }

    void IPointerUpHandler.OnPointerUp(PointerEventData eventData)
    {
        //CasFishManager.FishDragEnd();
        switch (fishState)
        {
            case FishState.None:
                if (dish)
                {
                    dish.GetComponent<FishDetect>().ReduceFish(gameObject);
                    dish.GetComponent<FishDetect>().ReduceRope();
                    dish.GetComponent<FishDetect>().RopeRebuild();
                    dish = null;
                }
               // transform.parent = fishParent[0];
                FishSprite[0].enabled = true;
                FishSprite[1].enabled = false;
                FishSprite[2].enabled = false;
                break;
            case FishState.RedDish:
                CasFishManager.FishDragEnd();
                //transform.parent = fishParent[1];
                FishSprite[0].enabled = false;
                FishSprite[1].enabled = true;
                FishSprite[2].enabled = true;

                break;
            case FishState.BlueDish:
                CasFishManager.FishDragEnd();
                //transform.parent = fishParent[2];
                FishSprite[0].enabled = false;
                FishSprite[1].enabled = true;
                FishSprite[2].enabled = true;
                break;
            default:
                break;
        }
    }

    public void OnDrawGizmos()
    {
        //���̾� ���Ǿ �׸���. (�׸� ��ġ, ������)
        Gizmos.DrawWireSphere(transform.position, detectRange);
    }

    public void FishReset1()
    {
        GetComponent<RectTransform>().position = oringPos;
        //transform.parent = fishParent[0];
        FishSprite[0].enabled = true;
        FishSprite[1].enabled = false;
        FishSprite[2].enabled = false;
        dish = null;
    }
}
