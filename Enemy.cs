using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Enemy : MonoBehaviour
{
    //public checkpoints checkpoint;

    public static Enemy Instance;
    
    public Rigidbody rb;

    public Vector3 mySpot;

    public int counter;

    public int speed = 20;
    public int health;
    public int maxHealth = 1;
    public int extraSpeed = 5;

    public GameObject deathEffect;
    public GameObject[] path;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;

        speed += extraSpeed * spawnMore.Instance.waveCounter / 3;
        maxHealth += spawnMore.Instance.waveCounter / 2;
        Debug.Log("spawnMore.Instance.waveCounter: " + spawnMore.Instance.waveCounter + "\tenemy health: " + maxHealth + "\tspeed: " + speed);

        health = maxHealth;
        counter = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //path = GameObject.FindGameObjectsWithTag("checkpoint");
        path = checkpoints.Instance.pathfinders;

        mySpot = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);

        transform.LookAt(path[counter].transform);
        rb.velocity = transform.forward * speed;

        //txt.text = "Current checkpoint is: " + path[counter] + "\n";

        if (Vector3.Distance(mySpot, path[counter].transform.position) < 2.0f )
        {
            counter++;
        }


        if (health <= 0)
        {
            Instantiate(deathEffect, new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z), this.transform.rotation);
            getMoney.Instance.money += 50;
            Destroy(this.gameObject);
        }

        
    }

    private void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "bullet")
        {
            health--;
        }

        if(col.gameObject.tag == "missile")
        {
            health -= 4;
        }

        if(col.gameObject.tag == "endCube")
        {
            getMoney.Instance.lives--;
            Destroy(this.gameObject);
        }
    }
}
