using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {

	private int MaxHits;
	private int timesHit;
	private bool isUnbreakable;
	public Sprite[] bricks;
	public AudioClip brickBreakSound;

	// Use this for initialization
	void Start () {
		timesHit=0;
		MaxHits=bricks.Length + 1;
	}

	void Awake() {
		isUnbreakable = (this.tag == "unbreakable");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D coll) {

		this.timesHit++;
		if (!isUnbreakable) {

			MissionManager.instance.HitBrick();

			// delete if it's gone
			if (this.timesHit >= this.MaxHits) {
				Destroy(gameObject);
				MissionManager.instance.BlockDestroyed();

			} else { // update sprite
				UpdateBrickSprite();
			}

	//		if (coll.gameObject.tag == "Enemy")
	//			coll.gameObject.SendMessage("ApplyDamage", 10);
		}
		AudioSource.PlayClipAtPoint (brickBreakSound, transform.position);
	} 

	void UpdateBrickSprite() {
		int brickIndex=timesHit - 1;
		if (bricks[brickIndex]) {
			SpriteRenderer sr = this.GetComponent<SpriteRenderer>();
			sr.sprite = bricks[brickIndex];
		}
	}
}
