using UnityEngine;

public class RobotAttack : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject[] shots;
    private Animator anim;
    private BirdScript robot;
    private float cooldownTimer = Mathf.Infinity;
    public AudioSource shotSFX;


    private void Awake()
    {
        anim = GetComponent<Animator>();
        robot = GetComponent<BirdScript>();
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.X) && cooldownTimer > attackCooldown && CanAttack())
        {
            Attack();
        }
        cooldownTimer += Time.deltaTime;
    }

    private void Attack()
    {
        shotSFX.Play();
        anim.SetTrigger("Attack");
        cooldownTimer = 0;
        shots[FindShot()].transform.position = firePoint.position;
        shots[FindShot()].GetComponent<Projectile>().SetDirection();
    }

    private int FindShot()
    {

        for (int i = 0; i < shots.Length; i++)
        {
            if (!shots[i].activeInHierarchy)
            {
                return i;
            }
        }
        return 0;
    }

    private bool CanAttack()
    {
        if (cooldownTimer > attackCooldown && robot.birdIsAlive) return true;
        return false;
    }
}
