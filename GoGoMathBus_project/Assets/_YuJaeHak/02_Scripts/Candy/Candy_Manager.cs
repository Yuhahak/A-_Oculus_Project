using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static Candy_Drag;

public class Candy_Manager : MonoBehaviour
{
    public GameClearController game;


    public GameObject Stage_1;  // ��������
    public GameObject Stage_2;


    public Candy_Detect Home;  //ĵ�� �� Ȩ
    public Candy_Detect Home1;
    public Candy_Detect Home2;

    public GameObject Nope; //Ʋ���� �� �̹���

    public List<GameObject> candyList = new List<GameObject>();

    public static Candy_Manager instance;

    private void Awake()
    {
        instance = this;
    }

    public bool isOver = false;  //���ӿ��� ����

    private void OnEnable()  // ���������� ���������� ���ӿ��� false�� ����
    {
        isOver = false;
    }

    private void Update()
    {
        if (!isOver)  //���ӿ����� �ƴ� ��
        {
            if (Stage_1.activeSelf)  // Stage_1�� ����������
            {
                if (Home.candyList.Count == 3 && Home1.candyList.Count == 3 && Home2.candyList.Count == 3)  // Ȩ1,2,3�� �� ���ڰ� ��� 3�� ��, ����
                {
                    isOver = true;
                    ResultCandy();
                }
                if(Home.candyList.Count + Home1.candyList.Count + Home2.candyList.Count == 9 && !isOver)  // ����
                {
                    StartCoroutine(NopeOn());
                    isOver = true;
                    Candy_Drag.instance.FailGame();
                }
            }
            else if (Stage_2.activeSelf)  // Stage_2
            {
                if(Home.candyList.Count == 4 && Home1.candyList.Count == 4) //����
                {
                    isOver = true;
                    ResultCandy();
                }
                if (Home.candyList.Count + Home1.candyList.Count == 8 && !isOver)  // ����
                {
                    StartCoroutine(NopeOn());
                    isOver = true;
                    Candy_Drag.instance.FailGame();
                }
            }

        }

    }

    void ResultCandy() // ���ӿ���
    {
        game.UpdateClearCount();
    }

    public void ReCandy()// ĵ���� ��ġ�� ����, ����Ʈ �ʱ�ȭ
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

    IEnumerator NopeOn()  //Ʋ���� �� ����ȭ��
    {
        Nope.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        Nope.SetActive(false);
    }


}
