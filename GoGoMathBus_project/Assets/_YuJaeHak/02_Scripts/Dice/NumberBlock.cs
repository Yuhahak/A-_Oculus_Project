using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class NumberBlock : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{

    private string BlockName; //블럭 이름
    public GameClearController gameClearController;


    void IPointerClickHandler.OnPointerClick(PointerEventData eventData)  //블럭을 클릭하면
    {
        Debug.Log("블럭클릭");
        BlockName = gameObject.name; //블럭이름을 저장
        checkNum();
    }

    void checkNum() //주사위 숫자와 블럭 숫자 체크
    {

        if (BlockName == Dice_Manager.instance.Num.ToString())  //맞았을 때
        {
            Dice_Manager.instance.BasePanel.SetActive(true);
            Dice_Manager.instance.CheckHealth = true;
            gameClearController.UpdateClearCount();
        }
        else //틀렸을 때
        {
            StartCoroutine(NopeImage());
        }



    }

    //    IEnumerator HealthCount() //맞았을 때 코인하나씩 켜주기
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

    void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData) //포인터가 블럭 위로 올라왔을 때
    {
        gameObject.GetComponent<Image>().color = new Color(75 / 255f, 160 / 255f, 160 / 255f);
    }

    void IPointerExitHandler.OnPointerExit(PointerEventData eventData) //포인터가 블럭에서 나왔을 때
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
