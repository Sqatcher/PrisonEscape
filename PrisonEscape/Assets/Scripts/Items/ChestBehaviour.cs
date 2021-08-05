using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestBehaviour : MonoBehaviour
{
    public GameObject wiekoOpen;
    public GameObject wiekoClose;

    
    public void OpenChest()
	{
        wiekoClose.SetActive(false);
        wiekoOpen.SetActive(true);
    }
}
