using UnityEngine;
using System.Collections.Generic;
using System.Collections;

/***
 * Mission manager controls the missions, what objectives you have are here, and
 * completing a mission/rewards and such are handled here as well.
 * 
 */
public class MissionManager : MonoBehaviour {

	const int BLOCKS_PER_ROW = 16;

	public enum GameStates { WaitingToStart, InProgress, LostGame, WonGame, Paused }

	public static MissionManager instance; 
	public static int lives = 3;
	public const int MAX_LIVES = 3;
	public static int score = 0;
	public static int totalBlocksLeft = 0;
	public static GameStates gameState = GameStates.WaitingToStart;

	public GameObject[] bricks;
	private GameObject ScoreText;

	// could load this from a config file of course, but, its a small
	// game and I'm the only one writing it.
	private enum Missions { Mission01, Mission02 };
	private Missions currentMission;

	private ArrayList levels;
	private int currentLevel = 0;
	
	// Use this for initialization
	void Init () {
		// load the current mission, or start at powerplant.
		currentMission = Missions.Mission01;
	}

	void Update() {
	}

	/***
	 * Awake 
	 * 
	 * we use Awake to make sure there is only one instance of this
	 * class ever, since we only need one, and it carries data.
	 */
	void Awake () {
		// There can be only 1. ;)
		if (instance == null) {
			DontDestroyOnLoad(gameObject);
			instance = this; // set the one that is allowed to exist to this one.

			SetupLevels();

		} else  {
			Destroy (gameObject);
		}
	}

	// Update is called once per frame
	void CompleteCurrentMision () {
//		switch (currentMission) {
//		case Missions.Mission01:
//			currentMission = Missions.Mission02;
//			break;
//		}
		// simple game, has no misssions :)

		// TODO: we should pause here, show a YOU Beat the level dialog.

		this.currentLevel++;
		if (this.currentLevel>levels.Count) {
			// you won!
			GameOver (true);
		}

		// move on to next level.
		StartNextLevel(); // already bumped level num.
	
	}

	private void StartNextLevel() {
		gameState = GameStates.WaitingToStart;
		DrawLevel(this.currentLevel);

	}

	public void StartGame () {
		score = 0;
		lives = MAX_LIVES;
		currentMission = Missions.Mission01;
		gameState = GameStates.WaitingToStart;
	}

	void OnLevelWasLoaded(int level) {
		if (level == 1) {
			// then this is the game level, so lets start it up! :)
			DrawLevel(this.currentLevel);
		}
	}
	
	public void GameOver(bool playerWon) {
		if (playerWon) {
			// won!
			GameObject.FindObjectOfType<MainMenuController>().JumpToLevel("game_over_win");

		} else {
			// lost
			GameObject.FindObjectOfType<MainMenuController>().JumpToLevel("game_over_lose");
		}
	}

	public static void GameStarted() {
		gameState = GameStates.InProgress;
	}

	public void LoseLife () {
		lives -= 1;
		if (lives <= 0 ) {
			GameOver(false);
		} else {
			// still going, get ready to play.
			gameState = GameStates.WaitingToStart;
		}
	}

	// level block setup
	public void DrawLevel(int levelID) {
		// find blocks obect for neatness :)
		// then parent the block to it.
		// TODO: ^^^^^^^^^^^^^^^^^^^^^^^
		GameObject blocksHolder = GameObject.FindGameObjectWithTag("BlockHolder");

		ArrayList thisLevelsBlocks = (ArrayList) levels[levelID];

		float xPos = 0.5f;
		float yPos = 0f;
		int index = 0;
		totalBlocksLeft=0;
		foreach (int blockType in thisLevelsBlocks) {

			if (blockType != -1) {			

				GameObject block;
				xPos = 0.5f + (index % BLOCKS_PER_ROW);
				yPos = 8.0f + (Mathf.Floor(index / BLOCKS_PER_ROW)*0.3f);
				Vector3 newPos = new Vector3(xPos, yPos,0);
				block = (GameObject) Instantiate(bricks[blockType], 
				                                 newPos, 
				                                 bricks[blockType].transform.rotation);
				if (blocksHolder != null) {
					block.transform.parent = blocksHolder.transform;
				}

				switch (blockType) {
				case 0: // skip
					break;
				case 1: // 1 hit block

					break;
				case 2: // 2 hit block
					break;
				case 3: // 3 hit block
					break;
				case 4: // special block!!
					break;
				}
				totalBlocksLeft++;
			}
			xPos += 1;
			index++;
		}
	}

	public void HitBrick() {
		score += 10;
	}

	public void BlockDestroyed() {
		totalBlocksLeft--;
		score += 20;

		if (totalBlocksLeft <= 0) {
			// won level!
			CompleteCurrentMision();		
		}
	}

	void SetupLevels(){
		levels = new ArrayList();

		// level 1
		ArrayList blocks = new ArrayList{
			-1,-1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,-1,-1,
			-1,-1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,-1,-1
		};
		levels.Add(blocks);

		// level 1
		ArrayList blocks2 = new ArrayList{
			 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0,
			-1,-1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,-1,-1
		};
		levels.Add(blocks2);

		// level 1
		ArrayList blocks3 = new ArrayList{
			0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0,
			0, 0, 1, 1, 1, 1, 2, 2, 2, 2, 1, 1, 1, 1, 0, 0,
			0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0
		};
		levels.Add(blocks3);


	}
}
