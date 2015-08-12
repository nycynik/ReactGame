using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {

	private GameBallController gameBall;
	public bool AutoPlay;

	private Vector3 paddleToBallVector;

	public Vector3 paddleInitialPosition;
	public Vector3 newPosition;
	private float distance = 5;
	private float speed = 1;
	public bool moving = false;

	// Use this for initialization
	void Start () {
		gameBall = GameObject.FindObjectOfType<GameBallController>();
		paddleToBallVector = gameBall.transform.position - this.transform.position;
	}
	
	// Update is called once per frame
	void Update () {

		newPosition = transform.position;

		// == Move the paddle.
		if (!AutoPlay) {

			// mouse controls
			float relativeMouseXPosition = Input.mousePosition.x / Screen.width;
			float mouseGameWordXPosition = Mathf.Clamp(relativeMouseXPosition * 16, 0.5f,15.5f);; // 16 world units wide.		
			this.transform.position = new Vector3(mouseGameWordXPosition,this.transform.position.y,this.transform.position.z);
		} else {
			// demo mode it up.
			this.transform.position = new Vector3(gameBall.transform.position.x,this.transform.position.y,this.transform.position.z);

		}

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
				gameBallBody.velocity = new Vector2(6f, 8f);
			} else {
				// Bump it up.
				paddleInitialPosition = transform.position;
				newPosition = new Vector3(transform.position.x-2f, transform.position.y, transform.position.z);

				print ("bump it up!");
				moving = true;

			}

		}

//		if (moving)
//			transform.position = transform.position + 
//				(transform.up*(Mathf.PingPong(Time.time*distance*speed + (distance*speed/2), distance*2)-distance));


	}
	
}
