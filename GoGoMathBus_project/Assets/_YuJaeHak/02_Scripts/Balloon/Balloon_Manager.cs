using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon_Manager : MonoBehaviour
{
    public GameClearController game;


    [Header("Stage_1")]
    public GameObject Kids_3_Player_1; // 플레이어
    public GameObject ok_Balloon_1; // 맞았을 때 켜줄 풍선
    public bool Stage_1_isOk = false; // 스테이지 1 클리어 여부

    [Header("Stage_2")]
    public GameObject Kids_3_Player_2; // 플레이어
    public GameObject ok_Balloon_2; // 맞았을 때 켜줄 풍선
    public bool Stage_2_isOk = false; // 스테이지 2 클리어 여부

    [Header("Stage_3")]
    public GameObject Kids_3_Player_3; // 플레이어
    public GameObject ok_Balloon_3; // 맞았을 때 켜줄 풍선
    public bool Stage_3_isOk = false; // 스테이지 3 클리어 여부


    private void Update()  
    {
        if (Stage_1_isOk)
        {
            Stage_1_Ok();
            Stage_1_isOk = false;
        }
        if (Stage_2_isOk)
        {
            Stage_2_Ok();
            Stage_2_isOk = false;
        }
        if (Stage_3_isOk)
        {
            Stage_3_Ok();
            Stage_3_isOk = false;
        }
    }

    void Stage_1_Ok()  // 클리어했을 때 호출할 함수
    {
        ok_Balloon_1.SetActive(true);
        Kids_3_Player_1.GetComponent<Animator>().SetTrigger("Ok");
        StartCoroutine(ResultBalloon());
    }

    void Stage_2_Ok()
    {
        ok_Balloon_2.SetActive(true);
        Kids_3_Player_2.GetComponent<Animator>().SetTrigger("Ok");
        StartCoroutine(ResultBalloon());
    }

    void Stage_3_Ok()
    {
        ok_Balloon_3.SetActive(true);
        Kids_3_Player_3.GetComponent<Animator>().SetTrigger("Ok");
        StartCoroutine(ResultBalloon());
    }

    IEnumerator ResultBalloon() // 게임엔딩
    {
        yield return new WaitForSeconds(2f);
        game.UpdateClearCount();

    }
}
