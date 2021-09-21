using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinLogicNew : MonoBehaviour
{
    private bool gameIsWon = false;
    public GameObject player;
    public GameObject canvas;
    public GameObject myObjective1;
    public GameObject myObjective2;
    public GameObject myObjective3;

    void Start()
    {
        gameIsWon = false;
    }
    void FixedUpdate()
    {
        WinLogic();
        AfterWin();

    }

    void WinLogic()
    {
        if (myObjective1.tag == "BlueCaptured" && myObjective2.tag == "BlueCaptured" && myObjective3.tag == "BlueCaptured")
        {
            //Debug.Log("Blue Wins");
            gameIsWon = true;
            canvas.GetComponent<UI>().BlueWin();
        }
        if (myObjective1.tag == "RedCaptured" && myObjective2.tag == "RedCaptured" && myObjective3.tag == "RedCaptured")
        {
            //Debug.Log("Red Wins");
            gameIsWon = true;
            canvas.GetComponent<UI>().RedWin();
        }
    }
    void AfterWin()
    {
        if (gameIsWon)
        {
            player.GetComponent<Player> ().canShoot = false;
        }
    }
}
