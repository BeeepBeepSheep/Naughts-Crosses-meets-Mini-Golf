using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour
{
    public Transform cam;
    public Transform camPosFar;
    public Transform camPosClose;

    void Update()
    {
        transform.position = camPosFar.position;
    }
    void OnTriggerEnter(Collider collision)
    {
        MoveClose();
    }
    void OnTriggerExit(Collider exit)
    {
        MoveFar();
    }
    void MoveClose()
    {
        cam.position = camPosClose.position;
        cam.rotation = camPosClose.rotation;
    }
    void MoveFar()
    {
        cam.position = camPosFar.position;
        cam.rotation = camPosFar.rotation;
    }
}
