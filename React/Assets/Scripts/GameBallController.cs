using UnityEngine;
using System.Collections;

public class GameBallController : MonoBehaviour {
	

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnCollisionEnter2D(Collision2D coll) {

		// ball will not sound when hitting a brick that is going away. LOL.
		if (MissionManager.gameState == MissionManager.GameStates.InProgress) 
			this.GetComponent<AudioSource>().Play();

		// just to be sure the ball does not get stuck, we mess with it a bit. :)
		Vector2 ballAdjustment = new Vector2(Random.Range(0f,2f), Random.Range(0f,2f));
		print (GetComponent<Rigidbody2D>().velocity);
		GetComponent<Rigidbody2D>().velocity += ballAdjustment;
		print (GetComponent<Rigidbody2D>().velocity);

	}
	
}
