using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RailGunAiming : MonoBehaviour
{
    public static AudioSource shootyNoise;

    public Vector3 center;
    public Vector3 enemyPos;
    public Vector3 gunPos1;
    public Vector3 gunPos2;
    public Vector3 gunPos;

    public Material redBoi;
    public Material blueBoi;

    public List<GameObject> targets = new List<GameObject>();
    public GameObject enemy;
    public GameObject bullet;
    public GameObject gun1;
    public GameObject gun2;
    GameObject[] obj;

    public float fireRate = .5f;
    public float shotClock = 0;
    public float range = 10;
    public int totalShots = 0;
    public int i = 0;
    public int x = 0;
    public int counter = 1;


    // Start is called before the first frame update
    void Start()
    {
        center = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        shotClock += Time.deltaTime;

        gunPos1 = gun1.transform.position;
        gunPos2 = gun2.transform.position;

        gunPos = (gunPos1 + gunPos2) / 2;

        //Debug.Log("gun1: " + gunPos1 + "\t gun2: " + gunPos2 + "\t gunPos: " + gunPos);

        obj = GameObject.FindGameObjectsWithTag("enemyCube");
        targets = TargetList(obj, center, range);

        if (InRange(center, targets[i], range))
        {

            transform.LookAt(targets[i].transform);

            if (shotClock >= fireRate)
            {

                Instantiate(bullet, gunPos, this.transform.rotation);

                NoisyBoi.Instance.MakeNoise();

                shotClock = 0;
                totalShots++;

            }

            float angle = Mathf.Atan2(targets[i].transform.position.z, targets[i].transform.position.x);
            //targets[i].GetComponent<MeshRenderer>().material = redBoi;
            //Debug.Log("enemyPos.x: " + enemyPos.x + "      enemyPos.z" + enemyPos.z + "      angle:" + angle * Mathf.Rad2Deg + "     sin(theta): " + Mathf.Sin(angle) + "    cos(theta): " + Mathf.Cos(angle));

        }


    }

    public List<GameObject> TargetList(GameObject[] obj, Vector3 center, float range)
    {
        List<GameObject> targets = new List<GameObject>();

        for (int i = 0; i < obj.Length; i++)
        {
            if (InRange(center, obj[i], range))
                targets.Add(obj[i]);
        }

        return targets;
    }

    public bool InRange(Vector3 center, GameObject obj, float range)
    {
        if (Vector3.Distance(center, obj.transform.position) <= range)
        {
            return true;
        }
        return false;
    }

    public bool OutOfRange(Vector3 center, GameObject obj, float range)
    {
        if (Vector3.Distance(center, obj.transform.position) > range)
        {
            return true;
        }
        return false;
    }
}

