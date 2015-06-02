using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {
	
	public float m_jump = 200f;
	public bool m_hasJump = false;

	public Vector3 m_defaultPos;

	public Rigidbody2D m_rigid;

	void Start(){
		m_defaultPos.x = (-4.58f);
	}
	
	void Update () {

		if (Input.GetMouseButtonDown (0) && !m_hasJump) {
			m_rigid.AddForce (new Vector2 (0, 1) * m_jump);
			gameObject.GetComponent<Animator>().SetBool("jump",true);
		}
		m_defaultPos = transform.position;

		m_defaultPos.x = (-4.58f);

		transform.position   = m_defaultPos;

		Quaternion rot = transform.rotation;

		if (rot.z != 0) {
			// Grab the Z euler angle
			float z = rot.eulerAngles.z;
		
			// Change the z angle based on input
			z =  1.4f;
		
			// Recreate the quaternion
			rot = Quaternion.Euler (0, 0, z);
		
			// Feed the Quaternion into our rotation
			transform.rotation = rot;
		}

		if (Input.GetMouseButtonDown (1))
			GetComponent<Animator> ().speed = 2f;


	}

	void OnCollisionExit2D() {
		m_hasJump = true;
		gameObject.GetComponent<Animator>().SetBool("jump",true);
	}

	void OnCollisionEnter2D() {
		gameObject.GetComponent<Animator>().SetBool("jump",false);
		m_hasJump = false;
		
	}

	void OnCollisionStay2D() {
		gameObject.GetComponent<Animator>().SetBool("jump",false);
		m_hasJump = false;
		
	}

	void OnTriggerEnter2D() {
		gameObject.GetComponent<PlayerDie> ().SetDie ();
		m_hasJump = true;
	}
}
