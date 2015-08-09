using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Score : MonoBehaviour {

	public Text score;
	public Text lives;

	public void SetScore(string text) {
		score.text = text;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (score != null)
			score.text = "Score " + MissionManager.score.ToString().PadLeft(6, '0');

		if (lives != null)
			lives.text = MissionManager.lives.ToString() + " Lives";
	}
}
