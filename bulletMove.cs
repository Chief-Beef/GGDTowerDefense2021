using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletMove : MonoBehaviour
{

    public Rigidbody rb;
    public float force = 55;
    public float pierce;
    public float timer = 3;

    // Start is called before the first frame update
    void Start()
    {
        rb.AddForce(transform.forward * force);
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if (pierce <= 0 || timer <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "enemyCube")
        {
            pierce--;

        }
    }
}
