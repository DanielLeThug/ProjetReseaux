using UnityEngine;
using System.Collections.Generic;

public class reception : MonoBehaviour {

    private List<Waves> waves = new List<Waves>();

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
        case 6:
			color = new Color(0, 255, 255);
            break;
        }
		return color;
	}

    // Power density of the tile
	private float powerAlpha(Vector3 antennaPosition, float antennaPower) {
		Vector3 a = transform.position;
		Vector3 b = antennaPosition;
        float distanceaucarre = Mathf.Pow(b.x - a.x, 2) + Mathf.Pow(b.z - a.z, 2);
        return antennaPower * 0.7f / (4 * Mathf.PI * distanceaucarre);
    }

    // Max power density of an antenna
    private float powerAlphaMax(GameObject go, float antennaPower) {
        Vector2 size = Tools.dimension(go);
        float tile_size = size.x;
        float distanceminaucarre = Mathf.Pow(tile_size, 2) + Mathf.Pow(tile_size, 2);
        return antennaPower * 0.7f / (4 * Mathf.PI * distanceminaucarre);
    }

	void OnTriggerEnter(Collider collision) {
        Waves wave = new Waves();
        wave.antenna = collision.gameObject.GetComponent<getAntenna>().source;

        GameObject white = Instantiate(Resources.Load("white"), Vector2.right, Quaternion.identity) as GameObject;
        Tools.resize(white, GetComponent<SpriteRenderer>().bounds.size);

        white.transform.parent = gameObject.transform;
        white.transform.localPosition = new Vector3(0, 0, 0);

        white.GetComponent<SpriteRenderer>().color = frequencyColor(wave.antenna.GetComponent<antennaData>().frequency);
        wave.coloration = white;

        white.transform.rotation = new Quaternion(0, 0, 0, 0);
        white.transform.localScale = new Vector3(1, 1, 0);
        waves.Add(wave);
    }

	void OnTriggerExit(Collider other) {
        for (int i = 0; i < waves.Count; i++)
        {
            if (waves[i].antenna == other.gameObject.GetComponent<getAntenna>().source)
            {
                Destroy(waves[i].coloration);
                waves.RemoveAt(i);
                break;
            }
        }
    }

	void Start() {
	}

	void Update() {
        if (waves.Count > 0)
        {
            int bestWave = 0;
            float bestPower = 0;
            Color color;
            for (int i = 0; i < waves.Count; i++)
            {
                GameObject[] gos = GameObject.FindGameObjectsWithTag("test");
                float alpha_max = powerAlphaMax(gos[0], waves[i].antenna.GetComponent<SphereCollider>().radius);
                float alpha = powerAlpha(waves[i].antenna.transform.position, waves[i].antenna.GetComponent<SphereCollider>().radius);
                alpha /= alpha_max; // We need a value between 0 and 1 for the opacity
                if (alpha > bestPower)
                {
                    bestPower = alpha;
                    bestWave = i;
                }
            }
            for(int i = 0; i < waves.Count; i++)
            {
                color = waves[i].coloration.GetComponent<SpriteRenderer>().color;
                if (i == bestWave)
                    color.a = bestPower;
                else
                    color.a = 0;
                waves[i].coloration.GetComponent<SpriteRenderer>().color = color;

            }

        }
    }
}

public struct Waves
{
    public GameObject antenna;
    public GameObject coloration;
}