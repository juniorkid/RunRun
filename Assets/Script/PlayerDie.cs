using UnityEngine;
using System.Collections;

public class PlayerDie : MonoBehaviour {

	public Sprite m_dieSprite;
	public bool m_die;	

	public GameObject m_createFloor;

	private GameObject[] m_grounds;

	IEnumerator Die(){
		if (m_die) {
			m_grounds = GameObject.FindGameObjectsWithTag("Ground");
			m_createFloor.GetComponent<CreateFloor>().SetStop(true);

			foreach (GameObject ground in m_grounds) {
				if(ground != null){
					ground.GetComponent<BGScroller>().SetSpeed(0f);
				}
			}

			gameObject.GetComponent<Animator>().SetBool("die",true);
			yield return new WaitForSeconds(.5f);
			Destroy(gameObject);
		}
	}

	// Use this for initialization
	void Start () {
		m_die = false;
	}
	
	// Update is called once per frame
	void Update () {
		StartCoroutine (Die ());
	}

	public void SetDie(){
		m_die = true;
	}

	public bool GetDie(){
		return m_die;
	}
}
