using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Joystick joystick;
    public Punch Punch;

    private Rigidbody rb;
    private Animator anim;

    [HideInInspector]
    public Transform target;

    public Interactible interact;

    [SerializeField] private float speed = 5;

    bool isLoot = false;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();

        InvokeRepeating("UpdateTarget", 0f, 0.5f);
        InvokeRepeating("UpdateItemTarget", 0f, 0.5f);
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Update()
    {

        if (target == null || interact != null)
        {
            return;
        }

    }

    private void Move()
    {
        bool isMove = Mathf.Abs(joystick.Direction.x) > 0.1 || Mathf.Abs(joystick.Direction.y) > 0.1;

        if (isMove && (Punch.makePunch || isLoot))
        {
            rb.velocity = Vector3.zero;
        }
        else if (isMove && gameObject.GetComponent<PlayerStats>().Health > 0)
        {

            anim.SetBool("IsRunning", true);
            Vector3 movement = new Vector3(joystick.Horizontal, 0.0f, joystick.Vertical);
            rb.AddForce(movement * speed * 2);
            transform.forward = Vector3.Normalize(movement);
        }
        else
            anim.SetBool("IsRunning", false);
    }

    public void PickupAnim()
    {
        StartCoroutine(PickupCoroutine());
    }

    IEnumerator PickupCoroutine()
    {
        isLoot = true;
        anim.SetTrigger("Loot");
        yield return new WaitForSeconds(2.05f);
        isLoot = false;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, PlayerStats.range);
    }

    private void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;


        foreach (var enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);

            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && shortestDistance <= PlayerStats.range)
        {
            target = nearestEnemy.transform;
        }
        else
        {
            target = null;
        }
    }

    private void UpdateItemTarget()
    {
        GameObject[] items = GameObject.FindGameObjectsWithTag("Item");
        float shortestDistance = Mathf.Infinity;
        GameObject nearestItem = null;


        foreach (var item in items)
        {
            float distanceToItem = Vector3.Distance(transform.position, item.transform.position);

            if (distanceToItem < shortestDistance)
            {
                shortestDistance = distanceToItem;
                nearestItem = item;
            }
        }

        if (nearestItem != null && shortestDistance <= nearestItem.GetComponent<Interactible>().radius)
        {
            interact = nearestItem.GetComponent<Interactible>();

        }
        else
        {
            interact = null;
        }
    }

    public void AddSpeed(int addSpeed)
    {
        speed += addSpeed;
    }
}
