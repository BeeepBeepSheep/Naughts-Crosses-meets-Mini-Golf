using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinLogicNew : MonoBehaviour
{
    private bool gameIsWon = false;
    public GameObject myObjective1;
    public GameObject myObjective2;
    public GameObject myObjective3;

    void Start()
    {
        gameIsWon = false;
    }
    void FixedUpdate()
    {
        if (myObjective1.tag == "BlueCaptured" && myObjective2.tag == "BlueCaptured" && myObjective3.tag == "BlueCaptured")
        {
            Debug.Log("Blue Wins");
        }
        if (myObjective1.tag == "RedCaptured" && myObjective2.tag == "RedCaptured" && myObjective3.tag == "RedCaptured")
        {
            Debug.Log("Red Wins");
        }
    }
}
