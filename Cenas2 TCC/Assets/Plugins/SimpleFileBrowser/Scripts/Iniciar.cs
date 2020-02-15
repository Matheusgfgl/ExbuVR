using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;
using UnityEngine.SceneManagement;
      


public class Iniciar : MonoBehaviour
{
    int tipoVisualizacao = 0;
 
    //Mudando para tela de construcao em 2d
    public void Tipo2D(bool active){
            if(active == true)
            {
            tipoVisualizacao = 1;
            SceneManager.LoadScene("Escolha");
            }
        }
    //Mudando para tela de construcao em 3d
    public void Tipo3D(bool active)
        {
            if (active == true)
            {
                SceneManager.LoadScene("Escolha3d");
            }
        }

    //Mudando para tela de construcao em ambos
    public void TipoAmbos(bool active)
            {
                if (active == true)
                {
                    SceneManager.LoadScene("EscolhaAmbos");
                }

            }

}
