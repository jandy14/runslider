using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
	public bool isKeyDown;
	public bool isGround;
	public float power = 10f;
	public GameManager gm;
	public GameObject dead;
	void Start ()
	{
		isKeyDown = false;
	}
	
	void Update ()
	{
		if(Input.GetKeyDown(KeyCode.Space))
		{
			isKeyDown = true;
			if(isGround)
			{
				Jump();
				isGround = false;
			}
			else
			{
				Fall();
			}
		}
		if(Input.GetKeyUp(KeyCode.Space))
		{
			isKeyDown = false;
			if (isGround)
				StandUp();
		}
	}
	private void OnCollisionEnter2D(Collision2D collision)
	{
		if(collision.gameObject.tag == "Floor")
		{
			isGround = true;
			if(isKeyDown)
			{
				Duck();
			}
		}
	}
	//private void OnCollisionExit2D(Collision2D collision)
	//{
	//	if (collision.gameObject.tag == "Floor")
	//	{
	//		isGround = false;
	//	}
	//}
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Block")
		{
			gm.isAlive = false;
			Instantiate(dead,transform.position,transform.rotation);
			Destroy(gameObject);
			Debug.Log("Die!!");
		}
	}


	private void Jump()
	{
		GetComponent<Rigidbody2D>().velocity = Vector2.up * power;
	}
	private void Fall()
	{
		GetComponent<Rigidbody2D>().velocity = Vector2.down * power * 2.5f;
	}
	private void StandUp()
	{
		float _scale = transform.localScale.y;
		transform.position += Vector3.up * _scale * 0.5f;
		transform.localScale = new Vector3(transform.localScale.x, _scale * 2, transform.localScale.z);
	}
	private void Duck()
	{
		float _scale = transform.localScale.y;
		transform.position += Vector3.down * _scale * 0.25f;
		transform.localScale = new Vector3(transform.localScale.x, _scale / 2, transform.localScale.z);
	}
}
