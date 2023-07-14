using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block_Manager : MonoBehaviour
{
    public GameClearController game;
    public GameObject None;



    [Header("Stage_1")]
    public GameObject circle_Left;
    public GameObject circle_Left1;
    public GameObject circle_Right;

    [Header("Stage_2")]
    public GameObject rhombus_Left;
    public GameObject rhombus_Left1;
    public GameObject rhombus_Right;

    [Header("Stage_3")]
    public GameObject Square_Left;
    public GameObject Square_Left1;
    public GameObject Square_Right;

    private void Update()
    {
        CheckStage();
    }


    void CheckStage()
    {
        if (circle_Left.activeSelf && circle_Right.activeSelf)
        {
            circle_Left1.SetActive(true);
            circle_Left.SetActive(false);
            ResultBalloon();
        }
        else if (rhombus_Left.activeSelf && rhombus_Right.activeSelf)
        {
            rhombus_Left1.SetActive(true);
            rhombus_Left.SetActive(false);
            ResultBalloon();
        }
        else if (Square_Left.activeSelf && Square_Right.activeSelf)
        {
            Square_Left1.SetActive(true);
            Square_Left.SetActive(false);
            ResultBalloon();
        }

    }

    void ResultBalloon() // 게임엔딩
    {
        game.UpdateClearCount();

    }

}
