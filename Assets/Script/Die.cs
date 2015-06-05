using UnityEngine;
using System.Collections;

public class Die : MonoBehaviour {
	
	// Use this for initialization
	void OnTriggerEnter2D(Collider2D obj) {
		SetDieFall (obj);
	}

	void OnTriggerStay2D(Collider2D obj) {
		SetDieFall (obj);
	}

	private void SetDieFall(Collider2D obj){
		if (obj.name == "Player" ) {
			obj.GetComponent<Player> ().ChangeStatus ("Die");
		}
	}

	void OnCollisionEnter2D(Collision2D coll) {
		SetDieStone (coll);
	}

	void OnCollisionStay2D(Collision2D coll) {
		SetDieStone (coll);
	}

	private void SetDieStone(Collision2D coll){
		if (coll.gameObject.GetComponent<Player> ().GetStatus() == "Normal" && coll.gameObject.name == "Player" && gameObject.tag == "Stone")
			coll.gameObject.GetComponent<Player> ().ChangeStatus ("Die");
	}
}
