using System.Collections.Generic;
using UnityEngine;

public class PipeController : MonoBehaviour
{
    public Transform SpawnPosition;
    public GameObject PipePrefab;
    public float PipeSpeed;
    public float PipeSpawnDelay;

    private float CurrentPipeSpawnDelay;
    private List<GameObject> Pipes = new List<GameObject>();

    // Update is called once per frame
    void Update()
    {
        for (int i = Pipes.Count - 1; i >= 0; i--)
        {
            GameObject pipe = Pipes[i];
            pipe.transform.position = pipe.transform.position + Vector3.left * PipeSpeed * Time.deltaTime;

            if(pipe.transform.position.x <= -5)
            {
                Destroy(pipe);
                Pipes.RemoveAt(i);
            }
        }

        CurrentPipeSpawnDelay += Time.deltaTime;

        if(CurrentPipeSpawnDelay < PipeSpawnDelay)
        {
            return;
        }

        CurrentPipeSpawnDelay = 0;

        Vector3 spawnPosition = SpawnPosition.position;
        spawnPosition.y += Random.Range(-0.8f, 0.8f);

        GameObject instantiatedObject = Instantiate(PipePrefab, spawnPosition, Quaternion.identity);
        Pipes.Add(instantiatedObject);
    }
}
