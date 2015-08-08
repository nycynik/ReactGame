using UnityEngine;
using System.Collections;

public class LoseCollider : MonoBehaviour {

	private MainMenuController mmc;

	// Use this for initialization
	void Start () {
		mmc = GameObject.FindObjectOfType<MainMenuController>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D (Collider2D collider) {

		switch (collider.name) {
			case "GameBall":
			mmc.JumpToLevel("game_over_win");
				break;
		}
	}

	void OnCollisionEnter2D (Collision2D collision) {
		Debug.Log ("life lost");
	}
}
