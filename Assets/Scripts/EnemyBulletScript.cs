using UnityEngine;

public class EnemyBulletScript : MonoBehaviour
{
    [SerializeField] private float bulletDamage;
    private GameObject player;
    private Camera mainCam;
    private Rigidbody2D rb;
    private PlayerArmor playerArmor;
    public float force;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            return; // bỏ qua enemy
        }
        
        // Nếu trúng player
        if (collision.gameObject.CompareTag("Player"))
        {
            playerArmor = collision.gameObject.GetComponent<PlayerArmor>();

            if (playerArmor != null)
            {
                playerArmor.TakeDamage(bulletDamage);
            }

            Destroy(gameObject); // hủy bullet
        }
        else
        {
            // Va vào bất kỳ object nào khác
            Destroy(gameObject); // hủy bullet
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();

        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");

        Vector3 direction = player.transform.position - transform.position;
        rb.linearVelocity = new Vector2(direction.x, direction.y).normalized * force;

        float rot = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot + 90);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 viewPos = mainCam.WorldToViewportPoint(transform.position);

        if (viewPos.x < 0 || viewPos.x > 1 ||
            viewPos.y < 0 || viewPos.y > 1)
        {
            Destroy(gameObject);
        }
    }


}
