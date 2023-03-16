using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class Movement : MonoBehaviour
{
    private NavMeshAgent agent;
    private Animator anim;

    public GameObject target;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
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

        agent.destination = target.transform.position;
        transform.LookAt(target.transform);
    }
}
