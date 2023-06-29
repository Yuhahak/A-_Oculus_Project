using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DishManager : MonoBehaviour
{
    public List<GameObject> fishList = new List<GameObject>();

    private int fishCount;

    private void Update()
    {
       
    }

    public void FishListUpdate()
    {
        if(fishCount > 0) //접시에 담긴 물고기가 1개 이상일 때
        {
            if(fishList.Count != fishCount) //물고기 리스트의 개수와 물고기 수가 다를 때
            {
                fishList.Clear();
            }
        }
    }
}
