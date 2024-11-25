using System.Runtime.CompilerServices;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    public Rigidbody2D myRigidBody;
    public float engineStrength;
    public bool birdIsAlive = true;
    public LogicScript logic;
    public EngineScript engine;
    public FuelScript fuel;
    public Animator anim;
    public AudioSource explosionSFX;
    public AudioSource deathSFX;
    private float startTimer = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        myRigidBody.gravityScale = 0;
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        engine = GameObject.FindGameObjectWithTag("Engine").GetComponent<EngineScript>();
        fuel = GameObject.FindGameObjectWithTag("Bird").GetComponent<FuelScript>();
        anim = GetComponent<Animator>();
        engineStrength = 5;
    }

    // Update is called once per frame
    void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space) || startTimer > 150)
            {
                myRigidBody.gravityScale = 3;
            }
            else {
                startTimer++;
            }

            if (Input.GetKey(KeyCode.Space) && birdIsAlive && fuel.currentFuel > 0)
            {
                myRigidBody.linearVelocityY = engineStrength;
                fuel.UseFuel(1);   
            }

            if ((myRigidBody.position.y > 10 || myRigidBody.position.y < -10) && birdIsAlive)
            {
                deathSFX.Play();
                birdIsAlive = false;
                logic.gameOver();
            }
        }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ((collision.gameObject.name == "botPipe" || collision.gameObject.name == "topPipe") && birdIsAlive) 
        {
            explosionSFX.Play();
            myRigidBody.gravityScale = 0;
            anim.SetTrigger("Die");
            engine.anim.SetBool("engine_on", false);
            birdIsAlive = false;
            logic.gameOver();
        }
    }
}
