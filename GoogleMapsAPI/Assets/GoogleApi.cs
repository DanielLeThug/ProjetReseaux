using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoogleApi : MonoBehaviour
{

    public RawImage img;

    string url;

    public float lat;
    public float lon;
    public float Speed = 0.0001f;

    LocationInfo li;

    public int zoom = 14;
    public int mapWidth = 640;
    public int mapHeight = 640;

    public enum mapType { roadmap, satellite, hybrid, terrain }
    public mapType mapSelected;
    public int scale;

    private float xDeg = 0.0f;
    private float yDeg = 0.0f;

    IEnumerator Map()
    {
        url = "https://maps.googleapis.com/maps/api/staticmap?center=" + lat + "," + lon +
            "&zoom=" + zoom + "&size=" + mapWidth + "x" + mapHeight + "&scale=" + scale
            + "&maptype=" + mapSelected +
            "&markers=color:blue%7Clabel:S%7C40.702147,-74.015794&markers=color:green%7Clabel:G%7C40.711614,-74.012318&markers=color:red%7Clabel:C%7C40.718217,-73.998284&key=AIzaSyBAOJnHA9Iy1fumJL8xTvxV4IHJy0YFuS8";
        WWW www = new WWW(url);
        yield return www;
        img.texture = www.texture;
        img.SetNativeSize();

    }
    // Use this for initialization
    void Start()
    {
        img = gameObject.GetComponent<RawImage>();
        StartCoroutine(Map());
    }

    void LateUpdate()
    {
        if (Input.GetMouseButton(0))
        {
            xDeg += Input.GetAxis("Mouse X") * Speed;
            yDeg += Input.GetAxis("Mouse Y") * Speed;
            lon -= xDeg;
            lat -= yDeg;
            StartCoroutine(Map());
        }
        if (!Input.GetMouseButton(0))
        {
            xDeg = 0.0f;
            yDeg = 0.0f;
        }
    }
}