using UnityEngine.AI;
using UnityEngine;
using System.Collections;

public class Combat : MonoBehaviour
{
    public GameObject target;

    public Transform cam;

    public Player player;
    public HealthBar healthBar;
    public EnemyStats enemyStats;

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
        healthBar.SetMaxHealth(enemyStats.startHealth);

    }

    private void Update()
    {
        bool isDistance = Vector3.Distance(transform.position, target.transform.position) < agent.stoppingDistance;
        canHit = isDistance;

        if (enemyStats.Health <= 0)
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
        player.GetComponent<PlayerStats>().TakeDamage(enemyStats.damage.GetValue());
    }

    private void DestroyEnemyEvent()
    {
        Destroy(gameObject);
        PlayerPrefs.SetInt("Money", PlayerStats.Money + enemyStats.moneyFrom);
        PlayerStats.Money = PlayerPrefs.GetInt("Money");
    }

}


