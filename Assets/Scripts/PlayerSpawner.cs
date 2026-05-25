using UnityEngine;
using TMPro;
using System.Collections;

public class PlayerSpawner : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timeText;
    [SerializeField] private float coolDownTime;
    [SerializeField] private Vector2 startPos;
    [SerializeField] private GameObject playerSprite;
    private Rigidbody2D playerRb;
    private PlayerArmor playerArmor;
    private Coroutine respawnCoroutine;
    private float currentTime;
    private bool isRespawning;

    void Awake()
    {
        playerRb = GetComponent<Rigidbody2D>();
        playerArmor = GetComponent<PlayerArmor>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startPos = transform.position;
        timeText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void RespawnPlayer()
    {
        Debug.Log("Respawn triggered");
        if (isRespawning) return;

        respawnCoroutine = StartCoroutine(Respawn(coolDownTime));
    }

    IEnumerator Respawn(float duration)
    {
        Debug.Log("RESPAWN STARTED");

        isRespawning = true;

        // hiện text khi chết
        timeText.gameObject.SetActive(true);

        // turn off player
        playerRb.linearVelocity = Vector2.zero;
        playerRb.simulated = false;
        transform.localScale = Vector3.zero;

        // cooldown
        yield return new WaitForSeconds(duration);

        // respawn
        transform.position = startPos;

        // reset armor
        playerArmor.ReviveFull();

        // turn on player
        playerRb.simulated = true;
        transform.localScale = Vector3.one;

        // ẩn text
        timeText.gameObject.SetActive(false);

        isRespawning = false;
        respawnCoroutine = null;

        Debug.Log("RESPAWN FINISHED");
    }
}
