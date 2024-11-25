using UnityEngine;

public class FuelSpawnerScript : MonoBehaviour
{

    public GameObject fuelCollectable;
    public FuelScript fuelScript;
    public PipeSpawnerScript pipeSpawner;
    private bool justSpawned;
    private float timer;
    private float spawnCooldown = 5;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timer = spawnCooldown;
        justSpawned = false;
        fuelScript = GameObject.FindGameObjectWithTag("Bird").GetComponent<FuelScript>();
        pipeSpawner = GameObject.FindGameObjectWithTag("PipeSpawner").GetComponent<PipeSpawnerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (justSpawned)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                justSpawned = false;
                timer = spawnCooldown;
            }
        }
        if ((fuelScript.currentFuel < fuelScript.startingFuel / 3) && !pipeSpawner.justSpawned && !justSpawned)
        {
            SpawnFuel();
        }
    }

    private void SpawnFuel()
    {
        Instantiate(fuelCollectable, new Vector3(transform.position.x, transform.position.y, 0), transform.rotation);
        justSpawned = true;
    }
}
