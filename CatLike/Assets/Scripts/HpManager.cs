using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpManager : MonoBehaviour
{

    public Text hp_text;
    public float hp = 100;

    // Update is called once per frame
    private void Update()
    {
        hp_text.text = "HP : " + ((int)hp);
        hp -=Time.deltaTime;
    }

    public void Dead()
    {
        hp--;
    }
}