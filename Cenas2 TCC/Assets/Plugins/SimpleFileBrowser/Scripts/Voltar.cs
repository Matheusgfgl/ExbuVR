using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

public class Voltar : MonoBehaviour
{
    Inicio2d carregar;
    public GameObject erro;

    public void VoltarInicio()
    {
        SceneManager.LoadScene("Inicial");
        print("Entrou");
    }
    public void Carregar()
    {
        SceneManager.LoadScene("Carregar");
     
    }
    public void Carregar3d()
    {
        SceneManager.LoadScene("Carregar3d");

    }
    public void CarregarAmbos()
    {
        SceneManager.LoadScene("Carregar3d");

    }
    public void Construir()
    {
        SceneManager.LoadScene("Inicio2d");
    }
   
    public void Construir3d()
    {
        SceneManager.LoadScene("Inicio3d");
    }
    public void ConstruirAmbos()
    {
        SceneManager.LoadScene("InicioAmbos");
    }
    public void Sair()
    {
        Application.Quit();
    }
    public void VoltarEscolha()
    {
        SceneManager.LoadScene("Escolha");
    }
    public void VoltarEscolha3d()
    {
        SceneManager.LoadScene("Escolha3d");
    }
    public void VoltarEscolhaAmbos()
    {
        SceneManager.LoadScene("EscolhaAmbos");
    }
    public void SairErro()
    {
        erro.SetActive(false);
    }

}
