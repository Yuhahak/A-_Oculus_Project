using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Candy_Detect : MonoBehaviour
{
    public List<GameObject> candyList = new List<GameObject>();  //������ ĵ�� ���� ����Ʈ


    public void AddCandy(GameObject candy)  //����Ʈ�� ĵ�� �߰�
    {
        candyList.Add(candy);
    }


    public void CancelCandy(GameObject candy)  //����Ʈ���� ĵ�� ����
    {

        for (int i = 0; i < candyList.Count; i++)
        {
            if (candyList[i] == candy)
            {
                candyList.RemoveAt(i);
            }
        }

    }

    public void ClearCandy()
    {
        candyList.Clear();
    }



}
