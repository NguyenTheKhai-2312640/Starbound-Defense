using UnityEngine;

public class ItemDrop : MonoBehaviour
{
    [Header("Item chance")]
    [SerializeField] GameObject armorPickupPrefab;
    [SerializeField] GameObject coinPickupPrefab;
    [SerializeField] float armorDropChance = 0.2f; // 20%
    [SerializeField] float coinDropChance = 0.6f; // 60%


    public void TryDropItem()
    {
        float rand = Random.value;

        if (rand < armorDropChance)
        {
            DropItem(armorPickupPrefab);
        }
        else if (rand < armorDropChance + coinDropChance)
        {
            DropItem(coinPickupPrefab);
        }
    }

    void DropItem(GameObject prefab)
    {
        if (prefab != null)
        {
            Instantiate(prefab, transform.position, Quaternion.identity);
        }
    }
}
