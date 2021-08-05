using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunBulletBehaviour : MonoBehaviour
{
    public float speed = 20f;
    public float discord = 3f;

    // Start is called before the first frame update
    void Start()
    {
        transform.GetComponent<Rigidbody>().velocity = transform.TransformDirection(new Vector3(Random.Range(-discord, discord), Random.Range(-discord, discord), speed));
        Destroy(gameObject, 1f);
    }
}
