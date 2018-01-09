using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class getInfos : MonoBehaviour
{
    private Image customImage;

    private void Start()
    {
        customImage = FindObjectOfType<Image>();
    }

    private void OnMouseOver()
    {
        customImage.enabled = true;
    }

    private void OnMouseExit()
    {
        customImage.enabled = false;
    }
}
