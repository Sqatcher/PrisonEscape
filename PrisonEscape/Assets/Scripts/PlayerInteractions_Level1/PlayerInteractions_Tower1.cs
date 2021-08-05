using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerInteractions_Tower1 : MonoBehaviour
{
    public float interactRange = 5f;
    public int levelScene = 3;

    public GameObject equipmentObject;
    public GameObject spawns;
    public GameObject userInterface;
    public GameObject map;
    public GameObject chest;
    public GameObject wiekoClose;

    public Camera playerCam;

    public string towerDoorName1;
    public int outSpawnIndex1 = 0;


    //eq:

    int currentScene;

    // Start is called before the first frame update
    void Start()
    {
        currentScene = SceneManager.GetActiveScene().buildIndex;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.E))
        {
            RaycastHit hit;
            if (Physics.Raycast(playerCam.transform.position, playerCam.transform.forward, out hit, interactRange))
            {
                //scene change
                if (hit.transform.name == towerDoorName1)
                {
                    ChangeSpawnIndex(outSpawnIndex1);
                    SceneManager.LoadScene(2);
                }

                if (hit.transform.gameObject == chest || hit.transform.gameObject == wiekoClose)
                {
                    chest.GetComponentInParent<ChestBehaviour>().OpenChest();

                    if (map != null)
                    {
                        map.SetActive(true);
                    }
                }
                if (hit.transform.gameObject == map)
                {
                    map.GetComponent<MapBehaviour>().GetMap();
                }
            }
        }
    }


    void ChangeSpawnIndex(int index)
    {
        EquipmentManager equipment = equipmentObject.transform.GetComponent<EquipmentManager>();

        equipment.ChangeSpawnIndex(index);
    }
}
