using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpadeBehaviour : MonoBehaviour
{
    public GameObject equipmentObject;
    public GameObject userInterface;

    public string spadeName = "Spade";


    // Start is called before the first frame update
    void Start()
    {
        if (equipmentObject.transform.GetComponent<EquipmentManager>().Spade() == true)
        {
            DestroySpade();
        }
    }

    public void DestroySpade()
	{
        Destroy(gameObject);
	}

    public void GetSpade()
    {
        EquipmentManager equipment = equipmentObject.transform.GetComponent<EquipmentManager>();
        equipment.HaveSpade(true);

        userInterface.transform.GetComponent<UIBehaviour>().LoadIcon(Resources.Load<Sprite>(spadeName));

        DestroySpade();
    }
}
