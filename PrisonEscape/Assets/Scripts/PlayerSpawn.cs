using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    public GameObject equipmentObject;
    public GameObject spawns;

    void Start()
    {
        Spawn();
    }

    public void Spawn()
    {
        //set spawn position
        int spawnIndex = equipmentObject.transform.GetComponent<EquipmentManager>().SpawnIndex();

        transform.position = spawns.transform.GetChild(spawnIndex).transform.position;

        //gameObject.transform.position = new Vector3(10, 10, 0);

        gameObject.transform.eulerAngles = spawns.transform.GetChild(spawnIndex).transform.eulerAngles;
    }
}
