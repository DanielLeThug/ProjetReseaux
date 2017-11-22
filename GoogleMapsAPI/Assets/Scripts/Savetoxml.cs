using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Xml;

public class Savetoxml : MonoBehaviour {
    public Button yourButton;

    // Use this for initialization
    void Start () {
        Button btn = yourButton.GetComponent<Button>();
        btn.onClick.AddListener(OnClick);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnClick() {
        XmlDocument filename = new XmlDocument();
        XmlWriterSettings settings = new XmlWriterSettings();
        settings.Indent = true;
        settings.NewLineOnAttributes = true;
        XmlWriter writer = XmlWriter.Create("./Assets/Resources/AntennasOut.xml", settings);
        

        writer.WriteStartElement("Antennas"); // <Antennas>

        // Fetch all gameobject with the tag "antenna" and puts it in an array tmp
        GameObject[] tmp = GameObject.FindGameObjectsWithTag("Antenna");

        // For each gameobject, creates an XML save in the XML file
        foreach(GameObject antennaobject in tmp)
        {
            antennaData antenna = antennaobject.GetComponent<antennaData>();
            writer.WriteStartElement("Antenna");
            writer.WriteAttributeString("name", antenna.name); // <Antenna>
            writer.WriteElementString("xpos", antennaobject.transform.position.x.ToString());
            writer.WriteElementString("ypos", antennaobject.transform.position.y.ToString());
            writer.WriteElementString("frequency", antenna.frequency.ToString());
            writer.WriteElementString("power", antenna.power.ToString());
            writer.WriteEndElement();
        }
        writer.WriteEndElement();
        filename.Save(writer);
    }
}
