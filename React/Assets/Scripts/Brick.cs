using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {

	public int MaxHits;
	private int timesHit;

	// Use this for initialization
	void Start () {
		timesHit=0;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D coll) {

		this.timesHit++;
		if (this.timesHit >= this.MaxHits) {
			Destroy(gameObject);
		}

		if (coll.gameObject.tag == "Enemy")
			coll.gameObject.SendMessage("ApplyDamage", 10);
		print ("collided");
		
	} 
}
