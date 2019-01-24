using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DeadZone : MonoBehaviour {

	public Text scorePlayerText;
	public Text scoreEnemyText;

	int scorePlayerInt = 0;
    int scoreEnemyInt = 0;

	public SceneChanger sceneChanger;

	public AudioSource pointAudio;


	// public BallBehaviour
 
	// private void OnCollisionEnter2D(Collision2D other) //Choque
	// {
	// 	Debug.Log("Colision");
	// }

	/**
	detecta cuando algo atraviesa la colision
	en este caso lo que atraviesa es la pelota 

	 */
	private void OnTriggerEnter2D(Collider2D ball)  
	{
		if (gameObject.CompareTag("Left"))//SIEMPRE USAR COMPARE TAG
		{
			scoreEnemyInt++;
            UpdateScoreLabel(scoreEnemyText,scoreEnemyInt);

		}else if (gameObject.CompareTag("Right"))
		{
			scorePlayerInt++;
            UpdateScoreLabel(scorePlayerText, scorePlayerInt);

        }
        ball.GetComponent<BallBehaviour>().gameStarted = false;
        CheckScore();
		pointAudio.Play();
    }

	private void UpdateScoreLabel(Text label, int score)
	{
		label.text = score.ToString();

	}

	void CheckScore()
	{
		if (scorePlayerInt >=3 )
		{
            sceneChanger.ChangeSceneTo("WinScene");
		}else if (scoreEnemyInt >= 3)
		{
			sceneChanger.ChangeSceneTo("LoseScene");
		}
	}
}
