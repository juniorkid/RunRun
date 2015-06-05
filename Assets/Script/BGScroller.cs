using UnityEngine;
using System.Collections;

public class BGScroller : MonoBehaviour {

	public float m_scrollSpeed = 0;

	private Vector3 m_startPosition;
		
	private bool m_deleteF;

	private GameObject m_player;

	public Transform m_stopTransform;
	void Start(){
	}

	void Update(){
		Vector3 pos = transform.position;
		if (pos.x <= -22f) {
			gameObject.SetActive (false);
			m_scrollSpeed = 0;
		} else {
			pos.x -= Time.deltaTime * m_scrollSpeed;
			transform.position = pos;
		}
	}
	
	public void SetSpeed(float speed){
	//	Debug.Log ("SPEED : " + speed);
		m_scrollSpeed = speed;
	//	Debug.Log ("m_scrollSpeed : " + m_scrollSpeed);
	}

	public float GetSpeed(){
		//	Debug.Log ("SPEED : " + speed);
		return m_scrollSpeed ;
		//	Debug.Log ("m_scrollSpeed : " + m_scrollSpeed);
	}
}
