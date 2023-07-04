using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    public static CoinManager instance;
    public List<GameObject> Coin = new List<GameObject>();

    public enum CoinBaseState
    {
        None, KeepCoin
    }

    public CoinBaseState coinBaseState = CoinBaseState.None;

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        StartCoroutine(CoinBaseCheck());
    }

    IEnumerator CoinBaseCheck()
    {
            switch (coinBaseState)
            {
                case CoinBaseState.None:
                    {
                        gameObject.GetComponent<SphereCollider>().enabled = true;
                        break;
                    }
                case CoinBaseState.KeepCoin:
                    {
                        gameObject.GetComponent<SphereCollider>().enabled = false;
                        break;
                    }
            }
            yield return new WaitForSeconds(0.1f);
    }
}
