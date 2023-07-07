using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static Candy_Drag;

public class Candy_Manager : MonoBehaviour
{
    public GameClearController game;


    public GameObject Stage_1;  // 스테이지
    public GameObject Stage_2;


    public Candy_Detect Home;  //캔디가 들어갈 홈
    public Candy_Detect Home1;
    public Candy_Detect Home2;

    public GameObject Nope; //틀렸을 때 이미지

    public List<GameObject> candyList = new List<GameObject>();

    public static Candy_Manager instance;

    private void Awake()
    {
        instance = this;
    }

    public bool isOver = false;  //게임오버 여부

    private void OnEnable()  // 스테이지가 켜질때마다 게임오버 false로 변경
    {
        isOver = false;
    }

    private void Update()
    {
        if (!isOver)  //게임오버가 아닐 때
        {
            if (Stage_1.activeSelf)  // Stage_1이 켜져있으면
            {
                if (Home.candyList.Count == 3 && Home1.candyList.Count == 3 && Home2.candyList.Count == 3)  // 홈1,2,3에 들어간 숫자가 모두 3일 때, 성공
                {
                    isOver = true;
                    ResultCandy();
                }
                if(Home.candyList.Count + Home1.candyList.Count + Home2.candyList.Count == 9 && !isOver)  // 실패
                {
                    StartCoroutine(NopeOn());
                    isOver = true;
                    Candy_Drag.instance.FailGame();
                }
            }
            else if (Stage_2.activeSelf)  // Stage_2
            {
                if(Home.candyList.Count == 4 && Home1.candyList.Count == 4) //성공
                {
                    isOver = true;
                    ResultCandy();
                }
                if (Home.candyList.Count + Home1.candyList.Count == 8 && !isOver)  // 실패
                {
                    StartCoroutine(NopeOn());
                    isOver = true;
                    Candy_Drag.instance.FailGame();
                }
            }

        }

    }

    void ResultCandy() // 게임엔딩
    {
        game.UpdateClearCount();
    }

    public void ReCandy()// 캔디의 위치와 상태, 리스트 초기화
    {
        for(int i =0; i < candyList.Count; i++)
        {
            candyList[i].GetComponent<RectTransform>().position = candyList[i].GetComponent<Candy_Drag>().oringPos;
            candyList[i].GetComponent<Candy_Drag>().candyState = CandyState.None;
            Home.ClearCandy();
            Home1.ClearCandy();
            Home2.ClearCandy();
        }
    }

    IEnumerator NopeOn()  //틀렸을 때 빨간화면
    {
        Nope.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        Nope.SetActive(false);
    }


}
