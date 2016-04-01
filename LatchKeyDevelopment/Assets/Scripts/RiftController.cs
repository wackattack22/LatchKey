using UnityEngine;
using System.Collections;

// Controls rift behavior.

public class RiftController : MonoBehaviour {

	private Animator riftAnim;
	public bool isActive;

	// Use this for initialization
	void Start () {
		riftAnim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (isActive) {
			riftAnim.SetBool ("isActive", true);
		}
	}

	public void SetActive(){
		isActive = true;
		GetComponent<BoxCollider2D> ().enabled = true;
	}
		
}
