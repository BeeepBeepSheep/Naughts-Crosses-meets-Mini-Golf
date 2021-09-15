using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxCapture : MonoBehaviour
{

    public Material redMat;
    public Material blueMat;
    private Material potentialColor;

    public Transform redBall;
    public Transform blueBall;
    private Vector3 stopVelocity;
    public Transform spawnPoint;

    private string blueTag = "BlueCaptured";
    private string redTag = "RedCaptured";

    void OnTriggerEnter(Collider collision)
    {
        stopVelocity = new Vector3(0, 0, 0);
        if (collision.transform == redBall)
        {
            potentialColor = redMat;
            redBall.GetComponent<Rigidbody>().velocity = stopVelocity;
            redBall.GetComponent<Rigidbody>().useGravity = false;
            redBall.position = spawnPoint.position;

            GetComponent<BoxCollider>().isTrigger = false;
            gameObject.tag = redTag;
        }
        if (collision.transform == blueBall)
        {
            potentialColor = blueMat;
            blueBall.GetComponent<Rigidbody>().velocity = stopVelocity;
            blueBall.GetComponent<Rigidbody>().useGravity = false;
            blueBall.position = spawnPoint.position;

            GetComponent<BoxCollider>().isTrigger = false;
            gameObject.tag = blueTag;
        }
        GetComponent<MeshRenderer>().material = potentialColor;
        Debug.Log(gameObject.tag);
    }
}
