using UnityEngine;

public class FuelCollectable : MonoBehaviour
{

    private bool available;
    private float moveSpeed = 5;
    private float deadZone = -35;
    public BirdScript bird;
    public FuelScript fuel;
    private Animator anim;
    public AudioSource pickupSFX;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        bird = GameObject.FindGameObjectWithTag("Bird").GetComponent<BirdScript>();
        fuel = GameObject.FindGameObjectWithTag("Bird").GetComponent<FuelScript>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * moveSpeed * Time.deltaTime;
        if (transform.position.x < deadZone)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 3 && bird.birdIsAlive)
        {
            pickupSFX.Play();
            fuel.AddFuel(fuel.startingFuel / 2);
            gameObject.GetComponent<Renderer>().enabled = false;
        }
    }
}
