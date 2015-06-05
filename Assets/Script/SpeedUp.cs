using UnityEngine;
using System.Collections;

public class SpeedUp : MonoBehaviour {
	

	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter2D(Collider2D obj) {
		if (obj.name == "Player") {
			obj.GetComponent<Player> ().ChangeStatus ("Fire");
			gameObject.transform.position = new Vector3 (-23f , 0f, 0f);
		}
	}
}
