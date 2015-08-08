using UnityEngine;
using System.Collections.Generic;
using System.Collections;

/***
 * Mission manager controls the missions, what objectives you have are here, and
 * completing a mission/rewards and such are handled here as well.
 * 
 */
public class MissionManager : MonoBehaviour {

	public enum GameStates { WaitingToStart, InProgress, LostGame, WonGame, Paused }

	public static MissionManager instance; 
	public static int lives = 3;
	public static GameStates gameState = GameStates.WaitingToStart;

	public ArrayList bricks;

	// could load this from a config file of course, but, its a small
	// game and I'm the only one writing it.
	private enum Missions { Mission01, Mission02 };
	Missions currentMission;

	private ArrayList levels;
	
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
			DrawLevel(0);

		} else if (instance != this) {
			print ("I Exist" + instance);
			Destroy (gameObject);
		}
	}

	// Update is called once per frame
	void CompleteCurrentMision () {
		switch (currentMission) {
		case Missions.Mission01:
			currentMission = Missions.Mission02;
			break;
		}
	}

	public void StartGame () {
		currentMission = Missions.Mission01;
		gameState = GameStates.WaitingToStart;
	}

	public static void GameOver(bool playerWon) {
		if (playerWon) {
			// won!

		} else {
			// lost

		}
	}

	public static void GameStarted() {
		gameState = GameStates.InProgress;
	}

	public void LoseLife () {
		lives -= 1;
		if (lives == 0 ) {
			GameOver(false);
		}
	}

	// level block setup
	void DrawLevel(int levelID) {
		ArrayList thisLevelsBlocks = level[levelID];

		for (int x=0; x<thisLevelsBlocks.Count; x++) {
			switch (thisLevelsBlocks[x]) {
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
		}
	}

	void SetupLevels(){
		levels = new ArrayList();

		ArrayList blocks = new ArrayList{0,1,1,2,2,1,1,0};

		levels.Add(blocks);
	}
}
