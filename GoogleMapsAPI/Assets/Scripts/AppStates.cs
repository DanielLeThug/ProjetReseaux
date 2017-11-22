using UnityEngine;
using System.Collections.Generic;
using System.Xml;

public class AppStates : MonoBehaviour {

	List<GameObject> antennas = new List<GameObject>();

    public TextAsset GameAsset;
    static string AntennaName = "";
    static int xpos = 0;
    static int ypos = 0;
    static int frequency = 0;
    static int power = 0;

    private void createAntennas() {

        XmlDocument xmlDoc = new XmlDocument(); // xmlDoc is the new xml document.
        xmlDoc.LoadXml(GameAsset.text);
        XmlNodeList antennasList = xmlDoc.GetElementsByTagName("antenna");

        foreach (XmlNode antennaInfo in antennasList)
        {
            XmlNodeList antennacontent = antennaInfo.ChildNodes;

            foreach (XmlNode antennaItem in antennacontent) // levels items nodes.
            {
                if (antennaItem.Name == "name")
                {
                    AntennaName = antennaItem.InnerText;
                }

                if (antennaItem.Name == "object")
                {
                    switch (antennaItem.Attributes["name"].Value)
                    {
                        case "xpos": xpos = int.Parse(antennaItem.InnerText); break; // put this in the dictionary.
                        case "ypos": ypos = int.Parse(antennaItem.InnerText); break; // put this in the dictionary.
                        case "frequency": frequency = int.Parse(antennaItem.InnerText); break; // put this in the dictionary.
                        case "power": power = int.Parse(antennaItem.InnerText); break; // put this in the dictionary.
                    }
                }
            }
            createAntenna(xpos, ypos, frequency, power, name);
        }  
    }

	private void createAntenna(float x, float y, int frequency, float power, string name) {
		GameObject antenna = Instantiate (Resources.Load ("antenna"), new Vector3(x,y,0), Quaternion.identity) as GameObject;
		antenna.GetComponent<antennaData> ().set (name, frequency, power);
		antennas.Add (antenna);
	}

	private void createTile(float size, int i, int j) {
		GameObject tile = Instantiate (Resources.Load ("tile"), Vector2.right, Quaternion.identity) as GameObject;
		Tools.resize (tile, new Vector2(size, size));
		tile.transform.position = new Vector3(i*size,j*size,1);
	}

	private void createTiles() {
		float size = 1;
		int nb = 10;
		for (int i = -nb; i < nb; i++)
			for (int j = -nb; j < nb; j++)
				createTile (size, i, j);
	}

	void Start () {
		createAntennas ();
		createTiles ();
	}

	void Update () {
	}
}