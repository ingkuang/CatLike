using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Summon : MonoBehaviour
{   
    public int character;
    public CharacterSelect character_select_num;
    public GameObject SamSek;

    void Awake()
    {
        character_select_num = GameObject.Find("GameSystem").GetComponent<CharacterSelect>();
        character = character_select_num.character_num;
        switch (character)
        {
            case 1:
                Instantiate(SamSek,new Vector3(0,0,0),Quaternion.identity);
                break;
        }


    }
}
