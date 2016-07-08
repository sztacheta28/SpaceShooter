using UnityEngine;
using System.Collections;

public class DamageHandler : MonoBehaviour {

	public int health = 1;

	public string[] enemyTag;

	public bool bonusGenerator;

	public GameObject bonusShootingPrefab;

	void OnTriggerEnter2D(Collider2D other) {
		for(int i=0; i<enemyTag.Length; ++i){
			if(other.gameObject.tag == enemyTag[i]){
				--health;
				break;
			}
		}
	}

	void Update() {
		if(health <= 0) {
			Die();
		}
	}

	void Die() {
		if(bonusGenerator){
			if(Random.Range(0, 5) == 0){
				Instantiate(bonusShootingPrefab, transform.position, Quaternion.identity);
			}
		}
		Destroy(gameObject);
	}

}
