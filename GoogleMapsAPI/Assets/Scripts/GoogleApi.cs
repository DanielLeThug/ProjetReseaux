using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoogleApi : MonoBehaviour
{
	public SpriteRenderer sr;
	string url;

	public float lat = 100;
	public float lon = 100;
	public float Speed = 0.0001f;
	public int zoom = 14;
	public int mapWidth = 640;
	public int mapHeight = 640;
	public int scale = 2;

	LocationInfo li;
	public enum mapType { roadmap, satellite, hybrid, terrain }
	public mapType mapSelected = mapType.roadmap;

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

		sr.sprite = Sprite.Create(www.texture, new Rect(0, 0, www.texture.width, www.texture.height), new Vector2(0.5f, 0.5f), 100f);
		//Tools.resize(gameObject, new Vector2(Tools.dimension().x, Tools.dimension().y));
	}

	void Start()
	{
		sr = gameObject.GetComponent<SpriteRenderer>();
		StartCoroutine(Map());
		transform.position = new Vector3 (0, 0, 10);
	}

	void LateUpdate()
	{
		if (Input.GetMouseButton(0))
		{
			xDeg += Input.GetAxis("Mouse X") * Speed;	
			yDeg += Input.GetAxis("Mouse Y") * Speed;
			lon -= xDeg;
			lat -= yDeg;
		}
		else if (Input.GetMouseButtonDown (0))
		{
			StartCoroutine(Map());
		}
		else
		{
			xDeg = 0.0f;
			yDeg = 0.0f;
		}
	}
}