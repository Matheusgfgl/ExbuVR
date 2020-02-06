using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class teste : MonoBehaviour
{
    public GameObject foto;


    // Start is called before the first frame update

     IEnumerator Start()
    {
        WWW loader = new WWW("C://Users/Matheus/Pictures/Foto.jpg");
        yield return loader;
    
        foto.GetComponent<RawImage>().texture = loader.texture;
    }

   
}
