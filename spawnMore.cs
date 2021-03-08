using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class spawnMore : MonoBehaviour
{

    public static spawnMore Instance;

    public float waveTimer = 0;
    public float waveChange = 30.0f;
    public int waveCounter = 1;
    public float timer = 0;
    public float spawnTime = 2.0f;
    public float enemyHealth;
    


    public GameObject cube;
    //public Vector3 spawnSpot;
    public float xPos;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Instance = this;

        timer += Time.deltaTime;
        waveTimer += Time.deltaTime;

        if(timer >= spawnTime)
        {
            Instantiate(cube, new Vector3(this.transform.position.x, this.transform.position.y-1, this.transform.position.z-1), this.transform.rotation);
            timer = 0;
        }

        if(waveTimer >= waveChange)
        {
            waveCounter++;
            spawnTime *= .9f;
            waveTimer = 0;
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
        if (wave >= 25)
            return true;

        return false;
    }

    
}


