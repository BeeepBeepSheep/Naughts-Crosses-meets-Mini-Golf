using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelector : MonoBehaviour
{
    public GameObject player;
    public int requestedLevel;

    public float sensitivity = 5;

    public Slider menuSensSlider;
    public GameObject worldSensSlider;

    public bool isFullScreen = true;
    public GameObject fullscreenTick;
    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }
    public void WorldStart()
    {
        player = GameObject.Find("PivotPoint");

        switch (requestedLevel)
        {
            case 1:
                player.GetComponent<Player>().currantSpawnPoint = player.GetComponent<Player>().spawnPoint1;
                break;

            case 2:
                player.GetComponent<Player>().currantSpawnPoint = player.GetComponent<Player>().spawnPoint2;
                break;

            case 3:
                player.GetComponent<Player>().currantSpawnPoint = player.GetComponent<Player>().spawnPoint3;
                break;

            case 4:
                player.GetComponent<Player>().currantSpawnPoint = player.GetComponent<Player>().spawnPoint4;
                break;

            case 5:
                player.GetComponent<Player>().currantSpawnPoint = player.GetComponent<Player>().spawnPoint5;
                break;

            default:
                Debug.Log("not an option");
                break;
        }
    }


    public void Level1()
    {
        sensitivity = menuSensSlider.value;
        SceneManager.LoadScene("1");
        requestedLevel = 1;
    }
    public void Level2()
    {
        sensitivity = menuSensSlider.value;
        SceneManager.LoadScene("1");
        requestedLevel = 2;
    }
    public void Level3()
    {
        sensitivity = menuSensSlider.value;
        SceneManager.LoadScene("1");
        requestedLevel = 3;
    }
    public void Level4()
    {
        sensitivity = menuSensSlider.value;
        SceneManager.LoadScene("1");
        requestedLevel = 4;
    }
    public void Level5()
    {
        sensitivity = menuSensSlider.value;
        SceneManager.LoadScene("1");
        requestedLevel = 5;
    }

    public void FullScreenToggle()
    {
        if (isFullScreen)
        {
            isFullScreen = false;
            Screen.fullScreen = isFullScreen;
            fullscreenTick.SetActive(false);
        }
        else
        {
            isFullScreen = true;
            Screen.fullScreen = isFullScreen;
            fullscreenTick.SetActive(true);
        }
        Debug.Log(isFullScreen);
    }

    public void AdjustSens(float newSens)
    {
        sensitivity = newSens;
    }
}
