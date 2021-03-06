using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager : MonoBehaviour
{
    static bool haveKey = false;
    static bool haveSpade = false;
    static bool haveMap = false;
	static bool isFirstTime = true;
	static int spawnIndex = 0;


	public void HaveKey (bool key)
	{
		haveKey = key;
	}
	public bool Key()
	{
		return haveKey;
	}

	public void HaveSpade(bool spade)
	{
		haveSpade = spade;
	}
	public bool Spade()
	{
		return haveSpade;
	}

	public void HaveMap(bool map)
	{
		haveMap = map;
	}
	public bool Map()
	{
		return haveMap;
	}

	public void ChangeSpawnIndex(int index)
	{
		spawnIndex = index;
	}

	public int SpawnIndex()
	{
		return spawnIndex;
	}

	public void ChangeFirstTime(bool index)
	{
		isFirstTime = index;
	}

	public bool FirstTime()
	{
		return isFirstTime;
	}

	public void ResetEquipment()
	{
		haveKey = false;
		haveSpade = false;
		haveMap = false;
		isFirstTime = true;
		spawnIndex = 0;
	}
}
