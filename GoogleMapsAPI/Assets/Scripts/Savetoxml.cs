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
        

        writer.WriteStartElement("Antennas"); // <Antennas>

        // Fetches all gameobject with the tag "antenna" and puts it in an array tmp
        GameObject[] tmp = GameObject.FindGameObjectsWithTag("Antenna");

        // For each gameobject, creates an XML save in the XML file
        foreach(GameObject antennaobject in tmp)
        {
            // Gathers data from the Unity components
            antennaData antenna = antennaobject.GetComponent<antennaData>();

           writer.WriteStartElement("Antenna"); // <Antenna>
                writer.WriteAttributeString("name", antenna.name); // Adds name as parameters of antenna <Antenna>
                float x = antennaobject.transform.position.x;
                writer.WriteElementString("xpos", x.ToString()); // Adds the x position
                float z = antennaobject.transform.position.z;
                writer.WriteElementString("zpos", z.ToString()); // Adds the y position
                writer.WriteElementString("frequency", antenna.frequency.ToString()); // Adds the frequency
                writer.WriteElementString("power", antenna.power.ToString()); // Adds the power
                writer.WriteEndElement(); // </Antenna>
        }
        writer.WriteEndElement(); // </Antennas>
        filename.Save(writer); // Writes everything in the XML file
    }
}
