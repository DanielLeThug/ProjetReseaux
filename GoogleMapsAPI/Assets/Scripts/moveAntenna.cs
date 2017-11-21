using UnityEngine;
using System.Collections;

public class moveAntenna : MonoBehaviour {

	private bool selected = false;

	void Update () {
		
		if(!selected && Input.GetMouseButtonDown (0)
			&& Tools.inside (gameObject, Camera.main.ScreenToWorldPoint (Input.mousePosition))) {
				selected = true;
		}
		if (Input.GetMouseButtonUp (0)) {
			selected = false;
		}
		if (selected) {
			Vector3 mousePos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			mousePos.z = transform.position.z;
			transform.position = mousePos;
		}
	}
}
