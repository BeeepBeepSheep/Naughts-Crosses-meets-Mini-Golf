using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfBounds : MonoBehaviour
{
    public GameObject player;
    public Transform spawnPoint;
    private Vector3 stopVelocity;

    void OnTriggerEnter(Collider collision)
    {
        stopVelocity = new Vector3(0, 0, 0);

        player.GetComponent<Player>().SwitchPlayer();
        collision.GetComponent<Rigidbody>().velocity = stopVelocity;
        collision.GetComponent<Rigidbody>().useGravity = false;
        collision.transform.position = player.GetComponent<Player>().currantSpawnPoint.position;
    }
}
