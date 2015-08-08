using UnityEngine;
using System.Collections;

/***
 * Main Menu Controller
 * 
 * Basic navigation around the game.  Includes
 * instructions, Quit and level loading.
 */
public class MainMenuController : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
	
		// TODO: checek for saved games, and enable load if we have some
		LoadLevel();

		Debug.Log(System.Environment.Version);
		Debug.Log(System.Environment.OSVersion);
	}
	
	// Update is called once per frame
	void Update () {

	}

	// called before start.
	void Awake () {
	}

	private IEnumerable LoadLevel() {
		AsyncOperation async = Application.LoadLevelAsync("outside");
		yield return async;
		Debug.Log ("MM:Loading Level");	
	}

	public void StartGame() {
		// Load the first level!
		MissionManager.instance.StartGame();
		Application.LoadLevel("Level01");
	}
	
	public void QuitGame() {
		Debug.Log ("MM:Quit called");
		Application.Quit();
	}
	
	public void ShowInstructions() {
		Debug.Log ("MM:Instructions Opened");
		Application.LoadLevel("instructions");
	}

	public void ShowMainMenu() {
		// Load the main level!
		Debug.Log ("MM:Returning to main");
		Application.LoadLevel("main");
	}

	public void JumpToLevel(string levelName) {
		// Load the first level!
		Application.LoadLevel(levelName);
	}
	
	public void LoadGame() {

		Debug.Log ("MM:Load game called");
	}
}
