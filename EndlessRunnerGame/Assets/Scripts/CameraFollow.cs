using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform player;
    Vector3 offset;


	private void Start()
	{
		offset = transform.position - player.position;
	}
	void Update()
    {
        Vector3 targetpos = player.position + offset;
		targetpos.x = 0;
		transform.position = targetpos;
    }
}
