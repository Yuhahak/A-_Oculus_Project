using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Dice : MonoBehaviour, IPointerClickHandler
{
    public static Dice instance;

    private Animator anim;
    public GameObject Dice_Anim;
    public GameObject BasePanel;
    public GameObject HealthPanel;
    public GameObject EndingPanel;


    [Header("Check")]
    [HideInInspector] public bool CheckHealth = false;
    [HideInInspector] public int Health = 0;
    [HideInInspector] public int Num;

    [Header("Dice")]
    public List<GameObject> Dice_ = new List<GameObject>();
    public List<GameObject> Health_ = new List<GameObject>();

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

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        Health = 0;
        Num = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (CheckHealth)
        {
            HealthPanel.gameObject.SetActive(true);
        }
        else
        {
            HealthPanel.gameObject.SetActive(false);
        }

        if(Health == 3)
        {
            Ending();
        }
    }

    void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
    {
        StartDice();
        Invoke("StopDice", 2.5f);
    }

    void StartDice()
    {
        for (int i = 0; i < 6; i++)
        {
            Dice_[i].transform.gameObject.SetActive(false);
        }
        Dice_Anim.gameObject.SetActive(true);
        Dice_Anim.GetComponent<Animator>().SetBool("DiceOn", true);
        BasePanel.gameObject.SetActive(true);
        CheckHealth = false;
    }

    void StopDice()
    { 
        Dice_Anim.GetComponent<Animator>().SetBool("DiceOn", false);
        Dice_Anim.gameObject.SetActive(false);
        BasePanel.gameObject.SetActive(false);
        int RandomNum = Random.Range(1, 7);
        Num = RandomNum;
        switch (Num)
        {
            case 1:
                Dice_[0].transform.gameObject.SetActive(true);
                break;
            case 2:
                Dice_[1].transform.gameObject.SetActive(true);
                break;
            case 3:
                Dice_[2].transform.gameObject.SetActive(true);
                break;
            case 4:
                Dice_[3].transform.gameObject.SetActive(true);
                break;
            case 5:
                Dice_[4].transform.gameObject.SetActive(true);
                break;
            case 6:
                Dice_[5].transform.gameObject.SetActive(true);
                break;
        }
    }


    void Ending()
    {
        EndingPanel.gameObject.SetActive(true);
    }
}
