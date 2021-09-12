using System.Collections;using System.Collections.Generic;using UnityEngine;using UnityEngine.UI;using TMPro;public class Player : MonoBehaviour{    public TextMeshProUGUI speedDial;    public TextMeshProUGUI powerDial;    public Slider powerSlider;    float xRotation = 0f;    public Rigidbody currantBall;    public Rigidbody blueBall;    public Rigidbody redBall;    private bool canSwitch = false;    private Vector3 stopVelocity;    public float rotationSpeed = 5f;    public float maxShotPower = 100f;    public float currantShotPower = 0f;    private bool canShoot = true;    void Awake()    {        Cursor.lockState = CursorLockMode.Locked;        Cursor.visible = false;
        currantShotPower = 0f;
    }    void Start()    {        redBall.useGravity = false;        powerSlider.maxValue = maxShotPower;    }    void Update()    {        transform.position = currantBall.position;

        //ui
        speedDial.SetText(currantBall.velocity.magnitude.ToString());        powerDial.SetText(currantShotPower.ToString());
        powerSlider.value = currantShotPower;
        xRotation += Input.GetAxis("Mouse X") * rotationSpeed;

        // stop movement if to slow
        if (currantBall.velocity.magnitude <= 0.05)        {            stopVelocity = new Vector3(0, 0, 0);            currantBall.velocity = stopVelocity;            SwitchPlayer();        }

        //rotate cam
        transform.rotation = Quaternion.Euler(transform.rotation.y, xRotation, 0f);        ShootLogic();    }    void ShootLogic()    {        if (canShoot)        {            if (Input.GetMouseButton(0))            {                currantShotPower -= Input.GetAxis("Mouse Y");                if (currantShotPower > maxShotPower)
                {
                    currantShotPower = maxShotPower;
                }
                if (currantShotPower < 0f)
                {
                    currantShotPower = 0f;
                }            }            if (Input.GetMouseButtonUp(0))            {                currantBall.velocity = transform.forward * (currantShotPower);                currantShotPower = 0f;                canSwitch = true;                canShoot = false;            }        }    }    void SwitchPlayer()    {        if (canSwitch & currantBall.velocity.x == 0 & currantBall.velocity.y == 0 & currantBall.velocity.z == 0)        {            canShoot = true;            canSwitch = false;            currantShotPower = 0f;            if (currantBall == blueBall)            {                currantBall = redBall;                currantBall.useGravity = true;            }            else            {                currantBall = blueBall;            }        }    }}