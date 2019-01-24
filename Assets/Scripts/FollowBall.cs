using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowBall : MonoBehaviour {

	public Transform ball; //para la posicion lo mas facil es usar un transform
	public float speed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		//usar yoffset y delta time para tener una velocidad constante a pesar de los frames
		float yOffset = 0;
        //Time.deltaTime //time between frames 
		float tempSpeed = speed +RandomBoost(); //la velocidad se hace aleatoria

		if (ball.GetComponent<BallBehaviour>().gameStarted)
		{

			if (transform.position.y < ball.position.y)
			{
                yOffset = transform.position.y + tempSpeed * Time.deltaTime;
                transform.position = new Vector3(transform.position.x,yOffset,transform.position.z);
			}else if (transform.position.y > ball.position.y)
			{
                yOffset = transform.position.y - tempSpeed * Time.deltaTime;

                transform.position = new Vector3(transform.position.x, yOffset, transform.position.z);

            }
		}	
	}

	private float RandomBoost(){
        float random = Random.Range(0.0f, 1.0f);

		float boost = 0;
		if (random >= 0.7)
		{	
			boost = random;
		}
		else if(random <= 0.3 ){
			boost = 0;

		}else //random >0.3   <0.7
		{
			boost = random * -1.5f;
		}
		// Debug.Log("boost: " + boost );
		return boost;
    }
}
