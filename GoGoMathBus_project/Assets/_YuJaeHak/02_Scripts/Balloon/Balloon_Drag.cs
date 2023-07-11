using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Balloon_Drag : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    public Balloon_Manager balloon_;

    public static Vector2 startPos; // ������ġ
    public float detectRange; //���� ����
    public Vector2 oringPos; //�ʱ�ȭ ��ġ


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

        if (hits.Length > 0) //�׸��� �����Ǿ��� ��
        {
            switch (hits[0].transform.name)
            {
                case "Balloon_Frame":  // Stage_1
                    if (gameObject.name == "Balloon_Brown") //��� �ִ� ��ü�� �̸��� �´ٸ�
                    {
                        gameObject.SetActive(false);  //��� �ִ°� ����
                        balloon_.Stage_1_isOk = true;  // Ŭ���� true
                    }
                    else //�ʱ�ȭ
                    {
                        GetComponent<RectTransform>().position = oringPos;
                    }

                    break;
                case "Balloon_Frame_1":  // Stage_2
                    if (gameObject.name == "Balloon_Pink") //��� �ִ� ��ü�� �̸��� �´ٸ�
                    {
                        gameObject.SetActive(false);  //��� �ִ°� ����
                        balloon_.Stage_2_isOk = true;  // Ŭ���� true
                    }
                    else //�ʱ�ȭ
                    {
                        GetComponent<RectTransform>().position = oringPos;
                    }
                    break;
                case "Balloon_Frame_2":  // Stage_2
                    if (gameObject.name == "Balloon_Yellow") //��� �ִ� ��ü�� �̸��� �´ٸ�
                    {
                        gameObject.SetActive(false);  //��� �ִ°� ����
                        balloon_.Stage_3_isOk = true;  // Ŭ���� true
                    }
                    else //�ʱ�ȭ
                    {
                        GetComponent<RectTransform>().position = oringPos;
                    }
                    break;
            }
        }
        else //�������� ������ �ʱ�ȭ
        {
            GetComponent<RectTransform>().position = oringPos;
        }

    }
}
