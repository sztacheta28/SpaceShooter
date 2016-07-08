using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

	public GameObject[] enemyPrefab;

	float shipBoundaryRadius = 0.5f;

	float spawnDistance = 6f;

	float enemyRate = 3f;
	float nextEnemy = 1f;
	
	void Update () {
		nextEnemy -= Time.deltaTime;

		if(nextEnemy <= 0f) {
			nextEnemy = enemyRate;
			enemyRate *= 0.95f;
			if(enemyRate < 0.30f)
				enemyRate = 0.30f;

			// Now calculate the orthographic width based on the screen ratio
			float screenRatio = (float)Screen.width / (float)Screen.height;
			float widthOrtho = Camera.main.orthographicSize * screenRatio;

			float max = widthOrtho - shipBoundaryRadius;
			float min = -widthOrtho + shipBoundaryRadius;

			Vector3 pos = new Vector3(Random.Range(min, max), spawnDistance, 0f);

			Instantiate(enemyPrefab[Random.Range(0, enemyPrefab.Length)], pos, Quaternion.identity);
		}
	}
}
