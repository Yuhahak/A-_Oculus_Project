using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon_Manager : MonoBehaviour
{
    public GameClearController game;


    [Header("Stage_1")]
    public GameObject Kids_3_Player_1; // �÷��̾�
    public GameObject ok_Balloon_1; // �¾��� �� ���� ǳ��
    public bool Stage_1_isOk = false; // �������� 1 Ŭ���� ����

    [Header("Stage_2")]
    public GameObject Kids_3_Player_2; // �÷��̾�
    public GameObject ok_Balloon_2; // �¾��� �� ���� ǳ��
    public bool Stage_2_isOk = false; // �������� 2 Ŭ���� ����

    [Header("Stage_3")]
    public GameObject Kids_3_Player_3; // �÷��̾�
    public GameObject ok_Balloon_3; // �¾��� �� ���� ǳ��
    public bool Stage_3_isOk = false; // �������� 3 Ŭ���� ����


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

    void Stage_1_Ok()  // Ŭ�������� �� ȣ���� �Լ�
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

    IEnumerator ResultBalloon() // ���ӿ���
    {
        yield return new WaitForSeconds(2f);
        game.UpdateClearCount();

    }
}
