using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIBehaviour : MonoBehaviour
{
    public GameObject equipmentObject;

    public Text dialogueText;
    public Image mapImage;
    public GameObject icons;

    bool isMapToBeActive = true;

    public GameObject[] iconArray;
    public bool[] iconArrayFull;

    public string mapName = "Map";
    public string spadeName = "Spade";
    public string keyName = "Key";
    

    // Start is called before the first frame update
    void Start()
    {
        CreateIconArray();
        ClearText();
        ShowMap(false);

        
        if (equipmentObject.transform.GetComponent<EquipmentManager>().Map())
		{
            LoadIcon(Resources.Load<Sprite>(mapName));
		}

        if (equipmentObject.transform.GetComponent<EquipmentManager>().Spade())
        {
            LoadIcon(Resources.Load<Sprite>(spadeName));
        }

        if (equipmentObject.transform.GetComponent<EquipmentManager>().Key())
        {
            LoadIcon(Resources.Load<Sprite>(keyName));
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z) && equipmentObject.transform.GetComponent<EquipmentManager>().Map())
		{
            ShowMap(isMapToBeActive);
            if (isMapToBeActive)
			{
                isMapToBeActive = false;
			}
            else
			{
                isMapToBeActive = true;
			}
		}
    }

    public void Talk(string text, int r=170, int g=255, int b=0)
    {
        dialogueText.text = text;
        dialogueText.color = new Color(r, g, b);
        Debug.Log(text);
        Debug.Log(r);

        Invoke("ClearText", 3);
    }

    void ClearText()
    {
        dialogueText.text = null;
    }

    void ShowMap(bool isToBeActive)
	{
        if (isToBeActive)
		{
            //appear
            mapImage.color = new Color(1, 1, 1, 1);
        }
        else
		{
            //disappear
            mapImage.color = new Color(1, 1, 1, 0);
        }
	}

    /*

    public void ShowMapIcon(bool show)
	{
        if (show)
		{
            mapIcon.color = new Color(1, 1, 1, 1);
        }
        else
		{
            mapIcon.color = new Color(1, 1, 1, 0);
        }
	}
    */

    void CreateIconArray()
	{
        iconArray = new GameObject[icons.transform.childCount];
        iconArrayFull = new bool[icons.transform.childCount];
        for (int i=0; i<icons.transform.childCount; i++)
		{
            iconArray[i] = icons.transform.GetChild(i).gameObject;
            icons.transform.GetChild(i).gameObject.SetActive(false);
            iconArrayFull[i] = false;
		}
	}

    public void LoadIcon(Sprite image)
	{
        for (int i=0; i<iconArray.Length; i++)
		{
            if (iconArrayFull[i] == false)
			{
                iconArray[i].SetActive(true);
                iconArray[i].GetComponent<Image>().sprite = image;
                iconArrayFull[i] = true;
                break;
			}
		}
	}
}
