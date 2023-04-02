using UnityEngine;
using System.Collections;

public class Punch : MonoBehaviour
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

    }

    public IEnumerator MakePunchCoroutine()
    {
        makePunch = true;
        if (EquipmentManager.instance.currentEquipment[1] != null)
            anim.SetTrigger("WeaponPunch");
        else
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
        if (EquipmentManager.instance.currentEquipment[1] != null)
        {
            hitPoint = EquipmentManager.instance.currentMeshes[1].gameObject.transform.Find("HitPoint").transform;
            radius = EquipmentManager.instance.currentEquipment[1].weaponRadius;
        }

        Collider[] colliders = Physics.OverlapSphere(hitPoint.position, radius);

        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].TryGetComponent(out Combat enemy))
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
            if (colliders[i].TryGetComponent(out EnemyStats enemy))
            {
                enemy.TakeDamage(gameObject.GetComponent<PlayerStats>().damage.GetValue());
            }
        }

    }
}
