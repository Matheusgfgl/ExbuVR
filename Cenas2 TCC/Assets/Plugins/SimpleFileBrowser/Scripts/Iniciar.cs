using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;
using UnityEngine.SceneManagement;
      

public class Iniciar : MonoBehaviour
{
    int tipoV = 0;
    public GameObject Dimensão2;
        public GameObject Dimensao3;
        public GameObject Ambos;

    public void Tipo2D(bool active){
            if(active == true)
            {
            tipoV = 1;
            SceneManager.LoadScene("Escolha");
            }
        }
    public void TipoConfig(bool active)
    {
        if (active == true)
        {
            SceneManager.LoadScene("2dd");
        }
    }

    public void Tipo3D(bool active)
        {
            if (active == true)
            {
                SceneManager.LoadScene("Escolha3d");
            }
        }


    public void TipoAmbos(bool active)
            {
                if (active == true)
                {
                    SceneManager.LoadScene("InicioAmbos");
                }

            }

}
