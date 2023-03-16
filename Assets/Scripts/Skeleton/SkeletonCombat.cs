using UnityEngine.AI;
using UnityEngine;
using System.Collections;

public class SkeletonCombat : MonoBehaviour
{
    public GameObject target;

    public Transform cam;

    public Player player;
    public HealthBar healthBar;
    public EnemyManager enemyManager;

    private NavMeshAgent agent;
    private Animator anim;

    private bool isReloaded = true;
    private bool canHit;

    [SerializeField] private float reloadTime;
    [SerializeField] private Transform hitPoint;
    [SerializeField] private float radius;


    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();

        healthBar.SetMaxHealth(enemyManager.health);
    }

    private void Update()
    {
        bool isDistance = Vector3.Distance(transform.position, target.transform.position) < agent.stoppingDistance;
        canHit = isDistance;

        if (enemyManager.health <= 0)
        {
            canHit = false;
        }

        if (canHit && isReloaded)
        {
            ReadColliders();
            StartCoroutine(Reload());
        }

        healthBar.transform.LookAt(cam.position);
    }

    IEnumerator Reload()
    {
        isReloaded = false;
        yield return new WaitForSeconds(reloadTime);
        isReloaded = true;
    }

    private void ReadColliders()
    {
        Collider[] colliders = Physics.OverlapSphere(hitPoint.position, radius);

        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].TryGetComponent(out Player person))
            {
                if (player.GetComponent<PlayerStats>().Health > 0)
                {
                    anim.SetTrigger("Hit");
                }
            }
        }
    }

    private void DecreasePlayerHP()
    {
        player.TakeDamage(enemyManager.damage);
    }

    public void TakeDamage(int damage)
    {
        if (enemyManager.health <= 0)
        {
            anim.SetTrigger("Death");
        }
        else if (enemyManager.health - damage <= 0)
        {
            enemyManager.health -= damage;
            healthBar.SetHealth(enemyManager.health);
            anim.SetTrigger("Death");
        }
        else if (enemyManager.health > 0)
        {
            enemyManager.health -= damage;
            healthBar.SetHealth(enemyManager.health);
            anim.SetTrigger("Damage");
        }
    }

    private void DestroyEnemyEvent()
    {
        Destroy(gameObject);
        PlayerStats.Money += enemyManager.moneyFrom;
    }

}


