using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class configurado : MonoBehaviour
{
    public float cronometro = 0;
    //Strings 
    public GameObject CriançasC;
    public GameObject MaeC;
    public GameObject CriançasS;
    public GameObject MaeS;
    public GameObject PaiC;
    public GameObject PaiS;
    public GameObject Fisio;
    public Text texto;
    //Objetos
    public GameObject textoT;

    [SerializeField]
    public Carregar c;
    private short tempoS;
    private string cenaAtual;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        cronometro += Time.deltaTime;
        tempoS = Convert.ToInt16(cronometro);
        cenaAtual = SceneManager.GetActiveScene().name;
        if (cenaAtual == "2dd") {
            if (cronometro < 20)
                textoT.GetComponent<Text>().text = Convert.ToString(20 - tempoS);
            if (cronometro > 20)
            {
                Fisio.SetActive(true);
            }
            if (cronometro > 22)
            {
                texto.enabled = false;
                textoT.SetActive(false);
                Fisio.SetActive(false);
                CriançasC.SetActive(true);
            }
            if (cronometro > 25)
            {
                CriançasC.SetActive(false);
                Fisio.SetActive(true);
            }
            if (cronometro > 27)
            {
                Fisio.SetActive(false);
                MaeC.SetActive(true);
            }
            if (cronometro > 33)
            {
                MaeC.SetActive(false);
                Fisio.SetActive(true);
            }
            if (cronometro > 36)
            {
                Fisio.SetActive(false);
                MaeS.SetActive(true);
            }
            if (cronometro > 41)
            {
                MaeS.SetActive(false);
                Fisio.SetActive(true);
            }
            if (cronometro > 44)
            {
                Fisio.SetActive(false);
                PaiS.SetActive(true);
            }
            if (cronometro > 49)
            {
                PaiS.SetActive(false);
                Fisio.SetActive(true);

            }
            if (cronometro > 51)
            {
                Fisio.SetActive(false);
                CriançasS.SetActive(true);

            }
            if (cronometro > 56)
            {
                CriançasS.SetActive(false);
                Fisio.SetActive(true);
            }
            if (cronometro > 60)
            {
                Fisio.SetActive(false);
                PaiC.SetActive(true);
            }
            if (cronometro > 65)
            {
                    SceneManager.LoadScene("Cena1");
                    DontDestroyOnLoad(gameObject);
            }
        }
        if (cenaAtual != "Fisio")
        {
            if (cronometro > 75 && cronometro < 79)
            {
                SceneManager.LoadScene("Fisio");
            }
            if (cronometro > 89 && cronometro < 92)
            {
                SceneManager.LoadScene("Fisio");
            }
            if (cronometro > 102 && cronometro < 106)
            {
                SceneManager.LoadScene("Fisio");
            }
        } 
            if (cronometro > 79 && cronometro < 89)
            {   
                if(cenaAtual != "Cena2")
                    SceneManager.LoadScene("cena2");
            }
           
              if (cronometro > 92 && cronometro < 102)
            {
            if (cenaAtual != "Cena3")
                SceneManager.LoadScene("cena3");
            }
                if (cronometro > 106 && cronometro < 116)
            {
            if (cenaAtual != "Cena4")
                SceneManager.LoadScene("cena4");
            }

            if (cronometro > 116)
                SceneManager.LoadScene("Final");
    }
}




