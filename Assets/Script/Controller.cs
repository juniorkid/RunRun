using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour {

	public GameObject m_player;

	public string m_pStatus;

	public bool m_hasDie;

	public float m_speed = 6f;

	public GameObject m_restartButton;

	private GameObject[] m_grounds;
	public GameObject m_createFloor;

	// Use this for initialization
	void Start () {
		m_hasDie = false;
	//	StartCoroutine (Die ());
	}
	
	// Update is called once per frame
	void Update () {
		ChangePlayerMode ();
	}

	// Player Die mode
	private IEnumerator Die(){

		while (m_pStatus != "Die");

		m_createFloor.GetComponent<CreateFloor> ().SetSpeedAll (0f);
		m_player.GetComponent<Player> ().m_hasJump = true;	
		m_player.GetComponent<Animator> ().SetBool ("die", true);

		yield return new WaitForSeconds (.5f);

	//	Instantiate (m_restartButton, new Vector3 ( -0.2f, 0.587f, 0), Quaternion.identity);
	//	m_player.SetActive (false);
	}

	// Player Fire mode
	private IEnumerator Fire(){

		Debug.Log ("Start Fire");
		m_player.GetComponent<Player> ().ChangeStatus ("DuringFire");
		m_player.GetComponent<Animator>().SetBool("fire",true);
		m_player.GetComponent<Player>().FireMode ();
		yield return new WaitForSeconds(10f);
		
		if (m_player.GetComponent<Player> ().GetStatus () != "Die") {
			m_player.GetComponent<Player> ().ChangeStatus ("Normal");
			m_player.GetComponent<Animator> ().SetBool ("fire", false);
			Normal ();
		}

		Debug.Log ("Stop Fire");

		yield break;
	}

	private void DuringFire(){
		m_createFloor.GetComponent<CreateFloor> ().SetSpeedAll (18);
	}

	// Player Normal mode
	void Normal(){
		m_createFloor.GetComponent<CreateFloor> ().SetSpeedAll (m_speed);
		m_player.GetComponent<Player>().NormalMode ();
	}

	private void ChangePlayerMode(){
		if (m_player != null) {
			m_pStatus = m_player.GetComponent<Player> ().GetStatus ();

			if(m_pStatus == "Die"){
				StartCoroutine (Die ());
			}
			if(m_pStatus == "Fire"){	
				StartCoroutine(Fire()); 
			}

			else if(m_pStatus == "DuringFire"){
				DuringFire();
			}

			else if(m_pStatus == "Normal"){	
				Normal();
			}

		}
	}

}
