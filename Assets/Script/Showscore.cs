using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Showscore : MonoBehaviour {

	public Text m_textScore;

	private float m_score;
	private float m_count;

	// Use this for initialization
	void Start () {
		m_score = 0;
		m_count = 0;
		m_textScore.text = "Score : " + m_score.ToString ();
	}
	
	// Update is called once per frame
	void Update () {

		// Count score when game don't stop
		// Increase point follow move speed 
		m_count += Time.deltaTime * gameObject.GetComponent<CreateFloor>().m_allSpeed / 5;
		m_score = (int)m_count;

		// Show score
		if(m_score < 10)
			m_textScore.text = "Score : 0000" + m_score.ToString();
		else if(m_score < 100)
			m_textScore.text = "Score : 000" + m_score.ToString();
		else if(m_score < 1000)
			m_textScore.text = "Score : 00" + m_score.ToString();
		else if(m_score < 10000)
			m_textScore.text = "Score : 0" + m_score.ToString();
		else 
			m_textScore.text = "Score : " + m_score.ToString();
	}
}
