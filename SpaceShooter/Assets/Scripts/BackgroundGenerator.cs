using UnityEngine;
using System.Collections;

public class BackgroundGenerator : MonoBehaviour {
	bool generated = false;

	public GameObject backgroundPrefab;

	void Update () {
		if(!generated){
			if(transform.position.y < 0f){
				Instantiate(backgroundPrefab, new Vector3(0f, 10.45f, 0f), Quaternion.identity);
				generated = true;
			}
		}
	}
}
