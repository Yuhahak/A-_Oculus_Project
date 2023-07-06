using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dice_Manager : MonoBehaviour
{
    public static Dice_Manager instance;
    public GameObject Nope; //틀렸을 때 이미지
    public GameObject BasePanel; //주사위를 포함한 모든 클릭 제한


    [Header("Check")]
    public bool CheckHealth = false; //정답여부
    public int Num; //난수
    public bool isOver = false; //게임오버여부

    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            if (instance == this)
            {
                Destroy(gameObject);
            }
        }
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
