using UnityEngine;
using System.Collections.Generic;

public class reception : MonoBehaviour {

	private Color defaultColor = new Color(255,255,255,0);
	private List<GameObject> captedAntennas = new List<GameObject> ();

	private Color frequencyColor(int frequency) {
		Color color = Color.white;
		switch (frequency) {
		case 1:
			color = new Color (255, 0, 0);
			break;
		case 2:
			color = new Color (0, 255, 0);
			break;
		case 3:
			color = new Color (0, 0, 255);
			break;
		case 4:
			color = new Color (255, 255, 0);
			break;
		case 5:
			color = new Color (255, 0, 255);
			break;
		}
		return color;
	}

	private float powerAlpha(Vector2 antennaPosition, float antennaPower) {
		Vector2 a = transform.position;
		Vector2 b = antennaPosition;
		float distance = Mathf.Sqrt (Mathf.Pow (b.x - a.x, 2) + Mathf.Pow (b.y - a.y, 2));
		return 1 - ((distance / antennaPower) * 5);
	}

	void OnTriggerEnter2D(Collider2D collision) {
		captedAntennas.Add (collision.gameObject);
	}

	void OnTriggerExit2D(Collider2D other) {
		captedAntennas.Remove (other.gameObject);
		if(captedAntennas.Count == 0)
			GetComponent<SpriteRenderer> ().color = defaultColor;
	}

	void Start() {
		GetComponent<SpriteRenderer> ().color = defaultColor;
	}

	void Update() {
		if (captedAntennas.Count > 0) {
			Color color = frequencyColor(captedAntennas[0].GetComponent<antennaData>().frequency);
			color.a = powerAlpha (captedAntennas[0].transform.position, captedAntennas[0].GetComponent<CircleCollider2D> ().radius);
			GetComponent<SpriteRenderer> ().color = color;
		}
	}
}