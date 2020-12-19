using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public bool 메뉴 = false;
    public GameObject Panel;

    public void 일시정지()
    {
        Time.timeScale = 0.0f;
        메뉴 = (!메뉴);
        Panel.SetActive(메뉴);
    }

    public void 계속하기()
    {
        Time.timeScale = 1.0f;
        메뉴 = (!메뉴);
        Panel.SetActive(메뉴);

    }

    public void 메인화면으로()
    {
        SceneManager.LoadScene(1);
    }
}
