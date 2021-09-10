using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ControlPoint : MonoBehaviour
{
    public TextMeshProUGUI speedDial;
    public TextMeshProUGUI powerDial;

    float xRotation = 0f;
    public Rigidbody currantBall;
    public Rigidbody blueBall;
    public Rigidbody redBall;

    public float rotationSpeed = 5f;

    public float minShotPower = 5f;
    public float maxShotPower = 30f;
    public float currantShotPower = 30f;
    void Start()
    {
        currantBall = blueBall;
    }

    void Update()
    {
        transform.position = currantBall.position;

        speedDial.SetText(currantBall.velocity.magnitude.ToString());
        powerDial.SetText(currantShotPower.ToString());

        xRotation += Input.GetAxis("Mouse X") * rotationSpeed;
        transform.rotation = Quaternion.Euler(transform.rotation.y, xRotation, 0f);
        if(Input.GetMouseButton(0))
        {
            currantShotPower = maxShotPower;
        }

        if (Input.GetMouseButtonUp(0))
        {
            currantBall.velocity = transform.forward * (currantShotPower);
            currantShotPower = 0f;
            if(currantBall == blueBall)
            {
                currantBall = redBall;
            }
            else
            {
                currantBall = blueBall;

            }
        }
    }
}
