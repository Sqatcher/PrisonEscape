using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafetyNetScript : MonoBehaviour
{
	// NIE DZIALA

	//public GameObject player;

	private void OnTriggerEnter(Collider other)
	{
		Debug.Log("TRIGGER");

		//player.GetComponent<PlayerMovement>().SetVelocity(0f, 0f, 0f);
		other.GetComponent<PlayerMovement>().SetVelocity(0f, 0f, 0f);
		//player.GetComponent<PlayerSpawn>().Spawn();
		other.GetComponent<PlayerSpawn>().Spawn();
	}
}
