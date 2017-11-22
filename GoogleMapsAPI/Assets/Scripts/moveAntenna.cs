using UnityEngine;
using System.Collections;

public class moveAntenna : MonoBehaviour {

	private bool selected = false;

    private bool touchedOtherAntenna(Vector3 mousePos)
    {
        GameObject[] antennas = GameObject.FindGameObjectsWithTag("Antenna");
        for (int i = 0; i < antennas.Length; i++)
            if (Tools.inside(antennas[i].gameObject, mousePos))
                if (antennas[i].gameObject != gameObject)
                    return true;
        return false;
    }

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
            if (!touchedOtherAntenna(mousePos))
                transform.position = mousePos;
            else
                selected = false;
        }
	}
}
