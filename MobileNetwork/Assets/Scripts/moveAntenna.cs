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

    /*void OnMouseOver() {

        if(selected)
        {
            print("a");
        }

        if(Input.GetMouseButtonDown(1)){
            selected = true;
        }

        if (Input.GetMouseButtonUp(1))
        {
            selected = false;
        }

    //print("aa");
}*/

    private void OnMouseDown()
    {
        selected = true;
    }

    void OnMouseDrag()
    {
        if (selected)
        {
            Vector3 pos = Input.mousePosition;
            pos.z = transform.position.z - Camera.main.transform.position.z;
            Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(pos);
            worldMousePosition.y = 0.2f;
            worldMousePosition.x *= 2f;
            worldMousePosition.z *= 2f;
            transform.position = worldMousePosition;
            print("a");
        }
    }

    private void OnMouseUp()
    {
        selected = false;
    }

    void Update () {

        /*Vector3 pos = Input.mousePosition;
        pos.z = transform.position.z - Camera.main.transform.position.z;
        Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(pos);
        worldMousePosition.y = 0.2f;
        worldMousePosition.x *= 2f;
        worldMousePosition.z *= 2f;
        

        if (!selected && Input.GetMouseButtonDown (1)
			&& Tools.inside (gameObject, worldMousePosition)) {
				selected = true;
		}
		if (Input.GetMouseButtonUp (1)) {
			selected = false;
		}
		if (selected) {
			Vector3 mousePos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			mousePos.z = transform.position.z;
            if (!touchedOtherAntenna(mousePos))
                transform.position = worldMousePosition;
            else
                selected = false;
        }*/
	}
}
