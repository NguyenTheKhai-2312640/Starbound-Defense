using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public enum PickupType { Armor, Coin }

    [Header("Item pickup")]
    [SerializeField] private PickupType type;
    [SerializeField] private float itemAmount;

    [Header("Audio")]
    [SerializeField] private AudioClip coinsSFX;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }


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

                // play sound FX
                audioSource.clip = coinsSFX;
                audioSource.Play();
                
                Destroy(gameObject, coinsSFX.length);
            }

        }
    }
}
