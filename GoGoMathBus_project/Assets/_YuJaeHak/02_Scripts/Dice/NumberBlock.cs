using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class NumberBlock : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{

    private string BlockName; //�� �̸�
    public GameClearController gameClearController;


    void IPointerClickHandler.OnPointerClick(PointerEventData eventData)  //���� Ŭ���ϸ�
    {
        Debug.Log("��Ŭ��");
        BlockName = gameObject.name; //���̸��� ����
        checkNum();
    }

    void checkNum() //�ֻ��� ���ڿ� �� ���� üũ
    {

        if (BlockName == Dice_Manager.instance.Num.ToString())  //�¾��� ��
        {
            Dice_Manager.instance.BasePanel.SetActive(true);
            Dice_Manager.instance.CheckHealth = true;
            gameClearController.UpdateClearCount();
        }
        else //Ʋ���� ��
        {
            StartCoroutine(NopeImage());
        }



    }

    //    IEnumerator HealthCount() //�¾��� �� �����ϳ��� ���ֱ�
    //{
    //    switch (Dice.instance.Health)
    //    {
    //        case 1:
    //            Dice.instance.Health_[0].GetComponent<Animator>().SetTrigger("Coin");
    //            break;
    //        case 2:
    //            Dice.instance.Health_[1].GetComponent<Animator>().SetTrigger("Coin");
    //            break;
    //        case 3:
    //            Dice.instance.Health_[2].GetComponent<Animator>().SetTrigger("Coin");
    //            break;
    //    }

    //    yield return new WaitForSeconds(0.01f);
    //}

    void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData) //�����Ͱ� �� ���� �ö���� ��
    {
        gameObject.GetComponent<Image>().color = new Color(75 / 255f, 160 / 255f, 160 / 255f);
    }

    void IPointerExitHandler.OnPointerExit(PointerEventData eventData) //�����Ͱ� ������ ������ ��
    {
        gameObject.GetComponent<Image>().color = new Color(255 / 255f, 255 / 255f, 255 / 255f);
    }

    IEnumerator NopeImage()
    {
        Dice_Manager.instance.Nope.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.25f);
        Dice_Manager.instance.Nope.gameObject.SetActive(false);
    }

}
