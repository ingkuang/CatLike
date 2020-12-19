using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterDisplay : MonoBehaviour
{
    public int character=1;
    public GameObject selected_character;
    public CharacterSelect character_select;

    void Start()
    {
        character_select = GameObject.Find("GameSystem").GetComponent<CharacterSelect>();
        switch (character)
        {
            case 1:
                GameObject.Find("characters").transform.Find("SamSek").gameObject.SetActive(true);
                selected_character = GameObject.Find("SamSek");
                break;
        }
        character_select.character_num = character;

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
