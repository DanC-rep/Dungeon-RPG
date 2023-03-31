using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class Movement : MonoBehaviour
{
    private NavMeshAgent agent;
    private Animator anim;

    public GameObject target;

    public Transform[] waypoints;
    public float distanceToChangeGoal;
    private int currentPoint = 0;

    private bool goToPlayer;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();

        agent.destination = waypoints[0].position;
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        if (agent.velocity != Vector3.zero)
            anim.SetBool("Move", true);
        else
            anim.SetBool("Move", false);

        if (Vector3.Distance(transform.position, target.transform.position) <= gameObject.GetComponent<SkeletonStats>().radius)
        {
            goToPlayer = true;
        }
        else
        {
            StartCoroutine(Patrol());
        }

        GoToPlayer();
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, gameObject.GetComponent<SkeletonStats>().radius);
    }

    void GoToPlayer() 
    {
        if (goToPlayer == true)
        {
            transform.LookAt(target.transform);
            agent.destination = target.transform.position;
        }
    }

    IEnumerator Patrol()
    {
        if (Vector3.Distance(transform.position, waypoints[currentPoint].position) < distanceToChangeGoal)
        {
            currentPoint += 1;
            if (currentPoint == waypoints.Length)
            {
                currentPoint = 0;
            }
            yield return new WaitForSeconds(3);
            agent.destination = waypoints[currentPoint].position;
            transform.LookAt(waypoints[currentPoint].position);
        }
    }
}
