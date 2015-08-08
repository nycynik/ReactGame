using UnityEngine;
using System.Collections;

public class SoundPlayer : MonoBehaviour {

	public static SoundPlayer instance = null;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void Awake () {
		if (instance == null) {
			instance = this;
			GameObject.DontDestroyOnLoad(gameObject);
		} else {
			GameObject.Destroy(gameObject);
		}

	}
}
