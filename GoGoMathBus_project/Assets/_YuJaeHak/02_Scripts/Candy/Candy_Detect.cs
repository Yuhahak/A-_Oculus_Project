using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Candy_Detect : MonoBehaviour
{
    public List<GameObject> candyList = new List<GameObject>();  //감지된 캔디를 담을 리스트


    public void AddCandy(GameObject candy)  //리스트에 캔디를 추가
    {
        candyList.Add(candy);
    }


    public void CancelCandy(GameObject candy)  //리스트에서 캔디를 삭제
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
