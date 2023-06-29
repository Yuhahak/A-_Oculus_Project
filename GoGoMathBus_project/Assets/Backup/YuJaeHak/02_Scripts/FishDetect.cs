using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro.EditorUtilities;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public class FishDetect : MonoBehaviour
{
    public float detectRange; //감지범위

    public int fishCount;
    public List<GameObject> fishList = new List<GameObject>();

    public GameObject ropePrefab;
    public List<GameObject> ropeList = new List<GameObject>();

    private bool ropeSign;
    //기즈모를 그리는 함수
    public void OnDrawGizmos()
    {  
        //와이어 스피어를 그린다. (그릴 위치, 반지름)
        Gizmos.DrawWireSphere(transform.position, detectRange);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //int layerMask = 1 << 6; //6번 레이어
        ////스피어캐스트를 그린다.(그릴위치, 크기, 방향, 길이, 레이어마스크)
        //var hits = Physics.SphereCastAll(transform.position, detectRange, Vector3.up, 0, layerMask);

        //if (fishList.Contains(null))
        //{
        //    fishList.Clear();
        //}

        //fishCount = hits.Length;
        //if(fishList.Count < hits.Length)
        //{
        //    for(int i = 0; i < hits.Length; i++)
        //    {
        //        if (!fishList.Contains(hits[i].transform.gameObject))
        //        {
        //            fishList.Add(hits[i].transform.gameObject);
        //        }
        //    }
        //}

        //if(fishList.Count != hits.Length)
        //{
        //    fishList.Clear();
        //    ReduceRope();
        //    for(int i = 0; i < hits.Length; i++)
        //    {
        //        fishList.Add(hits[i].transform.gameObject);
        //    }
        //}

    }

    public void FishInDish()
    {
        int layerMask = 1 << 6; //6번 레이어
        //스피어캐스트를 그린다.(그릴위치, 크기, 방향, 길이, 레이어마스크)
        var hits = Physics.SphereCastAll(transform.position, detectRange, Vector3.up, 0, layerMask);

        if(ropeList.Count < fishList.Count - 1)
        {
            CreateRope(fishList.Count - 2, fishList.Count - 1);
        }
        else if(ropeList.Count > fishList.Count - 1)
        {
            ReduceRope();
        }
    }

    public void CreateRope(int a, int b)
    {
        if(ropeList.Count == 0)
        {
            GameObject rope = Instantiate(ropePrefab);
            rope.transform.name = "Rope" + a.ToString() + "_" + b.ToString();
            rope.GetComponent<Rope>().lines.Add(fishList[a].GetComponent<DragFish>().FishSprite[2].transform);
            rope.GetComponent<Rope>().lines.Add(fishList[b].GetComponent<DragFish>().FishSprite[2].transform);
            ropeList.Add(rope);
        }
        else
        {
            for(int i=0; i < ropeList.Count; i++)
            {
                if (ropeList[i].transform.name != "Rope" + a.ToString() + "_" + b.ToString())
                {
                    if (ropeSign)
                    {
                        GameObject rope = Instantiate(ropePrefab);
                        rope.transform.name = "Rope" + a.ToString() + "_" + b.ToString();
                        rope.GetComponent<Rope>().lines.Add(fishList[a].GetComponent<DragFish>().FishSprite[2].transform);
                        rope.GetComponent<Rope>().lines.Add(fishList[b].GetComponent<DragFish>().FishSprite[2].transform);
                        ropeList.Add(rope);
                        StartCoroutine(ropeSignReset());
                        ropeSign = false;
                    }
                }
            }
        }
    }

    public void ReduceRope()
    {
        for(int i =0; i < ropeList.Count; i++)
        {
            Destroy(ropeList[i]);
        }
        ropeList.Clear();
    }

    IEnumerator ropeSignReset()
    {
        yield return new WaitForSeconds(0.2f);
        ropeSign = true;
    }

    public void AddFish(GameObject fish)
    {
        fishList.Add(fish);
    }

    public void ReduceFish(GameObject fish)
    {
        ReduceRope();
        for(int i = 0; i <fishList.Count; i++)
        {
            if (fishList[i] == fish)
            {
                fishList.RemoveAt(i);
            }
        }
    }

    public void CancelFish(GameObject fish)
    {
        for(int i = 0; i< fishList.Count; i++)
        {
            if (fishList[i] == fish)
            {
                fishList.RemoveAt(i);
            }
        }
    }

    public void FishReset()
    {
        fishList.Clear();
    }

    public void RopeRebuild()
    {
        StartCoroutine(RopeRebuildStart());
    }

    IEnumerator RopeRebuildStart()
    {
        yield return new WaitForSeconds(0.2f);

        for(int i = 0; i < fishList.Count-1; i++)
        {
            GameObject rope = Instantiate(ropePrefab);
            rope.transform.name = "Rope" + i.ToString() + "_" + (i + 1).ToString();
            rope.GetComponent<Rope>().lines.Add(fishList[i].GetComponent<DragFish>().FishSprite[2].transform);
            rope.GetComponent<Rope>().lines.Add(fishList[i + 1].GetComponent<DragFish>().FishSprite[2].transform);
            ropeList.Add(rope);
        }
    }

 
}
