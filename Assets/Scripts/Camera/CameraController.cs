using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float speed = 5;
    [SerializeField] private GameObject player;
    [SerializeField] private Vector3 offset;

    private void FixedUpdate()
    {
        Vector3 newPos = player.transform.position + offset;

        transform.position = Vector3.Lerp(transform.position, newPos, speed * Time.fixedDeltaTime);
    }
}
