using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;
using System;
using SimpleFileBrowser;

public class Controla : MonoBehaviour
{
    public float tempo = 0, velocidade = 0;
    private float cronometro;
    int tempoS;
    private string cenaAtual;
    public int i = 0;

    public List<int> numeros = new List<int>();
    List<string> tempos = new List<string>() { "Selecione ", "5 segundos ", "6 segundos", "7 segundos", "8 segundos", "9 segundos", "10 segundos" };
    List<string> velocidades = new List<string>() { "Selecione ", "5 graus ", "6 graus", "7 graus", "8 graus", "9 graus", "10 graus" };
    public Dropdown dropdownT, dropdownV;
    public Text dropdownText, dropdownText1;

    public Carregar c;
    //Strings 
    string TimeS, TipoS, TempoD, TempoA;
    public TextLogControl logControl;
    private string[] cena;
    //Objetos
    public GameObject erro, erroV, erroT, controla, texto, Camera, erroC;
  
    //Inputs
    public InputField InputTempoD, InputTempoA;

    Vector3 Movimento;
    private int numeroAleatorio, j = 0;
    private bool carregado = false;

    void Start()
    {
        cena = new string[7];
        
    }   
    void Update()
    {
        tempo = tempo + Time.deltaTime;
        cronometro = tempo;
        tempoS = Convert.ToInt16(tempo);
      
        cenaAtual = SceneManager.GetActiveScene().name;
        if (SceneManager.GetActiveScene().name != "Inicio3d")
        {
            try
            {
                if (cenaAtual == "TelaMensagem")
                {
                    texto = GameObject.Find("Texto");
                    texto.GetComponent<Text>().text = Convert.ToString(10 - tempoS);
                    if (tempo > 10)
                        ChangeScene(cena[i]);
                }
                if(cenaAtual != "TelaMensagem" && cenaAtual !="Inicio3d")
                    ChangeScene(cena[i]);   
            }
            catch
            {
                SceneManager.LoadScene("Final");
                Destroy(controla);
            }
        }
    }

    public void Iniciar()
    {
        tempo = 0;
        i = 0;
        //Recebendo entradas  
        TempoD = InputTempoD.text;
        TempoA = InputTempoA.text;

        //Convertendo para int
        c.tempoD = Convert.ToInt16(TempoD);
        c.tempoA = Convert.ToInt16(TempoA);

        if (c.tempo >= 5 && (c.tempo <= 10)) {
            if (velocidade >= 5 && velocidade <= 10)
            {
                if (c.tipo == 1 || c.tipo == 2)
                {
                    SetCena();
                    AleatorioFisio();
                    DontDestroyOnLoad(gameObject);
                    SceneManager.LoadScene(cena[i]);
                    i++;
                    if (c.tipo == 2)
                        Aleatorio();
                }
                    else
                    erro.SetActive(true);
            }
            else
                erroV.SetActive(true);
            }
        else
            erroT.SetActive(true);

    }
    public void Sequencial(bool active)
    {
        c.tipo = 1;
    }

    public void Randomico(bool active)
    {
        c.tipo = 2;
    }
    public void Dropdow_IndexTempo(int index)
    {
        dropdownText.text = tempos[index];
        if (index == 0)
        {
            dropdownText.color = Color.red;
            c.tempo = 0;
            print(" Entrou 0");
        }
        else
            dropdownText.color = Color.black;
        if (index == 1)
            c.tempo = 5;
        if (index == 2)
            c.tempo = 6;
        if (index == 3)
            c.tempo = 7;
        if (index == 4)
            c.tempo = 8;
        if (index == 5)
            c.tempo = 9;
        if (index == 6)
            c.tempo = 10;
    }
    public void Dropdow_IndexVelocidade(int index)
    {
        dropdownText1.text = velocidades[index];
        if (index == 0)
        {
            dropdownText1.color = Color.red;
            velocidade = 0;
        }
        else
            dropdownText1.color = Color.black;
        if (index == 1)
            velocidade = 5;
        if (index == 2)
            velocidade = 6;
        if (index == 3)
            velocidade = 7;
        if (index == 4)
            velocidade = 8;
        if (index == 5)
            velocidade = 9;
        if (index == 6)
            velocidade = 10;
    }
    public void ChangeScene(string a)
    {
        if (cronometro < c.tempo)
        {
            Rotation();
        }
        else
        {
            if (c.tipo == 1)
            {
               
                if (tempo > ((c.tempo * j) + c.somaA))
                {
                    if (cenaAtual != "Fisio" && cenaAtual != "Final")
                    {
                        SceneManager.LoadScene("Fisio");
                        c.somaA = somaAtual(j);
                    }
                }
                if (tempo > ((c.tempo * j) + c.somaA))
                {
                    if (cenaAtual != "Final")
                    {
                        SceneManager.LoadScene(cena[i]);
                        i++;
                        j++;
                        cronometro = 0;
                    }
                }
                if (j == 4)
                {
                    if (cenaAtual != "Final")
                    {
                        Destroy(gameObject);
                        SceneManager.LoadScene("Final");

                        j = 0;
                    }
                }
        }
            if (c.tipo == 2)
            {
                if (cenaAtual == "Inicio3d")
                {
                    SceneManager.LoadScene("TelaMensagem");
                }
                else {
                    SceneManager.LoadScene(cena[numeros[i]]);
                    i++;
                }    
            }
            DontDestroyOnLoad(gameObject);
        }
    }
    public void AleatorioFisio()
    {
        print("Entrou fisio");
        int aleatorio;
        for (int j = 0; j < 6; j++)
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
    public void errorTipo()
    {
        erro.SetActive(false);
        
      
    }
    public void errorTempo()
    {
        erroT.SetActive(false);
        
        
    }
    public void errorVelocidade()
    {
        erroV.SetActive(false);
       
    }

    public void Rotation()
    {
        print("Entrou rotation");
        GameObject.Find("Cena").transform.Rotate(0, velocidade * Time.deltaTime, 0);
    }
    public void SalvaExperimento()
    {
        AleatorioFisio();
        if (c.tipo == 2)
        {
            Aleatorio();
        }
        FileBrowser.ShowSaveDialog((path) => {
            var _arquivo = File.CreateText(path); _arquivo.WriteLine(JsonUtility.ToJson(c));
            _arquivo.Close();
        }, null, false, null, "Save", "Save");

        print("Salvou Json");
        //
    }
    private void SetCena()
    {
        cena[0] = "TelaMensagem";
        cena[1] = "Cena1";
        cena[2] = "Cena2";
        cena[3] = "Cena3";
        cena[4] = "Cena4";
    }

    public void Aleatorio()
    {
        for (int i = 0; i < 6; i++)
        {
            numeroAleatorio = UnityEngine.Random.Range(1, 7);
            for (int j = 0; j < 6; j++)
            {
                if (numeros.Contains(numeroAleatorio))
                {
                    numeroAleatorio = UnityEngine.Random.Range(1, 7);
                }
                else
                {
                    numeros.Add(numeroAleatorio);
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
                logControl.LogText(path); var _arquivoJson = File.OpenText(path); string json = JsonUtility.ToJson(c);
     
            }, null, false, null, "Select Folder", "Select");

            carregado = true;
        }
        else
            erroC.SetActive(true);
    }
    public void IniciarCarregado()
    {
        SceneManager.LoadScene("TelaMensagem");
        c.tempoD = 2;
        c.tempoA = 4;
        DontDestroyOnLoad(gameObject);
        cronometro = 0;
    }
}

