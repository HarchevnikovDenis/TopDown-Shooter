using UnityEngine;

public class EnemyShooting : GeneralShooting
{
    private new Transform transform;

    private void Start()
    {
        transform = gameObject.transform;
        target = FindObjectOfType<PlayerShooting>().gameObject.transform;
        rate = Random.Range(1.0f, 4.0f);
    }

    private void Update()
    {
        if(target == null)
        {
            return;
        }

        transform.LookAt(target);

        if(timeSinceLastShoot >= rate)
        {
            Shoot();
        }
        else
        {
            timeSinceLastShoot += Time.deltaTime;
        }
    }
}
