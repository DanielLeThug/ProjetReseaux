using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnitySlippyMap.Map;

public class Selection : MonoBehaviour {

    public GameObject SelectedAntenna;

    void Update()
    {
        if (Input.GetKey("escape"))
            Application.Quit();
        if (SelectedAntenna != null)
        {
            if (Input.GetKeyDown("up"))
            {
                SelectedAntenna.transform.position = new Vector3(SelectedAntenna.transform.position.x, SelectedAntenna.transform.position.y, SelectedAntenna.transform.position.z + 0.2f);
                SelectedAntenna.GetComponent<antennaData>().coloriser.transform.position = new Vector3(SelectedAntenna.transform.position.x, SelectedAntenna.transform.position.y, SelectedAntenna.transform.position.z + 0.2f);
                GameObject go = GameObject.FindGameObjectWithTag("map");
                MapBehaviour map = go.GetComponent<MapBehaviour>();
                AppStates.GetAntennaLocation(SelectedAntenna, map);
            }
            if (Input.GetKeyDown("down"))
            {
                SelectedAntenna.transform.position = new Vector3(SelectedAntenna.transform.position.x, SelectedAntenna.transform.position.y, SelectedAntenna.transform.position.z - 0.2f);
                SelectedAntenna.GetComponent<antennaData>().coloriser.transform.position = new Vector3(SelectedAntenna.transform.position.x, SelectedAntenna.transform.position.y, SelectedAntenna.transform.position.z - 0.2f);
                GameObject go = GameObject.FindGameObjectWithTag("map");
                MapBehaviour map = go.GetComponent<MapBehaviour>();
                AppStates.GetAntennaLocation(SelectedAntenna, map);
            }
            if (Input.GetKeyDown("left"))
            {
                SelectedAntenna.transform.position = new Vector3(SelectedAntenna.transform.position.x - 0.2f, SelectedAntenna.transform.position.y, SelectedAntenna.transform.position.z);
                SelectedAntenna.GetComponent<antennaData>().coloriser.transform.position = new Vector3(SelectedAntenna.transform.position.x - 0.2f, SelectedAntenna.transform.position.y, SelectedAntenna.transform.position.z);
                GameObject go = GameObject.FindGameObjectWithTag("map");
                MapBehaviour map = go.GetComponent<MapBehaviour>();
                AppStates.GetAntennaLocation(SelectedAntenna, map);
            }
            if (Input.GetKeyDown("right"))
            {
                SelectedAntenna.transform.position = new Vector3(SelectedAntenna.transform.position.x + 0.2f, SelectedAntenna.transform.position.y, SelectedAntenna.transform.position.z);
                SelectedAntenna.GetComponent<antennaData>().coloriser.transform.position = new Vector3(SelectedAntenna.transform.position.x + 0.2f, SelectedAntenna.transform.position.y, SelectedAntenna.transform.position.z);
                GameObject go = GameObject.FindGameObjectWithTag("map");
                MapBehaviour map = go.GetComponent<MapBehaviour>();
                AppStates.GetAntennaLocation(SelectedAntenna, map);
            }
            if (Input.GetKeyDown(KeyCode.P))
            {
                float newPower = SelectedAntenna.GetComponent<antennaData>().power + 50f;
                SelectedAntenna.GetComponent<antennaData>().setPower(newPower);
            }
            if (Input.GetKeyDown(KeyCode.M))
            {
                float newPower = SelectedAntenna.GetComponent<antennaData>().power - 50f;
                SelectedAntenna.GetComponent<antennaData>().setPower(newPower);
            }
            if (Input.GetKeyDown(KeyCode.O))
            {
                int newFrequency = SelectedAntenna.GetComponent<antennaData>().frequency + 1;
                SelectedAntenna.GetComponent<antennaData>().frequency = newFrequency;
            }
            if (Input.GetKeyDown(KeyCode.L))
            {
                int newFrequency = SelectedAntenna.GetComponent<antennaData>().frequency - 1;
                SelectedAntenna.GetComponent<antennaData>().frequency = newFrequency;
            }
        }    
    }

}
