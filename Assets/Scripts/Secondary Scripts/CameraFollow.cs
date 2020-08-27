using UnityEditor;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private float smoothSpeed = 20.0f;
    [SerializeField] private Vector3 offset;

    private Transform target;
    private new Transform transform;

    private void Start()
    {
        target = FindObjectOfType<PlayerMovement>().gameObject.transform;
        transform = gameObject.transform;
    }

    private void LateUpdate()
    {
        if(target == null)
        {
            return;
        }

        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        transform.position = smoothedPosition;

    }

    public void FindNewTarget()
    {
        target = FindObjectOfType<PlayerMovement>().gameObject.transform;
    }
}
