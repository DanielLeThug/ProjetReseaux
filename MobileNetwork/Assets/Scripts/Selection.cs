﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selection : MonoBehaviour {

    public GameObject SelectedAntenna;

    void Update()
    {
        if (SelectedAntenna != null)
        {
            if (Input.GetKeyDown("up"))
            {
                SelectedAntenna.transform.position = new Vector3(SelectedAntenna.transform.position.x, SelectedAntenna.transform.position.y, SelectedAntenna.transform.position.z + 0.2f);
                SelectedAntenna.GetComponent<antennaData>().coloriser.transform.position = new Vector3(SelectedAntenna.transform.position.x, SelectedAntenna.transform.position.y, SelectedAntenna.transform.position.z + 0.2f);
            }
            if (Input.GetKeyDown("down"))
            {
                SelectedAntenna.transform.position = new Vector3(SelectedAntenna.transform.position.x, SelectedAntenna.transform.position.y, SelectedAntenna.transform.position.z - 0.2f);
                SelectedAntenna.GetComponent<antennaData>().coloriser.transform.position = new Vector3(SelectedAntenna.transform.position.x, SelectedAntenna.transform.position.y, SelectedAntenna.transform.position.z - 0.2f);
            }
            if (Input.GetKeyDown("left"))
            {
                SelectedAntenna.transform.position = new Vector3(SelectedAntenna.transform.position.x - 0.2f, SelectedAntenna.transform.position.y, SelectedAntenna.transform.position.z);
                SelectedAntenna.GetComponent<antennaData>().coloriser.transform.position = new Vector3(SelectedAntenna.transform.position.x - 0.2f, SelectedAntenna.transform.position.y, SelectedAntenna.transform.position.z);
            }
            if (Input.GetKeyDown("right"))
            {
                SelectedAntenna.transform.position = new Vector3(SelectedAntenna.transform.position.x + 0.2f, SelectedAntenna.transform.position.y, SelectedAntenna.transform.position.z);
                SelectedAntenna.GetComponent<antennaData>().coloriser.transform.position = new Vector3(SelectedAntenna.transform.position.x + 0.2f, SelectedAntenna.transform.position.y, SelectedAntenna.transform.position.z);
            }
        }    
    }

}
