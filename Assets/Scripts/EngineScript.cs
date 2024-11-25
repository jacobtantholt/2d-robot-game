using UnityEngine;

public class EngineScript : MonoBehaviour
{
    public Animator anim;
    public BirdScript robot;
    public AudioSource jetpackSFX;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = GetComponent<Animator>();  
        robot = GameObject.FindGameObjectWithTag("Bird").GetComponent<BirdScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && robot.birdIsAlive && robot.fuel.currentFuel > 0)
        {
            anim.SetBool("engine_on", true);
            jetpackSFX.Play();
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            anim.SetBool("engine_on", false);
            jetpackSFX.Stop();
        }
    }
}
