using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinLogic : MonoBehaviour
{
    public float redCount = 0f;
    public float blueCount = 0f;
    public  float countAllowence = 1;

    public LayerMask m_LayerMask;



    void FixedUpdate()
    {
        MyCollisions();
        //    if (redCount == 3f)
        //    {
        //        Debug.Log("Red Wins");
        //    }
        //    if (blueCount == 3f)
        //    {
        //        Debug.Log("Blue Wins");
        //    }
    }
    void MyCollisions()
    {
        Collider[] hitColliders = Physics.OverlapBox(gameObject.transform.position, transform.localScale / 2, Quaternion.identity, m_LayerMask);
        int i = 0;
       
        while (i < hitColliders.Length)
        {
            if (hitColliders[i].tag != "DetectionLine")
            {
                if (countAllowence <= 1f && countAllowence > 0f)
                {
                    if (hitColliders[i].tag == "BlueCaptured")
                    {
                        blueCount++;
                        countAllowence--;
                        Debug.Log("bluecount is " + blueCount);
                    }
                    if (hitColliders[i].tag == "RedCaptured")
                    {
                        redCount++;
                        countAllowence--;
                        Debug.Log("redcount is " + redCount);
                    }
                }
            }
            i++;
        }
    }
}


