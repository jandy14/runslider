using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
	public Text score;
	public bool isAlive = true;

	private float timer;
	// Use this for initialization
	void Start ()
	{
		timer = 0;	
	}
	
	// Update is called once per frame
	void Update ()
	{
		timer += Time.deltaTime;
		if (isAlive)
		score.text = "Score : " + ((int)timer).ToString();
	}
}
