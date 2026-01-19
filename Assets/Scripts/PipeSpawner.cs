using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    [SerializeField] private float spawnTime = 1.5f;
    [SerializeField] private GameObject pipesPrefab;
    [SerializeField] private float height=1f;
    private void Start()
    {
        StartCoroutine(SpawnPipe());
    }
    private IEnumerator SpawnPipe()
    {
        while (true)
        {

            Instantiate(pipesPrefab, new Vector3(1f, Random.Range(-height, height), 0), Quaternion.identity);
            yield return new WaitForSeconds(spawnTime);
        }
    }

  
}
