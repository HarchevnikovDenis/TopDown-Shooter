using UnityEngine;

[RequireComponent(typeof(HealthController))]
public class GeneralShooting : MonoBehaviour
{
    [SerializeField] protected Transform pistolTransform;
    [SerializeField] protected GameObject bullet;
    [SerializeField] protected float rate = 2.0f;

    protected float timeSinceLastShoot;
    protected Transform target;

    protected void Shoot()
    {
        GameObject newBullet = Instantiate(bullet, pistolTransform.position, transform.rotation);
        if(gameObject.GetComponent<PlayerShooting>())
        {
            newBullet.GetComponent<BulletCollision>().isPlayer = true;
        }
        timeSinceLastShoot = 0.0f;
    }
}
