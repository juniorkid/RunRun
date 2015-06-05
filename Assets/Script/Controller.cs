using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour {

	public GameObject m_player;

	public string m_pStatus;

	public bool m_hasDie;

	private GameObject[] m_grounds;
	public GameObject m_createFloor;

	// Use this for initialization
	void Start () {
		m_hasDie = false;
	}
	
	// Update is called once per frame
	void Update () {
	//	m_player = GameObject.FindWithTag ("Player");
		if (m_player != null) {
			m_pStatus = m_player.GetComponent<Player> ().GetStatus ();

	//		Debug.Log("Status : " + m_pStatus);

			if(m_pStatus == "Die"){
//					Debug.Log("DIEEEEEE");
					StartCoroutine (Die ());
			}
				
			else if(m_pStatus == "Fire"){	
//					Debug.Log("FIREEEEE");
					StartCoroutine(Fire()); 
			}

			else if(m_pStatus == "Normal"){	
//					Debug.Log("Normallllll");
					Normal();
			}
		}
	}

	IEnumerator Die(){
		m_createFloor.GetComponent<CreateFloor> ().SetStop (true);
		m_createFloor.GetComponent<CreateFloor> ().SetSpeedAll (0f);
		m_player.GetComponent<Player> ().m_hasJump = true;	
		m_player.GetComponent<Animator> ().SetBool ("die", true);
		//m_player.GetComponent<Play> ().NormalMode ();

		yield return new WaitForSeconds (.8f);

		m_player.GetComponent<SpriteRenderer>().enabled = false;

		yield break;

	}

	private IEnumerator Fire(){
	//	Debug.Log("Start FIREEEEE");

		m_createFloor.GetComponent<CreateFloor> ().SetSpeedAll (18);
		m_player.GetComponent<Animator>().SetBool("fire",true);

		yield return new WaitForSeconds(10f);

	//	Debug.Log ("STOP FIRE1");
		if (m_player.GetComponent<Player> ().GetStatus () != "Die") {
			m_player.GetComponent<Player> ().ChangeStatus ("Normal");
			m_player.GetComponent<Animator> ().SetBool ("fire", false);
			Normal ();
		}
	//	Debug.Log ("STOP FIRE2");

		yield break;
	}

	public float m_speed = 6f;

	void Normal(){
		m_createFloor.GetComponent<CreateFloor> ().SetSpeedAll (m_speed);
		StopAllCoroutines ();
	}


}
