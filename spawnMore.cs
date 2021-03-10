using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class spawnMore : MonoBehaviour
{

    public static spawnMore Instance;

    //public float waveTimer = 0;
    public float timer = 0;
    public float spawnTime = 2.0f;
    public float enemyHealth;
    //public Vector3 spawnSpot;
    public float xPos;



    public GameObject cube;
    public int spawnCounter = 0;    //how many enemies spawn this wave
    public int waveChange;          //number of enemies that spawns per round
    public int waveCounter = 1;     //what wave of enemies are we on

    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Instance = this;

        timer += Time.deltaTime;

        if(timer >= spawnTime)
        {
            Instantiate(cube, new Vector3(this.transform.position.x, this.transform.position.y-1, this.transform.position.z-1), this.transform.rotation);
            spawnCounter++;
            timer = 0;
        }

        if(spawnCounter >= waveChange)
        {
            waveCounter++;          //next level
            spawnTime *= .9f;       //enemies spawn faster
            waveChange += 5;        //5 more enemies will spawn than the last wave
            spawnCounter = 0;       //reset spawn counter
            timer = -10.0f;         //wait 10 seconds between rounds to spawn more enemies
        }

        if(waveCounter == 26)
        {
            SceneManager.LoadScene("ChickenDinner");
        }

        if (getMoney.Instance.lives <= 0)
        {
            SceneManager.LoadScene("EndGame");
        }
    }

    public bool CheckForWin(int wave)
    {
        if (wave >= 15)
            return true;

        return false;
    }

    
}


