using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindmilTurn : MonoBehaviour
{
    public float speed = 200f;
    void Update()
    {
        transform.Rotate(Vector3.left * Time.deltaTime * speed);
    }
}
