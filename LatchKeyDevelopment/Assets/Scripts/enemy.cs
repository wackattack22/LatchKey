using UnityEngine;
using System.Collections;

public class enemy : MonoBehaviour {

    private Rigidbody2D rBody;

    public GameObject shield;


    private GameObject Enemy;
    private GameObject Player;

    float x;
    Vector2 pos;

    private Vector2 pos1;
    private Vector2 pos2;
    public float speed = 1.0f;

    public float velocity;



    // Use this for initialization
    void Start()
    {
        x = Random.Range(1, 10);

        pos = this.transform.position;
        //pos1 = new Vector2(Random.Range(-8, transform.position.x), transform.position.y);
        pos2 = new Vector2(Random.Range(transform.position.x, 8), transform.position.y);
        rBody.velocity = new Vector2(velocity, rBody.velocity.y);
    }

    // Update is called once per frame
    void Update()
    {

        //this.transform.position = new Vector2(Mathf.PingPong(Time.time, x), transform.position.y);

       transform.position = Vector2.Lerp(pos, pos2, Mathf.PingPong(Time.time * speed, 1.0f));

    }

    void FixedUpdate()
    {

    }
    //die
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "projectile")
        {
            Kill();
        }
        
    }


    public void Kill()
    {
        Destroy(this.gameObject);
    }
}
