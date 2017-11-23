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
		}
		return color;
	}

	private float powerAlpha(Vector2 antennaPosition, float antennaPower) {
		Vector2 a = transform.position;
		Vector2 b = antennaPosition;
		float distance = Mathf.Sqrt (Mathf.Pow (b.x - a.x, 2) + Mathf.Pow (b.y - a.y, 2));
		return 1 - ((distance / antennaPower) * 5);
	}

	void OnTriggerEnter2D(Collider2D collision) {
        Waves wave = new Waves();
        wave.antenna = collision.gameObject;

        GameObject white = Instantiate(Resources.Load("white"), Vector2.right, Quaternion.identity) as GameObject;
        Tools.resize(white, GetComponent<SpriteRenderer>().bounds.size);

        white.transform.parent = gameObject.transform;
        white.transform.localPosition = new Vector3(0, 0, 0);

        //white.transform.position = new Vector3(transform.position.x, transform.position.y, -wave.antenna.GetComponent<antennaData>().frequency - 1);

        white.GetComponent<SpriteRenderer>().color = frequencyColor(wave.antenna.GetComponent<antennaData>().frequency);
        wave.coloration = white;

        waves.Add(wave);
    }

	void OnTriggerExit2D(Collider2D other) {
        for (int i = 0; i < waves.Count; i++)
        {
            if (waves[i].antenna == other.gameObject)
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
                float alpha = powerAlpha(waves[i].antenna.transform.position, waves[i].antenna.GetComponent<CircleCollider2D>().radius);
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



            /*foreach (Waves wave in waves)
            {
                Color color = wave.coloration.GetComponent<SpriteRenderer>().color;
                color.a = powerAlpha(wave.antenna.transform.position, wave.antenna.GetComponent<CircleCollider2D>().radius);
                wave.coloration.GetComponent<SpriteRenderer>().color = color;
            }*/

        }
    }
}

public struct Waves
{
    public GameObject antenna;
    public GameObject coloration;
}