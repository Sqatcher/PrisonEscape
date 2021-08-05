using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafetyNetScript : MonoBehaviour
{
	public GameObject player;

	private void OnTriggerEnter(Collider other)
	{
		Debug.Log("TRIGGER");
		player.GetComponent<PlayerSpawn>().Spawn();
		player.GetComponent<PlayerMovement>().SetVelocity(0f, 0f, 0f);
	}
}
