using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using SimpleFileBrowser;
using UnityEngine.XR;

public class Inicio2d : MonoBehaviour
{
    public float cronometro = 0;
    //Strings 
    string  TempoD, TempoA, MetodoS, cenaAtual;

    private int tempoS, numeroAleatorio, num;
    //Inputs
    public InputField InputTempoD, InputTempoAte;
    //Objetos
    public GameObject foto, texto, textoT, erroI ,erroV, erroC;

    List<string> tempos = new List<string>() {"Selecione ", "5 segundos ", "6 segundos", "7 segundos", "8 segundos", "9 segundos", "10 segundos" };
    public Dropdown dropdown;
    public TextLogControl logControl;
    public int Rvirtual = 0, j = 0;
    public Text dropdownText;

    [SerializeField]
    public Carregar c;
    private bool carregado = false;
    public int salvado = 0;
    public GameObject erroc1;


    // Start is called before the first frame update
    public void Start()
    {
        c.tipo = 0;
        c.tempo = 0;
        TempoA = "";
        TempoD = "";
    }
    public void Iniciar()
    {
        Entradas();
        if (c.tempo == 0 || c.tipo == 0 || TempoA == " " || TempoD == " ")
        {
            erroV.SetActive(true);
        }
            else 
                if (c.qtdImagens > 0)
                {
                
                    cronometro = 0;
                    if (salvado == 0)
                    {
                        AleatorioFisio();
                        if (c.tipo == 2)
                        {
                            Aleatorio();
                        }
                    }
                    DontDestroyOnLoad(gameObject);
                    SceneManager.LoadScene("TelaMensagem");
                }
        else
        {
            erroI.SetActive(true);
        }
    }
  
    public void Entradas()
    {
        c.qtdImagens = c.url.Count;
        //Lendo os inputs
        try
        {
            TempoD = InputTempoD.text;
            TempoA = InputTempoAte.text;
        }
        catch
        {
            erroV.SetActive(true);
        }
       

        //Convertendo para int
 
        c.tempoD = Convert.ToInt32(TempoD);
        c.tempoA = Convert.ToInt16(TempoA);
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
            textoT.GetComponent<Text>().text = Convert.ToString(5 - tempoS);
            if (cronometro > 5)
            {
                SceneManager.LoadScene("2d");
                cronometro = 0;
            }
        }
        if (cenaAtual == "2d" || cenaAtual == "Fisio")
        {
            if (Rvirtual == 1) {
                EnableVR();
                print("Entrou Virtual");
            }
                
            Tipo();
        }
    }
    void Tipo()
    {
        if (c.tipo == 1)
        {
            foto = GameObject.Find("Fotos");
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
                if (cenaAtual != "2d" && cenaAtual != "Final")
                {

                    SceneManager.LoadScene("2d");
                    foto = GameObject.Find("Fotos");
                    StartCoroutine(LoadFromPC(c.url[j]));
                    j++;
                }
            }
            if (cenaAtual != "Final")
            {
                if (j == c.qtdImagens)
            {
                    Destroy(foto);
                    Destroy(gameObject);
                    SceneManager.LoadScene("Final");
                    j = 0;
                    cronometro = 0;
                }
            }

        }
        if (c.tipo == 2)
        {
            foto = GameObject.Find("Fotos");
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
                if (cenaAtual != "2d" && cenaAtual != "Final")
                {
                    SceneManager.LoadScene("2d");
                    foto = GameObject.Find("Fotos");
                    StartCoroutine(LoadFromPC(c.url[c.numeros[j]]));
                    j++;
                }
            }
            if (j == c.qtdImagens)
            {
                if (cenaAtual != "Final")
                {
                    print("entrou ale3");
                    Destroy(gameObject);
                    SceneManager.LoadScene("Final");

                    j = 0;
                }
            }
        }
    }

    public void Acicionar()
    {
        FileBrowser.ShowLoadDialog((path) => { c.url.Add(path); logControl.LogText(path); }, null, false, null, "Select Folder", "Select");
    }
    public void Remover()
    {
        //Excluindo 
        logControl.UnLogText();
        c.url.RemoveAt(c.url.Count - 1 );
    }

    public void Populate_list()
    {
        dropdown.AddOptions(tempos);
    }
    public void Dropdow_Index(int index)
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
    private IEnumerator LoadFromPC(string url)
    {
        WWW loader = new WWW(url);
        yield return loader;
        if (cenaAtual == "2d")
        {
            foto.GetComponent<RawImage>().texture = loader.texture;
        }
    }
    public void Aleatorio()
    {
        for (int i = 0; i < c.qtdImagens; i++)
        {
            numeroAleatorio = UnityEngine.Random.Range(0, c.qtdImagens);
            for (int j = 0; j < c.qtdImagens; j++)
            {
                if (c.numeros.Contains(numeroAleatorio))
                {
                    numeroAleatorio = UnityEngine.Random.Range(0, c.qtdImagens);
                }
                else
                {
                    c.numeros.Add(numeroAleatorio);
                }
            }
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
    public void errorc1()
    {
        erroc1.SetActive(false);
    }
    public void errorV()
    {
        erroV.SetActive(false);
    }
    public void errorI()
    {
        erroI.SetActive(false);
    }
    IEnumerator LoadDevice(string newDevice)
    {
        XRSettings.LoadDeviceByName(newDevice);
        yield return null;
        XRSettings.enabled = true;
    }
    void EnableVR()
    {
        StartCoroutine(LoadDevice("Cardbord"));
    }
    public void RealidadeVirtual(bool active)   
    {
        print("Entrou VR");
        Rvirtual = 1;
    }

    public void Sequencial(bool active)
    {
            c.tipo = 1;
    }

    public void Randomico(bool active)
    {
            c.tipo = 2;
    }
    public void SalvaExperimento()
    {
        salvado++;
        Entradas();
        AleatorioFisio();
        if (c.tipo == 2)
        {
            Aleatorio();
        }
        FileBrowser.ShowSaveDialog((path) => { var _arquivo = File.CreateText(path); _arquivo.WriteLine(JsonUtility.ToJson(c));
            _arquivo.Close();
        }, null, false, null, "Save", "Save");

        print("Salvou Json");
        //
    }
    public void CarregarExperimento()
    {
        if (carregado == false)
        {
            FileBrowser.ShowLoadDialog((path) =>
            {
                logControl.LogText(path); var _arquivoJson = File.OpenText(path); string json = JsonUtility.ToJson(c);
                c = JsonUtility.FromJson<Carregar>(_arquivoJson.ReadLine().ToString()); _arquivoJson.Close();
            }, null, false, null, "Select Folder", "Select");

            carregado = true;
        }
        else
            erroC.SetActive(true);
    }
    public void IniciarCarregado()
    {
        if (carregado == true)
        {
            SceneManager.LoadScene("TelaMensagem");
            DontDestroyOnLoad(gameObject);
            cronometro = 0;
        }
        else
            erroc1.SetActive(true);

    }
}