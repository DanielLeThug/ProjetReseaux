﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class getInfos : MonoBehaviour
{
    private Image customImage;
    private Text customText;

    private void Start()
    {
        customImage = FindObjectOfType<Image>();
        customText = FindObjectOfType<Text>();
    }

    private void OnMouseOver()
    {
        customText.text = "Position : (x : " + transform.position.x + ", y : " + transform.position.x + ")\n" +
            "Fréquence : " + GetComponent<antennaData>().frequency + "\nPuissance : " + GetComponent<antennaData>().power;
        customImage.enabled = true;
        customText.enabled = true;
    }

    private void OnMouseExit()
    {
        customImage.enabled = false;
        customText.enabled = false;
    }
}