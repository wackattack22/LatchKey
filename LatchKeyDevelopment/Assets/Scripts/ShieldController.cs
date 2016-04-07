﻿using UnityEngine;
using System.Collections;

// This script contains the shield projectile behavior.

public class ShieldController : MonoBehaviour
{
	// Controls how many bounces it takes before the shield is "returned".
	// We need a more reliable solution for this problem, but this was simply
	// an expedient solution.
	public int hitCounter;

	public GameObject player;

	public PlayerController playerController;

	// Use this for initialization
	void Start ()
	{
		player = GameObject.FindWithTag ("Player");
		playerController = player.GetComponent<PlayerController>();
	}
	
	// Update is called once per frame
	void Update ()
	{
	}

	void FixedUpdate(){
		Physics2D.IgnoreCollision (player.GetComponent<Collider2D>(), GetComponent<Collider2D>());
	}

	void OnCollisionExit2D (Collision2D col)
	{
		if (hitCounter <= 0) {
			//playerController.Warp (transform.position);
			Kill();
		} else {

			if (col.gameObject.layer == 8) {
				--hitCounter;
			} else if (col.gameObject.tag == "Hazard") {
				Kill ();
			}
            
        }
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag == "Hazard") {
			Kill ();
		}     
    }
		
	// Destroys the shield projectile and resets the player shield capabilities.
	public void Kill(){
		Destroy (this.gameObject);
		playerController.shieldDeployed = false;
	}
		
}
