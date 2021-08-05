using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    public float speed = 20f;

    // Start is called before the first frame update
    void Start()
    {
        transform.GetComponent<Rigidbody>().velocity = transform.TransformDirection(new Vector3(0, 0, speed));
        Destroy(gameObject, 2f);
    }

    // Update is called once per frame
    /*
    void Update()
    {
        
    }
    */
}
