using UnityEngine;
using System.Collections;

public class GameBallController : MonoBehaviour {
	
	private int clicksSinceBrick = 0;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnCollisionEnter2D(Collision2D coll) {

		clicksSinceBrick++;

		// ball will not sound when hitting a brick that is going away. LOL.
		if (MissionManager.gameState == MissionManager.GameStates.InProgress) 
			this.GetComponent<AudioSource>().Play();

		// just to be sure the ball does not get stuck, we mess with it a bit. :)
		// this is a mess, we need to improve this a LOT.
		if (clicksSinceBrick > 5) {
			clicksSinceBrick = 0;
			Vector2 curVelocity = GetComponent<Rigidbody2D>().velocity;

			float xVec = Random.Range(1f,3f) * Mathf.Sign(curVelocity.x);
			float yVec = Random.Range(1f,3f) * Mathf.Sign(curVelocity.y);
			Vector2 ballAdjustment = new Vector2(xVec, yVec);
			GetComponent<Rigidbody2D>().velocity += ballAdjustment;
		}
	}
	
}
