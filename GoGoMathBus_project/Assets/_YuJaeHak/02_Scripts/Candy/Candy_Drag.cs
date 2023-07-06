using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Candy_Drag : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    public static Vector2 startPos; // ������ġ
    public float detectRange; //���� ����

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

    }

    void IPointerUpHandler.OnPointerUp(PointerEventData eventData)
    {
        int layerMask = 1 << 6; //7�� ���̾�
        var hits = Physics.SphereCastAll(transform.position, detectRange, Vector3.up, 0, layerMask);

        if (hits.Length > 0) //���ð� �����Ǿ��� ��
        {
            Debug.Log(hits[0].transform.name);
        }
    }

    //������Ʈ�� �ڱ� �̸����� �ٲ��ֱ�
    //������ ������ ����Ʈ�� �߰�
    // �� ī��Ʈ�� 3���� �� ����
}
