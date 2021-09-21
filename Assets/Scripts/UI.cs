using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour
{
    public GameObject redScreen;
    public GameObject blueScreen;
    public GameObject hud;

    void Start()
    {
        redScreen.SetActive(false);
        blueScreen.SetActive(false);
        hud.SetActive(true);
    }
    public void RedWin()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        redScreen.SetActive(true);
        hud.SetActive(false);
    }
    public void BlueWin()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        blueScreen.SetActive(true);
        hud.SetActive(false);
    }
}
