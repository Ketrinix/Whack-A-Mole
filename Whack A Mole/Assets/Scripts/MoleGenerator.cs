using System.Collections;
using UnityEngine;

public class MoleGenerator : MonoBehaviour
{
    public GameObject molePrefab;
    public Transform[] spawnPoints;
    public float spawnInterval;

    private void Start()
    {
        StartCoroutine(SpawnTopos());
    }

    private IEnumerator SpawnTopos()
    {
        while (true)
        {
            if (spawnPoints.Length > 0)
            {
                int randomIndex = Random.Range(0, spawnPoints.Length);

                Hole selectedHole = spawnPoints[randomIndex].GetComponent<Hole>();

                if (selectedHole != null && !selectedHole.isOccupied)
                {
                    selectedHole.isOccupied = true;

                    GameObject moleGO = Instantiate(molePrefab, spawnPoints[randomIndex].position, Quaternion.identity);
                }
            }

            yield return new WaitForSeconds(spawnInterval);
        }
    }
}