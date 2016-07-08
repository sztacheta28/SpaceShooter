using UnityEngine;
using System.Collections;

public class PlayerShooting : MonoBehaviour {

	public Vector3 bulletOffset = new Vector3(0f, 0.5f, 0f);

	public GameObject bulletPrefab;

	public float fireDelay = 0.25f;
	float cooldownTimer = 0f;
	
	void Update () {
		cooldownTimer -= Time.deltaTime;

		if(cooldownTimer <= 0 ) {
			cooldownTimer = fireDelay;

			Vector3 offset = transform.rotation * bulletOffset;

			if(Bonuses.shootingLevel == 0){
				Instantiate(bulletPrefab, transform.position + offset, transform.rotation);
			}else if(Bonuses.shootingLevel == 1){
				Instantiate(bulletPrefab, transform.position + offset-new Vector3(0.05f, 0f, 0f), transform.rotation);
				Instantiate(bulletPrefab, transform.position + offset+new Vector3(0.05f, 0f, 0f), transform.rotation);
			}else if(Bonuses.shootingLevel == 2){
				Instantiate(bulletPrefab, transform.position + offset-new Vector3(0.1f, 0f, 0f), Quaternion.Euler(0, 0, 1));
				Instantiate(bulletPrefab, transform.position + offset, transform.rotation);
				Instantiate(bulletPrefab, transform.position + offset+new Vector3(0.1f, 0f, 0f), Quaternion.Euler(0, 0, -1));
			}else if(Bonuses.shootingLevel > 2){
				Instantiate(bulletPrefab, transform.position + offset-new Vector3(0.1f, 0f, 0f), Quaternion.Euler(0, 0, 5));
				Instantiate(bulletPrefab, transform.position + offset-new Vector3(0.05f, 0f, 0f), transform.rotation);
				Instantiate(bulletPrefab, transform.position + offset+new Vector3(0.05f, 0f, 0f), transform.rotation);
				Instantiate(bulletPrefab, transform.position + offset+new Vector3(0.1f, 0f, 0f), Quaternion.Euler(0, 0, -5));
			}
		}
	}
}
