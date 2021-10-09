using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour
{
    public GameObject hud;
    public GameObject winScreen;

    public GameObject redTitle;
    public GameObject blueTitle;

    public GameObject player;

    void Start()
    {
        hud.SetActive(true);
    }
    public void RedWin()
    {
        UniversalWinScreen();
        redTitle.SetActive(true);
    }
    public void BlueWin()
    {
        UniversalWinScreen();
        blueTitle.SetActive(true);
    }
    public void UniversalWinScreen()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        hud.SetActive(false);
        winScreen.SetActive(true);

        Time.timeScale = 0f;
        player.GetComponent<Player>().enabled = false;
    }
}
