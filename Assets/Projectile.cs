using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed;
    private bool hit;
    private BoxCollider2D boxCollider;
    private Animator anim;
    private float lifetime;
    public AudioSource shotHitSFX;


    private void Awake()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
        shotHitSFX = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (hit)
        {
            return;
        }

        float movementSpeed = speed * Time.deltaTime;
        transform.Translate(movementSpeed, 0, 0);

        lifetime += Time.deltaTime;
        if (lifetime > 5) gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag != "Middle")
        {
            shotHitSFX.Play();
            hit = true;
            boxCollider.enabled = false;
            anim.SetTrigger("Explode");
        }
    }

    public void SetDirection()
    {
        lifetime = 0;
        gameObject.SetActive(true);
        hit = false;
        boxCollider.enabled = true;
    }

    private void Deactivate()
    {
        gameObject.SetActive(false);
    }
}
