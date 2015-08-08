using UnityEngine;
using System;
using System.Collections;

public class MisssionData : MonoBehaviour {

	public static MisssionData md;

	public int CurrentRoom;
	public int CurrentState;
	public int Score;

	// Use this for initialization
	void Start () {

	}

	void Awake () {
		// There can be only 1. ;)
		if (md == null) {
			DontDestroyOnLoad(gameObject);
			md = this; // set the one that is allowed to exist to this one.
		} else if (md != this) {
			Destroy (gameObject);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI() {

		GUI.Label(new Rect(10,10,100,30), "Score: "+Score);

	}

	public void Save() {
		// create file
//		string dir = Application.persistentDataPath + "/Config";
//		if (!Directory.Exists (dir)) {
//			Directory.CreateDirectory (dir);
//		}
//		string configFile = dir + "/config.ini";
//		if (!File.Exists (configFile)) {
//			File.Create (qcarFile);
//		}

//		FileStream file = File.Create(Application.persistentDataPath+"/playerinfo.dat");

		// serialize data, and push it
//		BinaryFormatter bf = new BinaryFormatter();

	}

	public void Load() {
//		FileStream file = File.Open(Application.persistentDataPath+"/playerinfo.dat", FileMode.Open);

	}

}
