using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    [SerializeField] GameObject GroundTile;
    Vector3 nextSpawnPoint;

    public void SpawnTile(bool SpawnItems)
    {
        GameObject temp = Instantiate(GroundTile, nextSpawnPoint, Quaternion.identity);
        nextSpawnPoint = temp.transform.GetChild(1).transform.position;

        if (SpawnItems)
        {
            temp.GetComponent<GroundTile>().spawnObstacles();
            temp.GetComponent<GroundTile>().spawnChickens();
        }
    }

    void Start()
    {
        for (int i = 0; i < 15; i++)
        {
            if (i < 2)
            {
				SpawnTile(false);
			}
            else
            {
				SpawnTile(true);
			}
        }
    }
}
