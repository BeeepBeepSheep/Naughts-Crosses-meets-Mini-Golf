using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinLogic : MonoBehaviour
{
    private float redCount = 0f;
    private float blueCount = 0f;


    void Update()
    {
        if(redCount == 3f)
        {
            Debug.Log("Red Wins");
        }
        if (blueCount == 3f)
        {
            Debug.Log("Blue Wins");
        }
    }
    //need detection;
}
