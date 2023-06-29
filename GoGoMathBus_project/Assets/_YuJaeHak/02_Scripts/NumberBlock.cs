using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class NumberBlock : MonoBehaviour, IPointerClickHandler
{

    private string BlockName;
    private bool CanBlock;


    // Start is called before the first frame update
    void Start()
    {
   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
    {
        
        BlockName = gameObject.name;
        checkNum();
    }

    void checkNum()
    {
        if (BlockName == Dice.instance.Num.ToString())
        {
            ToastManager.Instance.showMessage("¡§¥‰!", 1f);
            Dice.instance.Health += 1;
            Dice.instance.CheckHealth = true;
            StartCoroutine(HealthCount());
        }
        else
        {
            ToastManager.Instance.showMessage("∂Ø!", 1f);
        }

        if(Dice.instance.Num == 0)
        {
            ToastManager.Instance.showMessage("¡÷ªÁ¿ß ±º∑¡!", 1f);

        }


    }

        IEnumerator HealthCount()
    {
        switch (Dice.instance.Health)
        {
            case 1:
                Dice.instance.Health_[0].gameObject.SetActive(true);
                break;
            case 2:
                Dice.instance.Health_[1].gameObject.SetActive(true);
                break;
            case 3:
                Dice.instance.Health_[2].gameObject.SetActive(true);
                break;
        }

        yield return new WaitForSeconds(0.1f);
    }
}
