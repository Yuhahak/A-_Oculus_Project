using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Candy_Manager : MonoBehaviour
{
    public Candy_Detect Home;
    public Candy_Detect Home1;
    public Candy_Detect Home2;

    private void Update()
    {
        StartCoroutine(ResultCandy());
    }

    IEnumerator ResultCandy()
    {
        if(Home.candyList.Count ==3 && Home1.candyList.Count == 3 && Home2.candyList.Count == 3)
        {
            Debug.Log("1");
        }

        yield return new WaitForSeconds(0.1f);
    }
}
