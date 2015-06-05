using UnityEngine;
using System.Collections;

public class SpeedUp : MonoBehaviour {

	// Change player to Fire Mode
	void OnTriggerEnter2D(Collider2D obj) {
		if (obj.name == "Player" && obj.GetComponent<Player>().GetStatus() != "Fire" && obj.GetComponent<Player>().GetStatus() != "DuringFire") {
			obj.GetComponent<Player> ().ChangeStatus ("Fire");
			gameObject.transform.position = new Vector3 (-23f , 0f, 0f);
		}
	}
}
