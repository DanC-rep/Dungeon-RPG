using UnityEngine;
using System.Collections;

public class HandPunch : Fighting
{
    private Animator anim;

    [HideInInspector]
    public bool makePunch { get; private set; } = false;

    public PlayerController playerController;

    [SerializeField] private Transform hitPoint;
    [SerializeField] private float radius;


    private void Start()
    {
        anim = GetComponent<Animator>();

        Damage = 5;

    }

    public IEnumerator MakePunchCoroutine()
    {
        makePunch = true;
        anim.SetTrigger("Punch");
        if (playerController.target != null && Vector3.Distance(transform.position, playerController.target.position) <= radius * 3)
        {
            transform.LookAt(playerController.target.position);
        }
        yield return new WaitForSeconds(1);
        makePunch = false;
    }

    public void MakePunch()
    {
        Collider[] colliders = Physics.OverlapSphere(hitPoint.position, radius);

        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].TryGetComponent(out SkeletonCombat skeleton))
            {
                StartCoroutine(MakePunchCoroutine());
            }
            else
            {
                StartCoroutine(MakePunchCoroutine());
            }
        }
    }

    private void DecreaseEnemyHP()
    {
        Collider[] colliders = Physics.OverlapSphere(hitPoint.position, radius);

        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].TryGetComponent(out SkeletonCombat skeleton))
            {
                skeleton.TakeDamage(Damage);
            }
        }

    }
}
