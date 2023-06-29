using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CasFishManager : MonoBehaviour
{
    public enum CatFishState
    {
        Stanby, Play, Result
    }

    public CatFishState catFishState = CatFishState.Stanby;

    public List<GameObject> fishList = new List<GameObject>();

    private int totalFishCount = 6; //전체 물고기의 갯수
    [SerializeField]
    private int redFishCount; //빨간접시에 필요한 물고기 갯수
    [SerializeField]
    private int blueFishCount; //파란접시에 필요한 물고기 갯수

    public FishDetect redDish;
    public FishDetect BlueDish;

    public Text redFishCountText;
    public Text blueFishCountText;
    public Text resultText;

    private int timeNumber;
    public Text StartText;

    public Text numberText_3;
    public Text numberText_2;
    public Text numberText_1;

    // Start is called before the first frame update
    void Start()
    {
        RandomFishCount();
        Time.timeScale = 0.0f;
        catFishState = CatFishState.Stanby;
    }

    // Update is called once per frame
    void Update()
    {

        switch (catFishState)
        {
            case CatFishState.Play:
                {
                    
                    break;

                }
        }

        Timer();




    }

    void Timer()
    {
        if (timeNumber < 961)
        {
            timeNumber++;
            if(timeNumber > 0)
            {
                numberText_3.gameObject.SetActive(true);
            }
            if(timeNumber > 240)
            {
                numberText_3.gameObject.SetActive(false);
                numberText_2.gameObject.SetActive(true);
            }
            if (timeNumber > 480)
            {
                numberText_2.gameObject.SetActive(false);
                numberText_1.gameObject.SetActive(true);
            }
            if (timeNumber > 720)
            {
                numberText_1.gameObject.SetActive(false);
                StartText.gameObject.SetActive(true);
                Time.timeScale = 1.0f;
            }
            if (timeNumber > 960)
            {
                StartText.gameObject.SetActive(false);
                Time.timeScale = 1.0f;
            }
        }
    }

    //물고기 결과
    void FishResult()
    {
        resultText.gameObject.SetActive(true);
        //빨간접시 물고기 수와 빨간접시 수가 같고, 파란접시 물고기 수와 파란접시 수가 같을 때
        if(redDish.fishCount == redFishCount && BlueDish.fishCount == blueFishCount)
        {
            resultText.text = "성공!";
        }

        //실패
        else
        {
            resultText.text = "실패!";


        }
        StartCoroutine(FishReset());
    }

    //게임 초기화
    IEnumerator FishReset()
    {
        yield return new WaitForSeconds(3.0f);
        RandomFishCount();
        for(int i =0; i < fishList.Count; i++)
        {
            fishList[i].SendMessage("FishReset1");
        }
        resultText.text = "";
        resultText.gameObject.SetActive(false);
        catFishState = CatFishState.Play;
    }
    void RandomFishCount()
    {
        //빨간접시에 필요한 물고기의 개수를 무작위로 지정
        redFishCount = Random.Range(1, totalFishCount);
        blueFishCount = totalFishCount - redFishCount;

        redFishCountText.text = redFishCount.ToString();
        blueFishCountText.text = blueFishCount.ToString();
    }

    //물고기를 드래그 시작할 때 선택한 물고기만 움직이게 하는 함수
    public void FishDragStart(GameObject fish)
    {
        //for(int i = 0; i < fishList.Count; i++)
        //{
        //    fishList[i].GetComponent<Image>().enabled = false;
        //}
    }

    public void FishDragEnd()
    {
        //for(int i=0; i < fishList.Count; i++)
        //{
        //    fishList[i].GetComponent<Image>().enabled = true;
        //}

        redDish.FishInDish();
        BlueDish.FishInDish();
        if (redDish.fishCount + BlueDish.fishCount == totalFishCount)
        {
            FishResult();
            catFishState = CatFishState.Result;
        }
        
    }

}
