using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class missileMove : MonoBehaviour
{
    public SphereCollider hitbox;
    public float explosionSize;
    public Rigidbody rb;
    public float timer = 3.0f;
    public float speed;
    public float range = 25.0f;
    public float explosionRadius = 7.5f;
    public float explosionForce = 100f;

    public int i;

    public Vector3 center;

    public GameObject explosion;
    public GameObject[] obj;
    public List<GameObject> targets = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        i = 0;
        rb.AddForce(transform.forward * speed);
    }

    // Update is called once per frame
    void Update()
    {
        center = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);

        obj = GameObject.FindGameObjectsWithTag("enemyCube");
        targets = TargetList(obj, center, range);

        transform.LookAt(targets[i].transform);
        rb.AddForce(transform.forward * speed);

        //Missile Lifespan
        timer -= Time.deltaTime;

        if (timer <= 0.0f)
        {
            Destroy(this.gameObject);
        }

        rb.velocity = new Vector3(0,0,0);
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

    public void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "enemyCube")
        {
            
            Instantiate(explosion, this.transform.position, this.transform.rotation);
            Destroy(this.gameObject);
        }
    }
}
