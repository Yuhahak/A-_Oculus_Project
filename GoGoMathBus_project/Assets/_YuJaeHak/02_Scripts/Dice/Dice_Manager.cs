using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dice_Manager : MonoBehaviour
{
    public static Dice_Manager instance;
    public GameObject Nope; //Ʋ���� �� �̹���
    public GameObject BasePanel; //�ֻ����� ������ ��� Ŭ�� ����


    [Header("Check")]
    public bool CheckHealth = false; //���俩��
    public int Num; //����
    public bool isOver = false; //���ӿ�������

    
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
