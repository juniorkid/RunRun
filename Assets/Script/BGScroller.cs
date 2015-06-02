using UnityEngine;
using System.Collections;

public class BGScroller : MonoBehaviour {

	public float m_scrollSpeed;

	private Vector3 m_startPosition;
		
	void Start(){

	}

	void Update(){
		Vector3 pos = transform.position;
		pos.x -= Time.deltaTime * m_scrollSpeed;
		if(pos.x < -17f){
			Destroy(gameObject);
		}
		transform.position = pos;
	}

	public void SetSpeed(float speed){
		m_scrollSpeed = speed;
	}
}
