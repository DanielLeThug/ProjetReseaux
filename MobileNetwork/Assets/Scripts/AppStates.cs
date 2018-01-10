using UnityEngine;
using System.Collections.Generic;
using System.Xml;
using UnitySlippyMap.Map;

public class AppStates : MonoBehaviour {

	public static List<GameObject> antennas = new List<GameObject>();

    public TextAsset GameAsset;
    static string AntennaName = "";
    static float xpos = 0;
    static float zpos = 0;
    static int frequency = 0;
    static float power = 0;

    private void createAntennas() {

        XmlDocument xmlDoc = new XmlDocument(); // xmlDoc is the new xml document.
        xmlDoc.LoadXml(GameAsset.text);
        XmlNodeList antennasList = xmlDoc.GetElementsByTagName("antenna");

        foreach (XmlNode antenna in antennasList)
        {
            AntennaName = antenna.Attributes["name"].Value;
            XmlNodeList antennacontent = antenna.ChildNodes;

            foreach (XmlNode antennaInfo in antennacontent) // levels items nodes.
            {
                switch (antennaInfo.Name)
                {
                    case "xpos": xpos = float.Parse(antennaInfo.InnerText); break; // put this in variable.
                    case "zpos": zpos = float.Parse(antennaInfo.InnerText); break; // put this in variable.
                    case "frequency": frequency = int.Parse(antennaInfo.InnerText); break; // put this in variable.
                    case "power": power = float.Parse(antennaInfo.InnerText); break; // put this in variable.
                }        
            }
            createAntenna(xpos, zpos, frequency, power, AntennaName);
        }
    }
    
    // Gives the location of an antenna in the WGS84 system
    public static double[] GetAntennaLocation(GameObject antenna, MapBehaviour map)
    {
        Vector3 tmp;
        Vector3 tmp_pos;
        tmp_pos.x = antenna.transform.position.x - Screen.width / 2f;
        tmp_pos.y = antenna.transform.position.y - Screen.height / 2f;
        tmp_pos.z = antenna.transform.position.z;
        tmp = Camera.main.ScreenToWorldPoint(tmp_pos);
        int[] center_tile = UnitySlippyMap.Helpers.GeoHelpers.WGS84ToTile(map.CenterWGS84[0], map.CenterWGS84[1], map.RoundedZoom);
        return UnitySlippyMap.Helpers.GeoHelpers.TileToWGS84((int)(center_tile[0] + tmp.x),
                                                                      (int)(center_tile[1] + tmp.y),
                                                                      map.RoundedZoom);
    }

    public void createAntenna(float x, float y, int frequency, float power, string name) {
		GameObject antenna = Instantiate (Resources.Load ("antenna"), new Vector3(x, 0.5f, y), Quaternion.identity) as GameObject;
        GameObject coloriser = Instantiate(Resources.Load("coloriser"), new Vector3(x, 0.5f, y), Quaternion.identity) as GameObject;
        antenna.GetComponent<antennaData>().set(name, frequency, power, coloriser);
        Tools.resize(antenna, new Vector2(0.15f, 0.15f));
        antenna.transform.Rotate (new Vector3(90, 0, 0));
        antennas.Add (antenna);
        coloriser.GetComponent<getAntenna>().source = antenna;
        GameObject go = GameObject.FindGameObjectWithTag("map");
        MapBehaviour map = go.GetComponent<MapBehaviour>();
        antenna.GetComponent<antennaData>().localisationWGS84 = GetAntennaLocation(antenna, map);
    }

	private void createTile(float size, int i, int j) {
		GameObject tile = Instantiate (Resources.Load ("tile"), Vector2.right, Quaternion.identity) as GameObject;
		Tools.resize (tile, new Vector2(size, size));
		tile.transform.position = new Vector3(i*size, 0.5f, j * size);
        tile.transform.Rotate (new Vector3 (90, 0, 0));
    }

	private void createTiles() {
		float size = 0.2f;
		int nb = 20;
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