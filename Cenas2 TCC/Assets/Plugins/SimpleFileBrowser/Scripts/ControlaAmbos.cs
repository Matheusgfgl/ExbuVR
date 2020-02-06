using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;
using System;

public class ControlaAmbos : MonoBehaviour
{
    public float tempo = 0;
    public float tempoMax;
    public float velocidade = 0;
    public int tipo;
    public int i = 0;
    public int contadorCena = 1;
    //Strings 
    string TimeS;
    string VelocidadeS;
    string TipoS;
    private string[] cena;
    //Objetos
    public GameObject erro;
    //Inputs
    public InputField InputTime;
    public InputField InputVelocidade;
    public InputField InputTipo;

    Vector3 Movimento;

    void Start()
    {
        cena = new string[7];

    }
    void Update()
    {
        tempo = tempo + Time.deltaTime;
        if (SceneManager.GetActiveScene().name != "InicioAmbos")
        {
            ChangeScene(cena[i]);
        }
    }

    public void Iniciar()
    {
        tempo = 0;

        //Recebendo entradas  
        TimeS = InputTime.text;
        VelocidadeS = InputVelocidade.text;
        TipoS = InputTipo.text;

        //Convertendo para int
        tempoMax = Convert.ToInt32(TimeS);
        velocidade = Convert.ToInt32(VelocidadeS);

        if ((tempoMax > 5 && tempoMax < 20) && (velocidade > 5 && velocidade < 10) && (TipoS == "1" || TipoS == "2"))
        {
            tipo = Convert.ToInt32(TipoS);

            DontDestroyOnLoad(gameObject);
            Tipo(tipo);
            SceneManager.LoadScene(cena[i]);
        }
        else
        {
            erro.SetActive(true);
        }
    }

    public void ChangeScene(string a)
    {
        if (tempo < tempoMax)
        {
            Rotation();
        }
        else
        {
            tempo = 0;
            i++;
            contadorCena++;
            SceneManager.LoadScene(cena[i]);
            DontDestroyOnLoad(gameObject);
        }
    }

    public void Tipo(int tipo)
    {
        if (tipo == 1)
        {
            cena[0] = "TelaMensagem";
            cena[1] = "Cena1";
            cena[2] = "Cena2";
            cena[3] = "Cena3";
            cena[4] = "Cena4";
            cena[5] = "Cena5";
            cena[6] = "Cena6";
        }
        if (tipo == 2)
        {
            print("Randomico");
        }
    }

    public void error()
    {
        erro.SetActive(false);
        InputTipo.text = "";
        InputTime.text = "";
        InputVelocidade.text = "";
    }


    public void Rotation()
    {
        Movimento = new Vector3(0, 0, 0);
        //GameObject.FindWithTag("Camera").transform.Rotate(0, -velocidade * Time.deltaTime, 0);
        //GameObject.FindWithTag("Camera").transform.position(0, velocidade * Time.deltaTime, 0);
    }

}
