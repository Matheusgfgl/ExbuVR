using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MostraTempo : MonoBehaviour
{
    public Text texto;
    public float tempo;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        tempo = tempo + Time.deltaTime;
        texto.text = Convert.ToString(tempo);
    }
}
