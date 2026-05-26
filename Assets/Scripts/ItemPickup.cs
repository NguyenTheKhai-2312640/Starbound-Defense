using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public enum PickupType { Armor, Coin }

    [Header("Item pickup")]
    [SerializeField] private PickupType type;
    [SerializeField] private float itemAmount;


    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (type == PickupType.Armor)
            {
                collision.gameObject.GetComponent<PlayerArmor>().AddArmor(itemAmount);
                Destroy(gameObject);
            }
            else if (type == PickupType.Coin)
            {
                collision.gameObject.GetComponent<MoneyManager>().AddCoins(itemAmount);
                Destroy(gameObject);
            }

        }
    }


}
