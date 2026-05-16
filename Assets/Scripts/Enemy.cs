using UnityEngine;


public class Enemy : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private Transform place;

    private Rigidbody2D rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        place = GameObject.FindGameObjectWithTag("Safeplace").transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 direction = (place.position - transform.position).normalized;
        rb.linearVelocity = direction * moveSpeed;
        // transform.position = Vector2.MoveTowards(transform.position, place.position, moveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject
                .GetComponent<Health>()
                .TakeDamage(3);

            Destroy(collision.gameObject);
        }
    }
}
