using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CoinManager : MonoBehaviour
{
    public Text Coin_text;

    public int coin = 0;

    private void Update()
    {
        Coin_text.text = "Coin : " + coin;
    }

    public void Add_coin()
    {
        coin++;
    }
}
