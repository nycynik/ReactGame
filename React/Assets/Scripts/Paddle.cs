using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {

	private GameBallController gameBall;

	Vector3 paddleToBallVector;

	// Use this for initialization
	void Start () {
		gameBall = GameObject.FindObjectOfType<GameBallController>();
		paddleToBallVector = gameBall.transform.position - this.transform.position;
	}
	
	// Update is called once per frame
	void Update () {

		// == Move the paddle.
		// mouse controls
		float relativeMouseXPosition = Input.mousePosition.x / Screen.width;
		float mouseGameWordXPosition = Mathf.Clamp(relativeMouseXPosition * 16, 0.5f,15.5f);; // 16 world units wide.		
		this.transform.position = new Vector3(mouseGameWordXPosition,this.transform.position.y,this.transform.position.z);

		if (MissionManager.gameState == MissionManager.GameStates.WaitingToStart) {
			gameBall.transform.position = this.transform.position + paddleToBallVector; // ball position
		}

		// keyboard controls
		if (Input.GetKeyDown(KeyCode.A)) { // move left

		} else if (Input.GetKeyDown(KeyCode.D)) { // move right

		} else if (Input.GetKeyDown(KeyCode.Space) || (Input.GetMouseButtonDown(0))) {
			if (MissionManager.gameState == MissionManager.GameStates.WaitingToStart) {
				MissionManager.GameStarted();
				// move ball for the first time.
				Rigidbody2D gameBallBody = gameBall.GetComponentInParent<Rigidbody2D>();
				gameBallBody.velocity = new Vector2(10f, 12f);
			} else {
				// Bump it up.
				print ("blump it up!");

			}

		}





	}
}
