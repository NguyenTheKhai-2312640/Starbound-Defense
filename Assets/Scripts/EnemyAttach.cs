using UnityEngine;

public class EnemyAttach : MonoBehaviour
{
    [SerializeField]
    private float damageAmount;

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlaceActive>())
        {
            var healthController = collision.gameObject.GetComponent<Health>();
            healthController.TakeDamage(damageAmount);
        }
    }
}
