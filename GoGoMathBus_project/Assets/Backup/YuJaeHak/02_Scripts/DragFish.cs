using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Unity.VisualScripting;

public class DragFish : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    public CasFishManager CasFishManager;
    public static Vector2 startPos; // 시작위치

    //물고기 상태
    public enum FishState
    {
        None, RedDish, BlueDish
    }
    public FishState fishState = FishState.None;
    public List<Image> FishSprite = new List<Image>(); //물고기 이미지
    private Vector2 oringPos; //물고기 초기화 위치
    public List<Transform> fishParent = new List<Transform>(); //물고기의 부모

    public float detectRange; //감지 범위

    public GameObject dish;
    private void Start()
    {
        oringPos = transform.localPosition; //물고기 위치 초기화
    }

    private void Update()
    {
        int layerMask = 1 << 7; //7번 레이어
        var hits = Physics.SphereCastAll(transform.position, detectRange, Vector3.up, 0, layerMask);

        if (hits.Length > 0) //접시가 감지되었을 때
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
        //접시가 감자되지 않았을 때
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

    //드래그 시작
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
        //와이어 스피어를 그린다. (그릴 위치, 반지름)
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
