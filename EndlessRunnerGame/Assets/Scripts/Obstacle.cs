using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    PlayerMovements movements;
    void Start()
    {
        movements = GameObject.FindObjectOfType<PlayerMovements>();
    }

	private void OnCollisionEnter(Collision collision)
	{
        if(collision.gameObject.name == "Player")
        {
            movements.Die();
        }
		//Kill the player
	}

	void Update()
    {
        
    }
}
