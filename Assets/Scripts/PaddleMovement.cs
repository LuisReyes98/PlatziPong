using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleMovement : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    /*  
		en un juego movil 30fps suele ser suficiente de poner mas el telefono
		es propenso a calentarse y quedarse sin batería
	*/
    // Update is called once per frame
    void Update () {
		Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

		// Debug.Log(Input.mousePosition);

		transform.position = new Vector3(
			transform.position.x,
			Mathf.Clamp(mousePos.y,-3.8f,3.8f),
			transform.position.z
		);

	}
}
