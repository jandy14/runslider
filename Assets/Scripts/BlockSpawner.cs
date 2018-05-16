using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawner : MonoBehaviour {

	public GameObject blocks;
	public float cycle = 0.5f;
	public float speed = 2f;

	private float timer;
	void Start ()
	{
		timer = 0;
	}
	
	void Update ()
	{
		timer += Time.deltaTime;

		if(timer > cycle)
		{
			int _result = Random.Range(0, 7);
			GameObject g = Instantiate(blocks, transform.position, transform.rotation);
			if(_result / 3 == 0)
			{
				int tmp = _result % 3;
				tmp -= 1;
				g.transform.position += Vector3.up * tmp;
				g.GetComponent<Rigidbody2D>().velocity = Vector2.left * speed;
			}
			else if (_result / 3 == 1)
			{
				int tmp = _result % 3;
				tmp -= 1;
				g.transform.position += Vector3.up * tmp * 0.5f;
				g.transform.localScale = new Vector3(g.transform.localScale.x, g.transform.localScale.y * 2f, g.transform.localScale.z);
				g.GetComponent<Rigidbody2D>().velocity = Vector2.left * speed;
			}
			else
			{
				//None;
			}

			timer = 0;
		}
	}
}
