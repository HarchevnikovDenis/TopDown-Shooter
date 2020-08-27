using UnityEngine;

// Реализовал дополнительный функционал подбора очков здоровья
[RequireComponent(typeof(Animator))]
public class PickUpHP : MonoBehaviour
{
    [SerializeField] private float extraHP;
    [SerializeField] private Animator animator;
    private bool isCollected;

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.GetComponent<PlayerMovement>() && !isCollected)
        {
            HealthController player = other.gameObject.GetComponent<HealthController>();
            if(player != null)
            {
                if(!player.isHealthPointsFull())
                {
                    isCollected = true;
                    player.GetExtraHP(extraHP);
                    animator.SetTrigger("Collect");
                }
            }
        }
    }

    private void Remove()
    {
        Destroy(gameObject);
    }
}
