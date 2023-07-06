using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Candy_Detect : MonoBehaviour
{
    public float detectRange; //감지 범위
    public List<GameObject> candyList = new List<GameObject>();

    public static Candy_Detect instance;

    public void OnDrawGizmos()
    {
        //와이어 스피어를 그린다. (그릴 위치, 반지름)
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
        int layerMask = 1 << 7; //7번 레이어
        var hits = Physics.SphereCastAll(transform.position, detectRange, Vector3.up, 0, layerMask);

        if (hits.Length > 0) //접시가 감지되었을 때
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
