using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerInteractions_MainLevel : MonoBehaviour
{

    public float interactRange = 5f;
    public int levelScene = 2;

    public GameObject equipmentObject;
    public GameObject userInterface;
    public GameObject spawns;

    public Camera playerCam;

    public string towerDoorName1;
    public int outSpawnIndex1 = 0;
    public string towerDoorName2;
    public int outSpawnIndex2 = 0;
    public string towerDoorName3;
    public int outSpawnIndex3 = 0;
    public string towerDoorName4;
    public int outSpawnIndex4 = 0;
    public GameObject tunnelEntry;

    static bool isTunnelDug = false;
    static bool firstTime = true;

    string firstInfo = "Goal: Escape from prison";
    static int doorThreeTries;
    //eq:
    bool haveKey = false;


    int currentScene;

    // Start is called before the first frame update
    void Start()
    {
        currentScene = SceneManager.GetActiveScene().buildIndex;

        if (isTunnelDug == true)
		{
            tunnelEntry.GetComponent<MeshRenderer>().enabled = true;
        }

        if (firstTime)
		{
            Invoke("FirstTime", 0.5f);

            doorThreeTries = 0;
            firstTime = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        haveKey = equipmentObject.transform.GetComponent<EquipmentManager>().Key();

        if (Input.GetKeyDown(KeyCode.E))
        {
            RaycastHit hit;
            if (Physics.Raycast(playerCam.transform.position, playerCam.transform.forward, out hit, interactRange))
            {
                //scene change
                if (hit.transform.name == towerDoorName1)
                {
                    ChangeSpawnIndex(outSpawnIndex1);
                    SceneManager.LoadScene(currentScene + 1);
                }
                if (hit.transform.name == towerDoorName2)
                {
                    ChangeSpawnIndex(outSpawnIndex2);
                    SceneManager.LoadScene(currentScene + 2);
                }
                if (hit.transform.name == towerDoorName3)
                {
                    /*
                    ChangeSpawnIndex(outSpawnIndex3);
                    SceneManager.LoadScene(currentScene + 3);
                    */
                    if (doorThreeTries < 4)
                    {
                        userInterface.GetComponent<UIBehaviour>().Talk("Don't go in there", 0f, 0f, 1f);
                        doorThreeTries++;
                    }
                    else
                    {
                        userInterface.GetComponent<UIBehaviour>().Talk("I said don't go in there", 0.2f, 0f, 0.8f);
                    }
                }
                if (hit.transform.name == towerDoorName4)
                {
                    ChangeSpawnIndex(outSpawnIndex4);
                    SceneManager.LoadScene(currentScene + 4);
                }

                if (hit.transform.gameObject == tunnelEntry && isTunnelDug)
                {
                    if (equipmentObject.GetComponent<EquipmentManager>().Key())
                    {
                        SceneManager.LoadScene(7);
                    }
					else
					{
                        userInterface.GetComponent<UIBehaviour>().Talk("It's locked", 0f, 0f, 1f);
                    }
                }

                if (hit.transform.gameObject == tunnelEntry && equipmentObject.GetComponent<EquipmentManager>().Spade())
                {
                    hit.transform.gameObject.GetComponent<MeshRenderer>().enabled = true;
                    isTunnelDug = true;
                }
            }
        }
    }

    void ChangeSpawnIndex(int index)
    {
        EquipmentManager equipment = equipmentObject.transform.GetComponent<EquipmentManager>();

        equipment.ChangeSpawnIndex(index);
    }

    void FirstTime()
	{
        userInterface.GetComponent<UIBehaviour>().Talk(firstInfo, 0, 0, 255);
    }
}
