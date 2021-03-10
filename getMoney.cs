using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class getMoney : MonoBehaviour
{
    public static getMoney Instance;

    public Text txt;

    public int money;
    public int lives;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        txt.text = "Survive Round 25 To Win" + "\nQ Key for Railgun " + "\nW Key for Missile Launcher" + "\nMoney: " + money + "\t Lives: " + (lives/2) + "\nRAILGUN PRICE: " + chooseTower.Instance.railgunCost + "\nMISSILE PRICE: " + chooseTower.Instance.missileLauncherCost + "\nROUND: " + spawnMore.Instance.waveCounter + "\nENEMY HEALTH: " + Enemy.Instance.maxHealth;
    }


}
