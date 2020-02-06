using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject textScene;
    public GameObject textOption1;
    public GameObject textOption2;
    public GameObject textOption3;
    public GameObject textOption4;

    GameObject[] textOptions;
    private static Dictionary<string, List<string>> optionByScenes;

    // Start is called before the first frame update
    void Start()
    {
        textOptions = new GameObject[] { textOption1, textOption2, textOption3, textOption4 };
        LoadSceneData();
        PopulateText();

    }

    private void LoadSceneData()
    {
        optionByScenes = new Dictionary<string, List<string>>();

        TextAsset xmlData = (TextAsset)Resources.Load("data");
        XmlDocument xmlDocument = new XmlDocument();
        xmlDocument.LoadXml(xmlData.text);

        foreach (XmlNode scene in xmlDocument["scenes"].ChildNodes)
        {
            string sceneName = scene.Attributes["name"].Value;

            List<string> options = new List<string>();

            foreach (XmlNode option in scene["options"].ChildNodes)
            {
                options.Add(option.InnerText);
            }
            optionByScenes[sceneName] = options;
        }
    }

    private void PopulateText()
    {
        foreach (KeyValuePair<string, List<string>> optionByScene in optionByScenes)
        {
            textScene.GetComponent<Text>().text = optionByScene.Key;

            for (int i = 0; i < textOptions.Length; i++)
            {
                textOptions[i].GetComponent<Text>().text = optionByScene.Value[i];
            }
        }
    }
}
