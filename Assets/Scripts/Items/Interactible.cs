using UnityEngine;

public class Interactible : MonoBehaviour
{
    public float radius = 3f;

    private Transform currentInteract;

    private Outline outline;
    public GameObject player;

    [HideInInspector]
    public bool interactible;

    public Item item;

    private void Start()
    {
        outline = gameObject.GetComponent<Outline>();
    }

    private void Update()
    {
        LineItem();
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

    private void LineItem()
    {
        if (player.GetComponent<PlayerController>().interact != null)
        {
            currentInteract = player.GetComponent<PlayerController>().interact.transform;
        }

        if (Vector3.Distance(player.transform.position, transform.position) < radius && currentInteract == transform)
        {
            outline.enabled = true;
            interactible = true;
        }
        else
        {
            outline.enabled = false;
            interactible = false;
        }
    }

    public void PickupItem()
    {
        Debug.Log(item.name);

        bool wasPickedUp = Inventory.instance.Add(item);

        if (wasPickedUp)
        {
            player.GetComponent<PlayerController>().PickupAnim();
            Destroy(gameObject);
        }

    }

    public void OpenDoor(GameObject door)
    {
        door.GetComponent<Animator>().SetTrigger("OpenDoor");
        interactible = false;
        door.GetComponent<Interactible>().enabled = false;
        door.GetComponent<Outline>().enabled = false;
        door.GetComponent<MeshCollider>().enabled = false;
    }
}
