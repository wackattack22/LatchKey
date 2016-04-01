using UnityEngine;
using System.Collections;

// This script controls the interaction between the shield projectile and rift

public class SwitchController : MonoBehaviour {

	private Animator switchAnim;

	public bool isActive;

	GameObject rift;

	RiftController riftController;

	// Use this for initialization
	void Start () {
		switchAnim = GetComponent<Animator> ();
		rift = GameObject.Find ("Rift");
		riftController = rift.GetComponent<RiftController> ();
	
	}
	
	// Update is called once per frame
	void Update () {
		if (isActive) {
			switchAnim.SetBool ("isActive", true);
			riftController.SetActive ();
		}
	
	}

	void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject.name == "projectile") {
			isActive = true;
		}
	}
}
