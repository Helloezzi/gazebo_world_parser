using UnityEngine;
using System.IO;
using System.Xml;
using UnityEngine.UI;

public class ParseWorld : MonoBehaviour
{
    public Button OpenXmlButton;

    public string FilePath;

    // Start is called before the first frame update
    void Start()
    {
        OpenXmlButton.onClick.AddListener(() => {
            OpenXml();
        });
    }

    private void OpenXml()
    {
        if (!File.Exists(FilePath))
            return;

        string strTemp = File.ReadAllText(FilePath);
        XmlDocument doc = new XmlDocument();
        doc.Load(FilePath);
        XmlElement root = doc["sdf"];

        XmlNode worldNode = root.SelectSingleNode("world");
        Debug.Log($"world name : {worldNode.Attributes[0].Value}");

        int count1 = 0;
        int count2 = 0;
        foreach(XmlNode node in worldNode.ChildNodes)
        {
            foreach(XmlNode childNode in node.ChildNodes)
            {
                Debug.Log($"{count2++} attributes name : {childNode.Attributes[0].Value}");
            }
        }
    }
}