using UnityEngine;
using System.Collections;

public class CreateFloor : MonoBehaviour {

	public GameObject[] m_prefab;

	private GameObject m_floor1;
	private GameObject m_floor2;

	private GameObject m_stone;

	private float m_timeStone;

	private bool m_hasFall;

	private float m_random; 

	private bool m_stop;

	// Use this for initialization
	void Start () {
		m_stop = false;
		m_timeStone = 4f;
		m_floor1 = Instantiate(m_prefab[0], new Vector3(-0.4f, -0.2f, 0), Quaternion.identity) as GameObject;
		m_floor2 = Instantiate(m_prefab[0], new Vector3( 15.21f, -0.2f, 0), Quaternion.identity) as GameObject;
	}

	void Update () {
		if (!m_stop) {
			if (m_floor1 == null) {
				m_random = Random.value;
				Debug.Log ("Floor 1 " + m_random);
				if (m_random < 0.5) {
					m_floor1 = Instantiate (m_prefab [0], new Vector3 (14.6f, -0.2f, 0), Quaternion.identity) as GameObject;
					m_hasFall = false;
				} else {
					m_floor1 = Instantiate (m_prefab [1], new Vector3 (14.6f, -0.2f, 0), Quaternion.identity) as GameObject;
					m_hasFall = true;
				}
			}

			if (m_floor2 == null) {
				m_random = Random.value;
				Debug.Log ("Floor 2 " + m_random);
				if (m_random < 0.5) {
					m_floor2 = Instantiate (m_prefab [0], new Vector3 (14.6f, -0.2f, 0), Quaternion.identity) as GameObject;
					m_hasFall = false;
				} else {
					m_hasFall = true;
					m_floor2 = Instantiate (m_prefab [1], new Vector3 (14.6f, -0.2f, 0), Quaternion.identity) as GameObject;
				}
			}

			if (m_timeStone != 0)
				m_timeStone -= Time.deltaTime;

			if (Random.value < 0.5 && m_timeStone <= 0 && !m_hasFall) {
				Instantiate (m_prefab [2], new Vector3 (10f, -1.11f, 0), Quaternion.identity);
				m_timeStone = 2 + Random.value * 10;
			}
		}
	}

	public void SetStop(bool stopGame){
		m_stop = stopGame;
	}

	public bool GetStop(){
		return m_stop;
	}
}
