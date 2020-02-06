using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;
using System;
using SimpleFileBrowser;

public class configurado3d : MonoBehaviour
{
    private int tempoS;
    private string cenaAtual;
    public float cronometro;
    private GameObject textoT;
    public GameObject erroC, erroc1;
    private bool carregado = false;
    public TextLogControl logControl;

    public void Iniciar()
    {
        if (carregado == true)
        {
            SceneManager.LoadScene("TelaMensagem");
            cronometro = 0;
            DontDestroyOnLoad(gameObject);
        }
        else
            erroc1.SetActive(true);
    }
        void Update()
    {
        cronometro += Time.deltaTime;
        tempoS = Convert.ToInt16(cronometro);
        cenaAtual = SceneManager.GetActiveScene().name;
        
            if (cenaAtual != "Carregar3d")
            {
                if (cenaAtual == "TelaMensagem")
                {
                    textoT = GameObject.Find("Texto");
                    textoT.GetComponent<Text>().text = Convert.ToString(5 - tempoS);
                    if (cronometro > 5)
                        SceneManager.LoadScene("Fisio");
                }
                if (cenaAtual != "Fisio")
                {
                    if (cronometro > 17 && cronometro < 20)
                    {
                        SceneManager.LoadScene("Fisio");
                    }
                    if (cronometro > 30 && cronometro < 34)
                    {
                        SceneManager.LoadScene("Fisio");
                    }
                    if (cronometro > 44 && cronometro < 47)
                    {
                        SceneManager.LoadScene("Fisio");
                    }
                }
                if (cronometro > 7 && cronometro < 17)
                {
                    if (cenaAtual != "Cena1")
                        SceneManager.LoadScene("Cena1");
                }

                if (cronometro > 20 && cronometro < 30)
                {
                    if (cenaAtual != "Cena2")
                        SceneManager.LoadScene("cena2");
                }

                if (cronometro > 34 && cronometro < 44)
                {
                    if (cenaAtual != "Cena3")
                        SceneManager.LoadScene("cena3");
                }
                if (cronometro > 47 && cronometro < 57)
                {
                    if (cenaAtual != "Cena4")
                        SceneManager.LoadScene("cena4");
                }
                if (cronometro > 57)
                {
                    if (cenaAtual != "Final")
                    {
                        cronometro = 0;
                        Destroy(gameObject);
                        SceneManager.LoadScene("Final");
                    }
                }
            }
    }
            
        public void CarregarExperimento()
        {
        if (carregado == false)
        {
            FileBrowser.ShowLoadDialog((path) =>
            {
                logControl.LogText(path); var _arquivoJson = File.OpenText(path);

            }, null, false, null, "Select Folder", "Select");

            carregado = true;
        }
        else
            erroC.SetActive(true);
    }
        public void ErroC()
        {
        erroC.SetActive(false);
        }
        public void ErroC1()
        {
        erroc1.SetActive(false);
        }
} 

        
        

