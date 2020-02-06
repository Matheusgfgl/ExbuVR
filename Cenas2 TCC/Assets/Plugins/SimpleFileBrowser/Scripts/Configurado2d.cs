using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Configurado2d : MonoBehaviour
{
    public float cronometro = 0;
    //Strings 
    string TempoD, TempoA, MetodoS, cenaAtual;
    public GameObject []Fotos;
    private int tempoS, numeroAleatorio, num, j = 0;
    //Objetos
    public GameObject textoT;
    Carregar c;

    // Start is called before the first frame update
    void Start()
    {
        c.tempo = 10;
        c.tempoD = 2;
        c.tempoA = 6;
        c.tipo = 1;
        
    }

    // Update is called once per frame
    void Update()
    {   
        
        cronometro += Time.deltaTime;
        tempoS = Convert.ToInt16(cronometro);
        cenaAtual = SceneManager.GetActiveScene().name;

        if (cenaAtual == "TelaMensagem")
        {
            textoT = GameObject.Find("Texto");
            textoT.GetComponent<Text>().text = Convert.ToString(20 - tempoS);
            if (cronometro > 20)
            {
                SceneManager.LoadScene("2dd");
                cronometro = 0;
            }
        }
        if (cenaAtual == "2d" || cenaAtual == "Fisio")
        {
            Fotos[0] = GameObject.Find("Foto1");
            Fotos[1] = GameObject.Find("Foto2");
            Fotos[2] = GameObject.Find("Foto3");
            Fotos[3] = GameObject.Find("Foto4");
            Fotos[4] = GameObject.Find("Foto5");
            Fotos[5] = GameObject.Find("Foto6");
            Tipo();
        }
    }
    void Tipo()
    {
            if (j >= 0 && j < c.qtdImagens)
            {
                if (cronometro > ((c.tempo * j) + c.somaA))
                {
                    if (cenaAtual != "Fisio" && cenaAtual != "Final")
                    {
                        SceneManager.LoadScene("Fisio");
                        c.somaA = somaAtual(j);
                    }
                }
            }
            if (cronometro > ((c.tempo * j) + c.somaA))
            {
                if (cenaAtual != "2dd" && cenaAtual != "Final")
                {
                    
                    SceneManager.LoadScene("2dd");
                    Fotos[j].SetActive(true);
                    //foto = GameObject.Find("Fotos");
                    //StartCoroutine(LoadFromPC(c.url[j]));
                    j++;
                }
            }
            if (j == c.qtdImagens)
            {
                if (cenaAtual != "Final")
                {
                    Destroy(gameObject);
                    SceneManager.LoadScene("Final");
                    j = 0;
                }
            }
        }
    private IEnumerator LoadFromPC(string url)
    {
        WWW loader = new WWW(url);
        yield return loader;
        if (cenaAtual == "2d")
        {
            //foto.GetComponent<RawImage>().texture = loader.texture;
        }
    }
    public void AleatorioFisio()
    {
        int aleatorio;
        for (int j = 0; j < c.qtdImagens; j++)
        {
            aleatorio = UnityEngine.Random.Range(c.tempoD, c.tempoA);
            c.numeroAleatorioFisio.Add(aleatorio);
            c.SomaAle += c.numeroAleatorioFisio[j];
        }
    }
    public int somaAtual(int atual)
    {
        c.somaI = c.numeroAleatorioFisio[0];
        for (int i = 1; i <= atual; i++)
        {
            c.somaI += c.numeroAleatorioFisio[i];
        }
        return c.somaI;
    }
}

