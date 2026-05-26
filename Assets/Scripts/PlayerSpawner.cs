using UnityEngine;
using System.Collections;

public class PlayerSpawner : MonoBehaviour
{
    [SerializeField] private float coolDownTime;
    [SerializeField] private Vector2 startPos;
    [SerializeField] private GameObject playerSprite;
    private Rigidbody2D playerRb;
    private PlayerArmor playerArmor;
    private PlayerShooter playerShooter;
    private Coroutine respawnCoroutine;
    private float currentTime;
    private bool isRespawning;

    void Awake()
    {
        playerRb = GetComponent<Rigidbody2D>();
        playerArmor = GetComponent<PlayerArmor>();
        playerShooter = GetComponent<PlayerShooter>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    // void Update()
    // {

    // }

    public void RespawnPlayer()
    {
        if (isRespawning) return;

        respawnCoroutine = StartCoroutine(Respawn(coolDownTime));
    }

    IEnumerator Respawn(float duration)
    {
        Debug.Log("RESPAWN STARTED");

        isRespawning = true;

        // turn off player
        playerRb.linearVelocity = Vector2.zero;
        playerRb.simulated = false;
        transform.localScale = Vector3.zero;
        playerShooter.canShoot = false;

        // cooldown
        yield return new WaitForSeconds(duration);

        // respawn
        transform.position = startPos;

        // reset armor
        playerArmor.ReviveFull();

        // turn on player
        playerRb.simulated = true;
        transform.localScale = Vector3.one;
        playerShooter.canShoot = true;

        isRespawning = false;
        respawnCoroutine = null;

        Debug.Log("RESPAWN FINISHED");
    }
}
