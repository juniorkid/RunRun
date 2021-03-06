﻿using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	
	public float m_jump = 800f;
	public bool m_hasJump = false;

	public Vector3 m_defaultPos;

	public string m_playerStatus;

	public float m_delayJump;

	public GameObject m_fireMode;
	

	void Start(){
		m_defaultPos.x = (-4.58f);
		m_playerStatus = "Normal";
	}
	
	void Update () {

		Jump ();

		SetDefualtPos ();

	}

	// Player jump when enter Floor 's Collision
	void OnCollisionEnter2D(Collision2D coll) {
		if (m_playerStatus != "Die") {
			gameObject.GetComponent<Animator> ().SetBool ("jump", false);
			m_hasJump = false;
		}
	}
	
	public void ChangeStatus(string status){
			m_playerStatus = status;
	}

	public string GetStatus(){
		return m_playerStatus;
	}

	public void FireMode(){
		transform.Find ("statusFire").GetComponent<SpriteRenderer>().enabled= true;
	}

	public void NormalMode(){
		transform.Find ("statusFire").GetComponent<SpriteRenderer>().enabled= false;
	}

	private void Jump (){
		if (Input.GetMouseButtonDown (0) && !m_hasJump) {

			gameObject.GetComponent<Rigidbody2D>().AddForce (new Vector2 (0, 1) * m_jump);
			gameObject.GetComponent<Animator>().SetBool("jump",true);
			m_hasJump = true;

		}
	}

	private void SetDefualtPos(){
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
	}
}
