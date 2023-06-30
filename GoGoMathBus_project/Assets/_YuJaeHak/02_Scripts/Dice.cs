using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Dice : MonoBehaviour, IPointerClickHandler
{
    public static Dice instance;

    private Animator anim;
    public GameObject Dice_Anim; //주사위 애니메이션 참조
    public GameObject BasePanel; //주사위를 포함한 모든 클릭 제한
    public GameObject HealthPanel; //주사위를 제외한 모든 클릭 제한
    public GameObject EndingPanel; //엔딩씬
    public GameObject Nope; //틀렸을 때 이미지



    [Header("Check")]
    [HideInInspector] public bool CheckHealth = false; //정답여부
    [HideInInspector] public int Health = 0; //코인 카운트
    [HideInInspector] public int Num; //난수
    private bool isOver = false; //게임오버여부

    [Header("Dice")]
    public List<GameObject> Dice_ = new List<GameObject>(); //나올 수 있는 주사위배열
    public List<GameObject> Health_ = new List<GameObject>(); //코인배열

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
        if (CheckHealth) // 블럭을 눌러 정답을 맞췄을 때
        {
            HealthPanel.gameObject.SetActive(true); //패널을 켜서 주사위를 제외한 클릭 제한
        }
        else
        {
            HealthPanel.gameObject.SetActive(false);
        }

        if(Health == 3) //코인 3개를 다 모으면 엔딩
        {
            isOver = true;

            if(isOver == true)
            {
                StartCoroutine(Ending());
            }
        }
    }

    void IPointerClickHandler.OnPointerClick(PointerEventData eventData) //주사위를 클릭했을 때
    {
        StartDice();
        Invoke("StopDice", 2.5f);
    }

    void StartDice()
    {
        for (int i = 0; i < 6; i++) // 켜져있는 주사위를 다 끄고 애니메이션 출력
        {
            Dice_[i].transform.gameObject.SetActive(false);
        }
        Dice_Anim.gameObject.SetActive(true);
        Dice_Anim.GetComponent<Animator>().SetBool("DiceOn", true);
        BasePanel.gameObject.SetActive(true);
        CheckHealth = false;
    }

    void StopDice()  // 난수를 뽑아 배열에 있는 주사위를 출력
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


    IEnumerator Ending() //엔딩씬
    {
        yield return new WaitForSeconds(4f);
        EndingPanel.gameObject.SetActive(true);
        isOver = false;
    }
}
