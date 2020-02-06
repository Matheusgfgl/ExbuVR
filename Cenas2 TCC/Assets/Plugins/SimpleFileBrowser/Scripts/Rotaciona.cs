using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotaciona : MonoBehaviour
{
    public GameObject cena;
    public float cronometro;
    public int speed = 10;

    // Update is called once per frame
    void Update()
    {
        cronometro += Time.deltaTime;
        transform.Rotate(0, speed * -Time.deltaTime, 0);
    }
}
