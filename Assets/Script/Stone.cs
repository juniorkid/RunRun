using UnityEngine;
using System.Collections;

public class Stone : MonoBehaviour {

	public Sprite m_boomSprite;
	public SpriteRenderer m_spirteRend;
	public Sprite m_defSprite;

	public bool m_boomStatus;
	// Use this for initialization
	void Start () {
		m_boomStatus = false;
		m_spirteRend = gameObject.GetComponent<SpriteRenderer> ();
		m_defSprite = m_spirteRend.sprite;
	}
	
	// Update is called once per frame

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.name == "Player") {
			if (coll.gameObject.GetComponent<Player> ().GetStatus () == "Fire") {
				m_boomStatus = true;
			}
		}
	}

	void Update(){
		if (m_boomStatus) {
			StartCoroutine (Boom ());
		} else {
			StopCoroutine (Boom ());
			m_spirteRend.sprite = m_defSprite;
		}
	}

	private IEnumerator Boom(){
	//	Debug.Log ("STONE BOOM");
		m_spirteRend.sprite = m_boomSprite;
		gameObject.GetComponent<PolygonCollider2D> ().enabled = false;
		yield return new WaitForSeconds (0.6f);
		gameObject.transform.position = new Vector3 (-24f, -1.0f, 0);
		m_boomStatus = false;
		gameObject.GetComponent<PolygonCollider2D> ().enabled = true;
	}
}
