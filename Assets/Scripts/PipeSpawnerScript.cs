using UnityEngine;

public class PipeSpawnerScript : MonoBehaviour
{

    public GameObject pipe;
    public float spawnRate = 2;
    private float timer = 0;
    private float heightOffset = 2;
    public bool justSpawned { get; private set; }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        justSpawned = false;
        spawnPipe();
        justSpawned = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < spawnRate)
        {
            timer += Time.deltaTime;
            justSpawned = false;
        }
        else
        {
            spawnPipe();
            timer = 0;
            justSpawned = true;
        }
    }

    void spawnPipe()
    {
        float lowestPoint = transform.position.y - heightOffset;
        float highestPoint = transform.position.y + heightOffset;
        Instantiate(pipe, new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint), 0), transform.rotation);
    }
}
