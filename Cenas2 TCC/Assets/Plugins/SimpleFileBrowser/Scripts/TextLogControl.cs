using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TextLogControl : MonoBehaviour
{
    [SerializeField]
    private GameObject textTamplate;
    public int indexItem = 0;

    public Inicio2d remove;
    
    private List<GameObject> textItems = new List<GameObject>();

    public void LogText(string newTextString)
    {

        if (textItems.Count == 10)
        {
            GameObject topItem = textItems[0];
            Destroy(topItem);
            textItems.Remove(topItem);
        }
        GameObject newText = Instantiate(textTamplate) as GameObject;
        newText.SetActive(true);

        newText.GetComponent<TextLogItem>().SetText(newTextString);
        newText.transform.SetParent(textTamplate.transform.parent, false);

        textItems.Add(newText);
        indexItem++;
    }
    public void UnLogText()
    {
        GameObject BotonItem = textItems[indexItem];
        Destroy(BotonItem);
        textItems.Remove(BotonItem);
        indexItem--;
    }
}
