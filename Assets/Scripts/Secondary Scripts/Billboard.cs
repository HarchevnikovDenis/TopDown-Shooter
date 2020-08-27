using UnityEngine;

public class Billboard : MonoBehaviour
{
    private new Transform transform;
    private Transform target;

    private void Start()
    {
        transform = gameObject.transform;
        target = Camera.main.transform;
    }

    private void Update()
    {
        transform.LookAt(target);
    }
}
