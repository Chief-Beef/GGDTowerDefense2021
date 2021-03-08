using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chooseTower : MonoBehaviour
{
    public static chooseTower Instance;

    public GameObject railgun;
    public GameObject missileLauncher;
    public GameObject chosenTower;

    public int missileLauncherCost = 1250;
    public int railgunCost = 500;
    public int chosenTowerCost;

    public KeyCode one;
    public KeyCode two;

    // Start is called before the first frame update
    private void Start()
    {
        chosenTowerCost = railgunCost;
    }

    // Update is called once per frame
    void Update()
    {
        Instance = this;

       
        if (Input.GetKeyDown(one))
        {
            chosenTower = railgun;
            chosenTowerCost = railgunCost;
        }
        if (Input.GetKeyDown(two))
        {
            chosenTower = missileLauncher;
            chosenTowerCost = missileLauncherCost;
        }
    }

}
