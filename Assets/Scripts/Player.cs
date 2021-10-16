using System.Collections;using System.Collections.Generic;using UnityEngine;using UnityEngine.UI;using TMPro;public class Player : MonoBehaviour{    public TextMeshProUGUI speedDial;    public TextMeshProUGUI powerDial;    public Slider powerSlider;
    public float redMovesCount = 0f;    public float blueMovesCount = 0f;    public TextMeshProUGUI blueMovesCountNum;    public TextMeshProUGUI redMovesCountNum;    float xRotation = 0f;    public Rigidbody currantBall;    public Rigidbody blueBall;    public Rigidbody redBall;    private bool canSwitch = false;    private Vector3 stopVelocity;    public float rotationSpeed = 5f;    public Transform currantSpawnPoint;    public Transform spawnPoint1;    public Transform spawnPoint2;    public Transform spawnPoint3;    public Transform spawnPoint4;    public Transform spawnPoint5;    public GameObject Environment1;    public GameObject Environment2;    public GameObject Environment3;    public GameObject Environment4;    public GameObject Environment5;    public int selectedLevel = 1;    public float maxShotPower = 70f;    public float currantShotPower = 0f;    public bool canShoot = true;    public bool canRotate = true;

    public GameObject levelSelector;    public Animator hudAnim;    void Awake()    {        Cursor.lockState = CursorLockMode.Locked;        Cursor.visible = false;
        currantShotPower = 0f;
    }    void Start()    {
        redBall.useGravity = false;        powerSlider.maxValue = maxShotPower;        levelSelector = GameObject.Find("LevelSelector");

        levelSelector.GetComponent<LevelSelector>().WorldStart();        WorldSelect();

        redBall.GetComponent<Transform>().position = currantSpawnPoint.position;        blueBall.GetComponent<Transform>().position = currantSpawnPoint.position;        rotationSpeed = levelSelector.GetComponent<LevelSelector>().sensitivity;
    }    void Update()    {        transform.position = currantBall.position;

        //ui
        speedDial.SetText(currantBall.velocity.magnitude.ToString());        powerDial.SetText(currantShotPower.ToString());
        powerSlider.value = currantShotPower;
        // stop movement if to slow
        stopVelocity = new Vector3(0, 0, 0);        if (currantBall.velocity.magnitude <= 0.05)        {            currantBall.velocity = stopVelocity;            if (canSwitch & currantBall.velocity.x == 0 & currantBall.velocity.y == 0 & currantBall.velocity.z == 0)
            {
                SwitchPlayer();            }
        }

        //rotate cam
        xRotation += Input.GetAxis("Mouse X") * rotationSpeed;
        transform.rotation = Quaternion.Euler(transform.rotation.y, xRotation, 0f);
        ShootLogic();    }    void ShootLogic()    {        if (canShoot)        {            if (Input.GetMouseButton(0))            {                currantShotPower -= Input.GetAxis("Mouse Y");                if (currantShotPower > maxShotPower)
                {
                    currantShotPower = maxShotPower;
                }
                if (currantShotPower < 0f)
                {
                    currantShotPower = 0f;
                }            }            if (Input.GetMouseButtonUp(0))            {                currantBall.velocity = transform.forward * (currantShotPower);                currantShotPower = 0f;                canSwitch = true;                canShoot = false;            }        }    }    public void SwitchPlayer()    {
        canShoot = true;
        canSwitch = false;
        currantShotPower = 0f;

        blueBall.angularVelocity = stopVelocity;
        redBall.angularVelocity = stopVelocity;

        if (currantBall == blueBall)
        {
            currantBall = redBall;
            currantBall.useGravity = true;
            blueMovesCount++;
            blueMovesCountNum.SetText(blueMovesCount.ToString());
            hudAnim.SetTrigger("RedsTurn");
        }
        else
        {
            currantBall = blueBall;
            currantBall.useGravity = true;
            redMovesCount++;
            redMovesCountNum.SetText(blueMovesCount.ToString());
            hudAnim.SetTrigger("BluesTurn");
        }    }    public void WorldSelect()
    {
        switch (levelSelector.GetComponent<LevelSelector>().requestedLevel)
        {
            case 1:
                Environment1.SetActive(true);
                Environment2.SetActive(false);
                Environment3.SetActive(false);
                Environment4.SetActive(false);
                Environment5.SetActive(false);
                break;

            case 2:
                Environment1.SetActive(false);
                Environment2.SetActive(true);
                Environment3.SetActive(false);
                Environment4.SetActive(false);
                Environment5.SetActive(false);
                break;

            case 3:
                Environment1.SetActive(false);
                Environment2.SetActive(false);
                Environment3.SetActive(true);
                Environment4.SetActive(false);
                Environment5.SetActive(false);
                break;

            case 4:
                Environment1.SetActive(false);
                Environment2.SetActive(false);
                Environment3.SetActive(false);
                Environment4.SetActive(true);
                Environment5.SetActive(false);
                break;

            case 5:
                Environment1.SetActive(true);
                Environment2.SetActive(false);
                Environment3.SetActive(false);
                Environment4.SetActive(false);
                Environment5.SetActive(true);
                break;

            default:
                Debug.Log("not an option");
                break;
        }
    }}