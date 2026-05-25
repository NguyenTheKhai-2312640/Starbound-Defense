using UnityEngine;

public class EnemyKnockback : MonoBehaviour
{
    [SerializeField]
    private float damageAmount;

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerMovement>())
        {
            var armorController = collision.gameObject.GetComponent<PlayerArmor>();
            armorController.TakeDamage(damageAmount);
        }
    }
}