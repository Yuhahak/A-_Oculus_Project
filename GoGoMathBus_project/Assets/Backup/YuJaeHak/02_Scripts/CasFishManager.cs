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

    private int totalFishCount = 6; //��ü ������� ����
    [SerializeField]
    private int redFishCount; //�������ÿ� �ʿ��� ����� ����
    [SerializeField]
    private int blueFishCount; //�Ķ����ÿ� �ʿ��� ����� ����

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

    //����� ���
    void FishResult()
    {
        resultText.gameObject.SetActive(true);
        //�������� ����� ���� �������� ���� ����, �Ķ����� ����� ���� �Ķ����� ���� ���� ��
        if(redDish.fishCount == redFishCount && BlueDish.fishCount == blueFishCount)
        {
            resultText.text = "����!";
        }

        //����
        else
        {
            resultText.text = "����!";


        }
        StartCoroutine(FishReset());
    }

    //���� �ʱ�ȭ
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
        //�������ÿ� �ʿ��� ������� ������ �������� ����
        redFishCount = Random.Range(1, totalFishCount);
        blueFishCount = totalFishCount - redFishCount;

        redFishCountText.text = redFishCount.ToString();
        blueFishCountText.text = blueFishCount.ToString();
    }

    //����⸦ �巡�� ������ �� ������ ����⸸ �����̰� �ϴ� �Լ�
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
