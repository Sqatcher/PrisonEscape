using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerInteractions_Tower4 : MonoBehaviour
{
    public float interactRange = 5f;
    public int levelScene = 6;

    public GameObject equipmentObject;
    public GameObject spawns;
    public GameObject userInterface;

    public GameObject chest;
    public GameObject wiekoClose;
    public GameObject key;

    public Camera playerCam;

    public string towerDoorName1;
    public int outSpawnIndex1 = 0;

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

                    key.SetActive(true);
                }

                //look for the key only if not already there
                if (equipmentObject.transform.GetComponent<EquipmentManager>().Key() == false)
                {
                    for (int i = 0; i < key.transform.childCount; i++)
                    {
                        if (hit.transform.gameObject == key.transform.GetChild(i).gameObject)
                        {
                            key.GetComponent<KeyBehaviour>().GetKey();
                            break;
                        }
                    }
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
