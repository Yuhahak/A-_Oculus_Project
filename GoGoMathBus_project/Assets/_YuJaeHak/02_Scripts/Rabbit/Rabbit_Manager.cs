using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Rabbit_Manager : MonoBehaviour
{
    public GameClearController gameClearController;
    public List<GameObject> carrotList = new List<GameObject>();
    bool Stage1_Clear = false;

    public List<GameObject> carrotList_1 = new List<GameObject>();
    bool Stage2_Clear = false;

    public List<GameObject> carrotList_2 = new List<GameObject>();
    bool Stage3_Clear = false;

    public List<GameObject> carrotList_3 = new List<GameObject>();
    bool Stage4_Clear = false;


    private void Update()
    {
        if (carrotList[0].activeSelf && carrotList[1].activeSelf && carrotList[2].activeSelf && !Stage1_Clear)
        {
            Stage1_Clear = true;
            gameClearController.UpdateClearCount();
        }

        if (carrotList_1[0].activeSelf && carrotList_1[1].activeSelf && !Stage2_Clear)
        {
            Stage2_Clear = true;
            gameClearController.UpdateClearCount();
        }

        if (carrotList_2[0].activeSelf && carrotList_2[1].activeSelf &&
            carrotList_2[2].activeSelf && carrotList_2[3].activeSelf && carrotList_2[4].activeSelf && !Stage3_Clear)
        {
            Stage3_Clear = true;
            gameClearController.UpdateClearCount();
        }

        if (carrotList_3[0].activeSelf && carrotList_3[1].activeSelf &&
            carrotList_3[2].activeSelf && !Stage4_Clear)
        {
            Stage4_Clear = true;
            gameClearController.UpdateClearCount();
        }
    }
}
