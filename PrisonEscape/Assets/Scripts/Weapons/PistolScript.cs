using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolScript : MonoBehaviour
{
    //public GameObject camera;
    [HideInInspector]
    float targetXRotation, targetYRotation;
    [HideInInspector]
    float targetXRotationV, targetYRotationV;

    public Camera playerCam;
    //public GameObject shell;
    public GameObject bullet;
    public Transform shellSpawnPos, bulletSpawnPos;
    //public float rotateSpeed = .3f, holdHeight = -0.5f, holdSide = -0.5f;
    public float range = 100f;
    public float damage = 10f;
    public float impactForce = 30f;
    public float fireRate = 3f;
    //public ParticleSystem muzzleFlash;


    private float nextTimeToFire = 0f;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)  //GetButton = automatic, GetButtonDown = manual
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
        }

        //targetXRotation = Mathf.SmoothDamp(targetXRotation, FindObjectOfType<MouseLook>().rotX, ref targetXRotationV, rotateSpeed);
    }

    void Shoot()
    {
        //muzzleFlash.Play();
        //GameObject shellCopy = Instantiate<GameObject>(shell, shellSpawnPos.position, Quaternion.identity) as GameObject;
        //Rigidbody bulletCopy = Instantiate(bullet, transform.position, transform.rotation) as Rigidbody;
        GameObject bulletCopy = Instantiate(bullet, bulletSpawnPos.position, transform.rotation) as GameObject;
        //bulletCopy.velocity = transform.TransformDirection(new Vector3(0, 0, bulletSpeed));
        //Destroy(bulletCopy.GetComponent<Rigidbody>());
        //Destroy(bulletCopy, 2f);

        RaycastHit hit;
        bool status = Physics.Raycast(playerCam.transform.position, playerCam.transform.forward, out hit, range);

        if (status)
        {
            //Debug.Log(hit.transform.name);

            TargetBehaviour target = hit.transform.GetComponent<TargetBehaviour>();

            if (target != null)
            {
                target.TakeDamage(damage);
            }

            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }
        }
    }

}
