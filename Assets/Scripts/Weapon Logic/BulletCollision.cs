using UnityEngine;

[RequireComponent(typeof(Animator))]
public class BulletCollision : MonoBehaviour
{
    [SerializeField] private GameObject playerHit;
    [SerializeField] private GameObject enemyHit;
    [SerializeField] private GameObject wallHit;
    [SerializeField] private Animator animator;

    public float damage { private get; set; }
    public bool isPlayer { get; set; }
    
    private void Start()
    {
        GameSettings settings = FindObjectOfType<GameSettings>();
        if(settings == null)
        {
            return;
        }

        UpdateBulletDamageValue(settings);
    }

    public void UpdateBulletDamageValue(GameSettings settings)
    {
        if (isPlayer)
        {
            damage = settings.PlayerDamage;
        }
        else
        {
            damage = settings.EnemyDamage;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Попадание в персонажей
        if(collision.gameObject.GetComponent<GeneralShooting>())
        {
            // Изменение здоровья цели
            TakeDamage(collision.gameObject.GetComponent<HealthController>());


            // Отображение эффектов
            if(collision.gameObject.GetComponent<PlayerShooting>())
            {
                ShowEffect(playerHit);
            }
            else
            {
                ShowEffect(enemyHit);
            }
        }
        else
        {
            ShowEffect(wallHit);
        }

        animator.SetTrigger("Collision");
    }

    private void TakeDamage(HealthController health)
    {
        health?.ToUpdateHealthIndicator(damage);
    }

    private void ShowEffect(GameObject effect)
    {
        GameObject newEffect = Instantiate(effect, transform.position, transform.rotation);
        Destroy(newEffect, 5.0f);
    }

    private void Remove()
    {
        Destroy(gameObject);
    }
}
