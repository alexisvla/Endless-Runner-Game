using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chicken : MonoBehaviour
{
    [SerializeField] float turnSpeed = 90f;

	private void OnTriggerEnter(Collider other)
	{

        if (other.gameObject.GetComponent<Obstacle>() != null)
        {
            Destroy(gameObject);
            return;
        }

        //check the object we collided with is the player
        if (other.gameObject.name != "Player")
        {
            return;
        }

        //add the player's Score
        GameManager.Instance.IncrementScore();

        //destroy the chicken
        Destroy(gameObject);
    }

	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0,0,turnSpeed * Time.deltaTime);
    }
}
