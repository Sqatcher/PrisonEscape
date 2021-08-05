using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.GetComponent<Rigidbody>().velocity = transform.TransformDirection(new Vector3(4, 4, 1));
        Destroy(gameObject, 1f);
    }

}
