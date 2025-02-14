﻿using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour 
{
	public GameObject explosion;
	public GameObject playerExplosion;
	public int scoreValue;
	private GameController gameController;

	void Start()
	{
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null)
		{
			gameController = gameControllerObject.GetComponent <GameController>();
		}
		if (gameController == null) 
		{
			Debug.Log ("Cannot find 'game controller' script");
		}


	}

	void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Boundary") || other.CompareTag("Enemy")) 
		{
			return;
		}

		if (explosion != null) 
		{
			Instantiate (explosion, other.transform.position, other.transform.rotation);
		}
		if (other.CompareTag ("Player"))
		{
			Instantiate (playerExplosion, other.transform.position, other.transform.rotation);
			gameController.GameOver ();
		}


		gameController.AddScore (scoreValue);
		Destroy (other.gameObject);
		Destroy(gameObject);


	}

}
