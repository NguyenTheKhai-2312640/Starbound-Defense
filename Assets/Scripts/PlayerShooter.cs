using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;

public class PlayerShooter : MonoBehaviour
{
    [SerializeField] private float bulletSpeed;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform rotationPoint;
    [SerializeField] private Transform gunOffset;
    [SerializeField] private float timeBetweenShots;
    [SerializeField] private bool canShoot;

    private Camera mainCam;
    private Vector3 mousePos;
    private float timer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        // Không cho xử lý khi pause
        if (GameManager.isPaused)
            return;

        // Gun offset
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 rotation = mousePos - rotationPoint.position;
        float rotz = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        rotationPoint.rotation = Quaternion.Euler(0, 0, rotz);

        // Gun shooting
        if (!canShoot)
        {
            timer += Time.deltaTime;
            if (timer > timeBetweenShots)
            {
                canShoot = true;
                timer = 0;
            }
        }

        if (Input.GetMouseButton(0) && canShoot)
        {
            canShoot = false;
            Instantiate(bulletPrefab, gunOffset.position, rotationPoint.rotation);
        }
    }
}
