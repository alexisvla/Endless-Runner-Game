using Unity.VisualScripting;
using UnityEngine;

public class GroundTile : MonoBehaviour
{
 
    GroundSpawner spawner;
	[SerializeField] GameObject ObstaclePrefabs;
	[SerializeField] GameObject ChickenPrefabs;


	void Start()
    {
        spawner = GameObject.FindObjectOfType<GroundSpawner>();
    }

	private void OnTriggerExit(Collider other)
	{
        spawner.SpawnTile(true);
        Destroy(gameObject,2);
	}

    

    public void spawnObstacles()
    {
        //choose a random point

        int obstacleSpawnIndex = Random.Range(2, 5);
        Transform spawnPoint = transform.GetChild(obstacleSpawnIndex).transform;

        //spawn at the position
        Instantiate(ObstaclePrefabs, spawnPoint.position, Quaternion.identity, transform);
    }


    public void spawnChickens()
    {
        int ChickenToSpawn = 10;
        for (int i = 0; i < ChickenToSpawn; i++)
        {
            GameObject temp = Instantiate(ChickenPrefabs, transform);
            temp.transform.position = GetRandomPointInCollider(GetComponent<Collider>());
        }
    }

    Vector3 GetRandomPointInCollider(Collider collider)
    {
        Vector3 point = new Vector3(
            Random.Range(collider.bounds.min.x, collider.bounds.max.x),
            Random.Range(collider.bounds.min.y, collider.bounds.max.y),
            Random.Range(collider.bounds.min.z, collider.bounds.max.z)
            );

        if (point != collider.ClosestPoint(point))
        {
            point = GetRandomPointInCollider(collider);
        }

        point.y = 1;
        return point;
    }
}
