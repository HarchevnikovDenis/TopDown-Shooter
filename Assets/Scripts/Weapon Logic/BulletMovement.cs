using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    [SerializeField] private float movementSpeed;
    private new Transform transform;
    private Vector3 forward;

    private void Start()
    {
        transform = gameObject.transform;
        forward = transform.forward.normalized;
        Destroy(gameObject, 10.0f);
    }

    private void Update()
    {
        transform.position += forward * movementSpeed * Time.deltaTime;
    }
}
