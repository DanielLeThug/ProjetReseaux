using UnityEngine;
using System.Collections;

public class antennaData : MonoBehaviour {

	public string name = "UNDEFINED";
	public int frequency = 0;
	public float power = 0;
    public double[] localisationWGS84;
    public GameObject coloriser;

	public void set(string newName, int newFrequency, float newPower, GameObject newColoriser) {
		name = newName;
		frequency = newFrequency;
		power = newPower;
        coloriser = newColoriser;
        coloriser.transform.localScale = new Vector3(newPower, 0.05f, newPower);
	}
}
