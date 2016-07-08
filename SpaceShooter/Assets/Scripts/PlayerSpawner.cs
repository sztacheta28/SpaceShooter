using UnityEngine;
using System.Collections;

public class PlayerSpawner : MonoBehaviour {

	public GameObject playerPrefab;
	GameObject playerInstance;

	float shipBoundaryRadius = 0.5f;

	public int numLives = 4;

	float respawnTimer;

	bool firstTime = true;

	bool flashing;

	float rekord;

	public Texture againBtn;
	
	void Start () {
		rekord = PlayerPrefs.GetFloat("scores");
		Time.timeScale = 1f;
		SpawnPlayer();
	}

	IEnumerator SpawnPlayer() {
		numLives--;
		respawnTimer = 0.5f;
		Bonuses.shootingLevel = 0;

		Vector3 pos = new Vector3(transform.position.x, -4f, transform.position.z+10);
		playerInstance = (GameObject)Instantiate(playerPrefab, pos, Quaternion.identity);
		playerInstance.GetComponent<Transform>().parent = transform;

		if(!firstTime){
			flashing = true;
			playerInstance.GetComponent<Collider2D>().enabled = false;

			yield return new WaitForSeconds(3);

			flashing = false;
			playerInstance.GetComponent<Collider2D>().enabled = true;
			playerInstance.GetComponent<SpriteRenderer>().enabled = true;
		}
		firstTime = false;
	}

	void Update () {
		if(playerInstance == null && numLives > 0f) {
			respawnTimer -= Time.deltaTime;

			if(respawnTimer <= 0f) {
				StartCoroutine("SpawnPlayer");
			}
		}

		if(flashing){
			playerInstance.GetComponent<SpriteRenderer>().enabled = !playerInstance.GetComponent<SpriteRenderer>().enabled;
		}
	}

	void OnGUI() {
		///do usunięcia później
		//if(GUI.Button( new Rect(0.2f*Screen.width , 0.15f*Screen.height, 0.6f*Screen.width, 0.10f*Screen.height), "Zagraj ponownie")){
		//	Application.LoadLevel(Application.loadedLevel);
		//}
		//////////////////////////////

		if(numLives > 0 || playerInstance != null) {
			GUI.Label( new Rect(0, 0, 100, 50), "Pozostałe życia: " + numLives);
		}
		else {
			GUI.Label( new Rect( Screen.width/2 - 75 , Screen.height/2 - 75, 150, 50), "Przegrałeś!");
			GUI.Label( new Rect( Screen.width/2 - 75 , Screen.height/2 - 25, 150, 50), "Twój wynik: "+Scores.score);
			if(rekord < Scores.score){
				GUI.Label( new Rect( Screen.width/2 - 75 , Screen.height/2 + 25, 150, 50), "Pobiłeś rekord!");
				PlayerPrefs.SetFloat("scores", Scores.score);
			}else{
				GUI.Label( new Rect( Screen.width/2 - 75 , Screen.height/2 + 25, 150, 50), "Rekord to: "+rekord);
			}

			Time.timeScale = 0f;

			if(GUI.Button( new Rect(0.2f*Screen.width , 0.15f*Screen.height, 0.6f*Screen.width, 0.10f*Screen.height), againBtn, "")){
				Application.LoadLevel(Application.loadedLevel);
			}
		}
	}
}
