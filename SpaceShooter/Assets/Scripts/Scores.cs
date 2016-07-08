using UnityEngine;
using System.Collections;

public class Scores : MonoBehaviour {
	public static float score = 0;

	void Start(){
		score = 0;
	}

	void Update (){
		score += Time.deltaTime;
	}

	void OnGUI(){
		GUI.skin.label.fontSize = 17;
		GUI.Label(new Rect(Screen.width-0.2f*Screen.height, 0f, 0.2f*Screen.height, 0.1f*Screen.height), "Dystans: "+score.ToString("F2"));
	}
}
