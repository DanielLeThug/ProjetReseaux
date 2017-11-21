using UnityEngine;
using System.Collections.Generic;

public class AppStates : MonoBehaviour {

	List<GameObject> antennas = new List<GameObject>();

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

	private void createAntennas() {
		createAntenna (0, 0, 1, 24, "A");
		createAntenna (3, 3, 2, 15, "B");
		createAntenna (-3, -3, 3, 9, "C");
		createAntenna (3, -3, 4, 21, "D");
		createAntenna (-3, 3, 5, 12, "E");
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