using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerInteractions_Tower3 : MonoBehaviour
{
    public float interactRange = 5f;
    public int levelScene = 5;

    public GameObject equipmentObject;
    public GameObject spawns;
    public GameObject userInterface;

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

            }
        }
    }


    void ChangeSpawnIndex(int index)
    {
        EquipmentManager equipment = equipmentObject.transform.GetComponent<EquipmentManager>();

        equipment.ChangeSpawnIndex(index);
    }
}
