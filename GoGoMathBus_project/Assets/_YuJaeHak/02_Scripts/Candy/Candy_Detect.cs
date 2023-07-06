using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Candy_Detect : MonoBehaviour, IPointerUpHandler
{
    public float detectRange; //���� ����

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
        int layerMask = 1 << 7; //7�� ���̾�
        var hits = Physics.SphereCastAll(transform.position, detectRange, Vector3.up, 0, layerMask);

        if (hits.Length > 0) //���ð� �����Ǿ��� ��
        {
            Debug.Log(hits[0].transform.name);
        }
    }

    void IPointerUpHandler.OnPointerUp(PointerEventData eventData)
    {

    }


}
