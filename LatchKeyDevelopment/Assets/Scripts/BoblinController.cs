using UnityEngine;
using System.Collections;

public class BoblinController : MonoBehaviour {

    private Vector2 dir;

    private float time;
    private float x;
    private float y;

    private bool colliding;


    void Start () {
        //Random direction
        x = Random.Range(-1f, 1f);
        y = Random.Range(-1f, 1f);
        dir = new Vector2(x, y);

        //Random time to move in direction
        time = Random.Range(3f, 6f);

    }
	
	void Update () {
        time -= Time.deltaTime;
        this.GetComponent<Rigidbody2D>().velocity = dir.normalized * 1f;

      if (colliding)    //Reverse direction
        {   
            dir = new Vector2(-x, -y);
            colliding = false;
        }
        
        //Time is up, new random direction and interval
        if (time <= 0)
        {
            x = Random.Range(-1f, 1f);
            y = Random.Range(-1f, 1f);
            dir = new Vector2(x, y);

            time = Random.Range(3f, 6f);
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        //collisions that reverse direction
        if (col.gameObject.layer == 8)  //wall
        {
            colliding = true;
        }
        else if (col.gameObject.layer == 9) //hazard
        {
            colliding = true;
        }
        else if (col.gameObject.layer == 13)    //enemy
        {
            colliding = true;
        }
        else if (col.gameObject.tag == "Switch")
        {
            colliding = true;
        }

        //collisions that kill boblin
        if (col.gameObject.name == "projectile")
        {
            PlayerController.lvlScore += 10;
            Kill();
        }
    }

    public void Kill()
    {
        Destroy(this.gameObject);
    }
}
