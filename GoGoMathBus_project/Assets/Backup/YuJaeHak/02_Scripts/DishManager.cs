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
        if(fishCount > 0) //���ÿ� ��� ����Ⱑ 1�� �̻��� ��
        {
            if(fishList.Count != fishCount) //����� ����Ʈ�� ������ ����� ���� �ٸ� ��
            {
                fishList.Clear();
            }
        }
    }
}
