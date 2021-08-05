using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapBehaviour : MonoBehaviour
{
    public GameObject equipmentObject;
    public GameObject userInterface;

    public string mapName = "Map";

    void Start()
    {
        if (equipmentObject.transform.GetComponent<EquipmentManager>().Map() == true)
        {
            DestroyMap();
        }
    }
    public void GetMap()
	{
        EquipmentManager equipment = equipmentObject.transform.GetComponent<EquipmentManager>();
        equipment.HaveMap(true);

        userInterface.transform.GetComponent<UIBehaviour>().LoadIcon(Resources.Load<Sprite>(mapName));
        userInterface.transform.GetComponent<UIBehaviour>().Talk("To look at the map press Z!");

        DestroyMap();
    }

    public void DestroyMap()
	{
        Destroy(gameObject);
	}

}
