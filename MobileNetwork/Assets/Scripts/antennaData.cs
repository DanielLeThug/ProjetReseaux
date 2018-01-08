using UnityEngine;
using System.Collections;

public class antennaData : MonoBehaviour {

	public string name = "UNDEFINED";
	public int frequency = 0;
	public float power = 0;

	public void set(string newName, int newFrequency, float newPower) {
		name = newName;
		frequency = newFrequency;
		power = newPower;
        GetComponentInChildren<SphereCollider>().radius = power;

        //GetComponent<SphereCollider> ().radius = power;
	}
}
