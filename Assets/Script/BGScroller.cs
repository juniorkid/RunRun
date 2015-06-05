using UnityEngine;
using System.Collections;

public class BGScroller : MonoBehaviour {

	public float m_scrollSpeed = 0;

	private Vector3 m_startPosition;
		
	private bool m_deleteF;

	private GameObject m_player;

	public Transform m_stopTransform;

	void Update(){

		// Move object backward
		Vector3 pos = transform.position;

		// Stop object when go to stop point
		if (pos.x <= -22f) {
			gameObject.SetActive (false);
			m_scrollSpeed = 0;
		} 
		// Move object backward
		else {
			pos.x -= Time.deltaTime * m_scrollSpeed;
			transform.position = pos;
		}
	}

	// Set move speed
	public void SetSpeed(float speed){
		m_scrollSpeed = speed;
	}

	// Get move speed
	public float GetSpeed(){
		return m_scrollSpeed ;
	}
}
