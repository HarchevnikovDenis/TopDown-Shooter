using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 2.0f;

    private Joystick joystick;
    private new Transform transform;

    // Обращение к полю transform происходит каждый кадр, поэтому лучше получить эту ссылку в самом начале
    private void Start()
    {
        transform = gameObject.transform;
        joystick = FindObjectOfType<FixedJoystick>();
    }


    private void Update()
    {
        Move();
    }

    private void Move()
    {
        float horizontal = joystick.Horizontal;
        float vertical = joystick.Vertical;

        Vector3 movement = new Vector3(horizontal, 0.0f, vertical).normalized;
        movement = transform.position + movement;

        transform.position = Vector3.MoveTowards(transform.position, movement, movementSpeed * Time.deltaTime);
    }
}
