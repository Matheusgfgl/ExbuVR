using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

    [System.Serializable]
    public class Carregar {
    //Inteiros
    public int tempo, qtdImagens, SomaAle = 0, somaI = 0;
    public int tempoD, tempoA, tipo;
    public int somaA = 0;
  

    //Lists
    public List<int> numeros = new List<int>();
    public List<int> numeroAleatorioFisio = new List<int>();
    public List<string> url;

    public Carregar(int tempo, int tempoD, int tempoA, int tipo)
        {
            this.tempo = tempo;
            this.tempoA = tempoA;
            this.tempoD = tempoD;
            this.tipo = tipo;
    }
}
    