using UnityEngine;
using System.Collections;

public class Bonuses : MonoBehaviour {
	public static int shootingLevel = 0;

	void OnTriggerEnter2D(Collider2D other) {
		if(other.gameObject.tag == "BonusShooting"){
			++shootingLevel;
		}
	}
}
