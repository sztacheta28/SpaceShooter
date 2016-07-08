using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public float maxSpeed = 5f;
	public float rotSpeed = 180f;

	float shipBoundaryRadius = 0.5f;

	public Texture leftBtn;	
	public Texture rightBtn;

	int factor = 0;

	void Update () {

		// ROTATE the ship.

		// Grab our rotation quaternion
		Quaternion rot = transform.rotation;

		// MOVE the ship.
		Vector3 pos = transform.position;
		 
		Vector3 velocity = new Vector3(factor * maxSpeed * Time.deltaTime, 0, 0);

		pos += rot * velocity;

		// RESTRICT the player to the camera's boundaries!

		// First to vertical, because it's simpler
		if(pos.y+shipBoundaryRadius > Camera.main.orthographicSize) {
			pos.y = Camera.main.orthographicSize - shipBoundaryRadius;
		}
		if(pos.y-shipBoundaryRadius < -Camera.main.orthographicSize) {
			pos.y = -Camera.main.orthographicSize + shipBoundaryRadius;
		}

		// Now calculate the orthographic width based on the screen ratio
		float screenRatio = (float)Screen.width / (float)Screen.height;
		float widthOrtho = Camera.main.orthographicSize * screenRatio;

		// Now do horizontal bounds
		if(pos.x+shipBoundaryRadius > widthOrtho) {
			pos.x = widthOrtho - shipBoundaryRadius;
		}
		if(pos.x-shipBoundaryRadius < -widthOrtho) {
			pos.x = -widthOrtho + shipBoundaryRadius;
		}

		// Finally, update our position!!
		transform.position = pos;
	}

	void OnGUI(){
		factor = 0;

		if (GUI.RepeatButton(new Rect(0, 0.85f*Screen.height, 0.15f*Screen.height, 0.15f*Screen.height), leftBtn, "")){
			factor = -1;
		}

		if (GUI.RepeatButton(new Rect(Screen.width-0.15f*Screen.height, 0.85f*Screen.height, 0.15f*Screen.height, 0.15f*Screen.height), rightBtn, "")){
			factor = 1;
		}
	}
}