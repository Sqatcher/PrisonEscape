using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyBehaviour : MonoBehaviour
{
    public GameObject equipmentObject;
    public GameObject userInterface;

    public string keyName = "Key";

    // Start is called before the first frame update
    void Start()
    {
        if (equipmentObject.transform.GetComponent<EquipmentManager>().Key() == true)
		{
            DestroyKey();
		}
    }

    public void DestroyKey()
    {
        Destroy(gameObject);
    }

    public void GetKey()
	{
        EquipmentManager equipment = equipmentObject.transform.GetComponent<EquipmentManager>();
        equipment.HaveKey(true);

        userInterface.transform.GetComponent<UIBehaviour>().LoadIcon(Resources.Load<Sprite>(keyName));

        DestroyKey();
    }
}
