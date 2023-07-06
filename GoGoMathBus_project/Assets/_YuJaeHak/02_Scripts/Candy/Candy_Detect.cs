using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Candy_Detect : MonoBehaviour
{
    public float detectRange; //���� ����
    public List<GameObject> candyList = new List<GameObject>();

    public static Candy_Detect instance;

    public void OnDrawGizmos()
    {
        //���̾� ���Ǿ �׸���. (�׸� ��ġ, ������)
        Gizmos.DrawWireSphere(transform.position, detectRange);
    }

    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        int layerMask = 1 << 7; //7�� ���̾�
        var hits = Physics.SphereCastAll(transform.position, detectRange, Vector3.up, 0, layerMask);

        if (hits.Length > 0) //���ð� �����Ǿ��� ��
        {

        }
    }


    public void AddCandy(GameObject candy)
    {
        candyList.Add(candy);
    }


    public void CancelCandy(GameObject candy)
    {

        for (int i = 0; i < candyList.Count; i++)
        {
            if (candyList[i] == candy)
            {
                candyList.RemoveAt(i);
            }
        }

    }

}
