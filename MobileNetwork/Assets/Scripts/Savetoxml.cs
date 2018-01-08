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
        XmlDocument filename = new XmlDocument(); // Idk why we need this one but we actually need it to save the writer inside it
        XmlWriterSettings settings = new XmlWriterSettings(); // Creation of settings that will be needed to be bootiful
        settings.Indent = true; // This is bootiful
        settings.NewLineOnAttributes = true; // Same shit than before
        XmlWriter writer = XmlWriter.Create("./Assets/Resources/AntennasOut.xml", settings); // This is creation of the XML file and its settings
        

        writer.WriteStartElement("antennas"); // <antennas>

        // Fetches all gameobject with the tag "antenna" and puts it in an array tmp
        GameObject[] tmp = GameObject.FindGameObjectsWithTag("Antenna");

        // For each gameobject, creates an XML save in the XML file
        foreach(GameObject antennaobject in tmp)
        {
            // Gathers data from the Unity components
            antennaData antenna = antennaobject.GetComponent<antennaData>();

            writer.WriteStartElement("antenna"); // <antenna>
            writer.WriteElementString("name", antenna.name); // Adds name as parameters of antenna <Antenna
            writer.WriteStartElement("object"); // <object>
            writer.WriteAttributeString("xpos", antennaobject.transform.position.x.ToString()); // Adds the x 
            writer.WriteStartElement("object"); // <object>
            writer.WriteAttributeString("zpos", antennaobject.transform.position.y.ToString()); // Adds the y position as z since the map is rotated by 90°
            writer.WriteStartElement("object"); // <object>
            writer.WriteAttributeString("frequency", antenna.frequency.ToString()); // Adds the frequency
            writer.WriteStartElement("object"); // <object>
            writer.WriteAttributeString("power", antenna.power.ToString()); // Adds the power
            writer.WriteEndElement(); // </antenna>
        }
        writer.WriteEndElement(); // </antennas>
        filename.Save(writer); // Writes everything in the XML file
    }
}
