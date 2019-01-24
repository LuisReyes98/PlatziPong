using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehaviour : MonoBehaviour {

	public Transform paddle;
	public bool gameStarted = false;
	public Rigidbody2D rigidbodyBall;

	public AudioSource ballAudio;

	private float posDif;

	// Use this for initialization
	void Start () {
        posDif = paddle.position.x - transform.position.x;

    }
	
	// Update is called once per frame
	void Update () {
		if (!gameStarted)
		{			
			transform.position = new Vector3(paddle.position.x - posDif, paddle.position.y, paddle.position.z);			

			if (Input.GetMouseButtonDown(0))
			{
				// Debug.Log("game started");
                rigidbodyBall.velocity = new Vector2(8,8);
				gameStarted = true;
			}
		} 
	}

	/// <summary>
	/// Sent when an incoming collider makes contact with this object's
	/// collider (2D physics only).
	/// </summary>
	/// <param name="other">The Collision2D data associated with this collision.</param>
	
	private void OnCollisionEnter2D(Collision2D collision)
	{
		ballAudio.Play();
	}
}
