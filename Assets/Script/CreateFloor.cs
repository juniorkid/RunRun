using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CreateFloor : MonoBehaviour {

	public float m_allSpeed;

	public GameObject[] m_prefab;

	private GameObject m_floor1;
	private GameObject m_floor2;

	private int m_numStone;
	
	private float m_timeStone;

	private bool m_hasFall;

	private float m_random; 

	private bool m_stop;

	private GameObject m_item;

	private List<GameObject> m_listGround;
	private List<GameObject> m_listFall;
	private List<GameObject>  m_listStone;

	private int m_indexGround;
	private int m_indexFall;

	private Vector3 m_startPos;
	private Vector3 m_endPos;

	// Use this for initialization
	void Start () {
		m_listGround = new List<GameObject> ();
		m_listFall = new List<GameObject> ();
		m_listStone = new List<GameObject> ();

		m_indexGround = 0;
		m_indexFall = 0;

		m_listGround.Add (Instantiate(m_prefab[0], new Vector3(15.6f, -3.016f, 0), Quaternion.identity) as GameObject);
		m_listGround.Add (Instantiate(m_prefab[0], new Vector3(15.6f, -3.016f, 0), Quaternion.identity) as GameObject);
		m_listGround.Add (Instantiate(m_prefab[0], new Vector3(15.6f, -3.016f, 0), Quaternion.identity) as GameObject);
		m_listGround.Add (Instantiate(m_prefab[0], new Vector3(15.6f, -3.016f, 0), Quaternion.identity) as GameObject);

		m_listFall.Add (Instantiate (m_prefab [1], new Vector3 ( 15.6f, -3.016f, 0), Quaternion.identity) as GameObject);
		m_listFall.Add (Instantiate (m_prefab [1], new Vector3 ( 15.6f, -3.016f, 0), Quaternion.identity) as GameObject);
		m_listFall.Add (Instantiate (m_prefab [1], new Vector3 ( 15.6f, -3.016f, 0), Quaternion.identity) as GameObject);
		m_listFall.Add (Instantiate (m_prefab [1], new Vector3 ( 15.6f, -3.016f, 0), Quaternion.identity) as GameObject);

		GameObject stone;
		stone = Instantiate (m_prefab [2], new Vector3 (-24f, -1.0f, 0), Quaternion.identity) as GameObject;
		m_listStone.Add (stone);

		stone = Instantiate (m_prefab [2], new Vector3 (-24f, -1.0f, 0), Quaternion.identity) as GameObject;
		m_listStone.Add (stone);

		stone = Instantiate (m_prefab [2], new Vector3 (-24f, -1.0f, 0), Quaternion.identity) as GameObject;
		m_listStone.Add (stone);

		stone = Instantiate (m_prefab [2], new Vector3 (-24f, -1.0f, 0), Quaternion.identity) as GameObject;
		m_listStone.Add (stone);

		stone = Instantiate (m_prefab [2], new Vector3 (-24f, -1.0f, 0), Quaternion.identity) as GameObject;
		m_listStone.Add (stone);

		m_numStone = 0;
		m_stop = false;
		m_timeStone = 4f;

		m_listGround[m_indexGround].GetComponent<BGScroller>().SetSpeed(5f);
		m_floor1 = m_listGround [m_indexGround];
	
		m_floor1.transform.position = new Vector3(-5.39f, -3.016f, 0);
		m_indexGround++;

		m_listGround[m_indexGround].GetComponent<BGScroller>().SetSpeed(5f);
		m_floor2 = m_listGround [m_indexGround];
		m_floor2.transform.position = m_floor1.transform.Find("Stop").gameObject.transform.position;
		m_indexGround++;

		m_item = Instantiate (m_prefab [3], new Vector3 (-23f, -1.11f, 0), Quaternion.identity) as GameObject;
	}

	void Update () {
		if (!m_stop) {
			CreateFloor1();
			CreateFloor2();
			CreateStone();
			CreateFire();	
		}
	}

	public void SetStop(bool stopGame){
	//	Debug.Log ("STOP");
		m_stop = stopGame;
	}

	public bool GetStop(){
		return m_stop;
	}

	public void SetSpeedAll(float speed){
		m_allSpeed = speed;
		if(m_floor1 != null)
			m_floor1.GetComponent<BGScroller> ().SetSpeed (m_allSpeed);
		if(m_floor2 != null)
			m_floor2.GetComponent<BGScroller> ().SetSpeed (m_allSpeed);

		foreach (GameObject stone in m_listStone) {
			if(stone.activeSelf == true){
				stone.GetComponent<BGScroller>().SetSpeed(m_allSpeed);
			}
		}

		if (m_item != null) {
		//	Debug.Log("Set Fire Speed : " + speed);
			m_item.GetComponent<BGScroller> ().SetSpeed (speed);
		}
	}	

	void CreateFloor1(){

		if (m_floor1.activeSelf == false) {
			m_random = Random.value;

			if (m_random < 0.6) {
				if(m_indexGround == m_listGround.Count)
					m_indexGround = 0;
				
				m_listGround[m_indexGround].SetActive(true);
				m_floor1 = m_listGround[m_indexGround];
				m_indexGround ++;
				
				m_hasFall = false;

			} else {

				if(m_indexFall == m_listFall.Count)
					m_indexFall = 0;
				
				m_listFall[m_indexFall].SetActive(true);
				m_floor1 = m_listFall[m_indexFall];
				m_indexFall ++;
				m_hasFall = true;
			}

			m_floor1.transform.position = m_floor2.GetComponent<BGScroller> ().m_stopTransform.position;

			//Vector3 pos = m_floor1.transform.position;
			//pos.x -= 2f;

			//m_floor1.transform.position = pos;
			m_floor1.SetActive(true);
			StartCoroutine(Snap( m_floor1.transform,m_floor2.GetComponent<BGScroller> ().m_stopTransform));
	//		Debug.Log(m_hasFall);
		}
	}

	private IEnumerator Snap(Transform t1, Transform t2)
	{
		yield return new WaitForSeconds (0.001f);
		while (t1.position.x != t2.position.x) {
			t1.position = t2.position;
			yield break;
		}
	}
	void CreateFloor2(){

		if (m_floor2.activeSelf == false) {
			//Debug.Log(m_hasFall);
			m_random = Random.value;

			if (m_random < 0.6) {
				if(m_indexGround == m_listGround.Count)
					m_indexGround = 0;
				
				m_listGround[m_indexGround].SetActive(true);
				m_floor2 = m_listGround[m_indexGround];
				m_indexGround ++;
				
				m_hasFall = false;

			} else {

				if(m_indexFall == m_listFall.Count)
					m_indexFall = 0;
				
				m_listFall[m_indexFall].SetActive(true);
				m_floor2 = m_listFall[m_indexFall];
				m_indexFall ++;
				m_hasFall = true;
			}





			//m_floor2.transform.position = pos;
			m_floor2.SetActive(true);
			BGScroller bgs = m_floor1.GetComponent<BGScroller> ();
			Vector3 pos = bgs.m_stopTransform.position;
			//pos.x -= 2f;
			m_floor2.transform.position = pos;
	//		Debug.Log("Is equals "+(bgs.m_stopTransform.position.x == m_floor2.transform.position.x));
	//		Debug.Log("bgs "+bgs.m_stopTransform.position.x);
	//		Debug.Log("m_floor2 "+m_floor2.transform.position.x);
	//		Debug.Log(m_hasFall);
			StartCoroutine(Snap( m_floor2.transform,bgs.m_stopTransform));
		}
	}

	void CreateStone(){
		if (m_timeStone != 0)
			m_timeStone -= Time.deltaTime;
		
		if (Random.value < 0.6 && m_timeStone <= 0 && !m_hasFall && m_numStone < m_listStone.Count) {
			m_listStone[m_numStone].transform.position = new Vector3 ( 8f, -1.14f, 0);
			m_listStone[m_numStone].SetActive(true);
			m_timeStone = 2 + Random.value * 10;
			m_numStone ++;
		}
		
		if(m_numStone == m_listFall.Count){
			m_numStone = 0;
		}
	}

	void CreateFire(){
		float random;
		random = Random.value;
		Debug.Log (random);
		if(m_item.transform.position.x < -21 && random > 0.99){
			m_item.transform.position = new Vector3 (10f, -1.11f, 0);
		//	Debug.Log(m_item.GetComponent<BGScroller>().m_scrollSpeed);
			m_item.SetActive(true);
		}
	}
}
