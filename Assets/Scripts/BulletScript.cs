using UnityEngine;

public class BulletScript : MonoBehaviour
{
    [SerializeField] private float bulletDamage;
    private Vector3 mousePos;
    private Camera mainCam;
    private Rigidbody2D rb;
    private Enemy enemy;
    public float force;


    void OnCollisionEnter2D(Collision2D collision)
    {
        // Nếu trúng enemy
        if (collision.gameObject.CompareTag("Enemy"))
        {
            enemy = collision.gameObject.GetComponent<Enemy>();

            if (enemy != null)
            {
                enemy.TakeDamage(bulletDamage);
            }
            
            // Destroy(collision.gameObject); // hủy enemy
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
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = mousePos - transform.position;
        Vector3 rotation = transform.position - mousePos;
        rb.linearVelocity = new Vector2(direction.x, direction.y).normalized * force;
        float rot = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
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

    public void SetSpeed(float bulletSpeed)
    {
        force = bulletSpeed;
    }
}
