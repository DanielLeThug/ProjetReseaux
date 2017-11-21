using UnityEngine;
using System.Collections;

public class Tools : MonoBehaviour {

	public static float top() {
		return Camera.main.ViewportToWorldPoint (new Vector2 (0, 1)).y;
	}

	public static float left() {
		return Camera.main.ViewportToWorldPoint (new Vector2 (0, 1)).x;
	}

	public static float bottom() {
		return Camera.main.ViewportToWorldPoint (new Vector2 (1, 0)).y;
	}

	public static float right() {
		return Camera.main.ViewportToWorldPoint (new Vector2 (1, 0)).x;
	}

	public static Vector2 dimension() { // x = width, y = height
		return new Vector2 (right () - left (), top () - bottom ());
	}

	public static Vector2 center() {
		return new Vector2 ((right () + left ()) / 2, (top () + bottom ()) / 2);
	}

	public static Vector2 dimension(GameObject go) {
		Vector2 size = new Vector2 (
			go.GetComponent<SpriteRenderer> ().bounds.size.x,
			go.GetComponent<SpriteRenderer> ().bounds.size.y);
		return size;
	}

	// donne les dimensions d'une ressource par son tag
	public static Vector2 resourceSize(string tag) {
		GameObject g = Instantiate (Resources.Load (tag), Tools.center(), Quaternion.identity) as GameObject;
		Vector2 size = dimension (g);
		Destroy (g);
		return size;
	}

	public static float top(GameObject go) {
		return go.transform.position.y + go.GetComponent<SpriteRenderer> ().bounds.size.y / 2;
	}

	public static float bottom(GameObject go) {
		return go.transform.position.y - go.GetComponent<SpriteRenderer> ().bounds.size.y / 2;
	}

	public static float left(GameObject go) {
		return go.transform.position.x - go.GetComponent<SpriteRenderer> ().bounds.size.x / 2;
	}

	public static float right(GameObject go) {
		return go.transform.position.x + go.GetComponent<SpriteRenderer> ().bounds.size.x / 2;
	}

	public static bool inside(GameObject go, Vector2 point) {
		return point.y < top (go) && point.y > bottom (go) && point.x > left (go) && point.x < right (go);
	}

	public static void resize(GameObject go, Vector2 newSize) {
		go.transform.localScale = new Vector2 (1, 1);
		Vector2 currentSize = go.GetComponent<SpriteRenderer> ().bounds.size;
		go.transform.localScale = new Vector2 (newSize.x / currentSize.x, newSize.y / currentSize.y);
	}
}
