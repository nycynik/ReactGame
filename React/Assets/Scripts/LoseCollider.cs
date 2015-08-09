using UnityEngine;
using System.Collections;

public class LoseCollider : MonoBehaviour {


	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D (Collider2D collider) {

		switch (collider.name) {
			case "GameBall":
			MissionManager.instance.LoseLife();
				break;
		}
	}

	void OnCollisionEnter2D (Collision2D collision) {
		Debug.Log ("life lost");
	}
}
