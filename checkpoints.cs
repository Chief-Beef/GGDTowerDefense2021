using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkpoints : MonoBehaviour
{

    public GameObject[] pathfinders = new GameObject[21];
    public static checkpoints Instance;
    
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        pathfinders = new GameObject[this.transform.childCount];

        for (int i = 0; i < pathfinders.Length; i++)
        {
            pathfinders[i] = this.transform.GetChild(i).gameObject;
        }
    }


}
