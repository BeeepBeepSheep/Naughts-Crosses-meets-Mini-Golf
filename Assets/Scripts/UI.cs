using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public GameObject hud;
    public GameObject winScreen;
    public GameObject pauseScreen;

    public GameObject redTitle;
    public GameObject blueTitle;

    public GameObject player;

    public RectTransform scoreTracker;
    public Transform scoreFinalPos;

    void Start()
    {
        hud.SetActive(true);
        pauseScreen.SetActive(false);
        winScreen.SetActive(false);

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

        scoreTracker.SetParent(scoreFinalPos);
        scoreTracker.anchorMin = new Vector2(0, 0);
        scoreTracker.anchorMax = new Vector2(1, 1);
        scoreTracker.anchoredPosition = Vector2.zero;
        //scoreFinalPos.scale = new Vector3(.5f,.5f,.5f);
        
    }
}
