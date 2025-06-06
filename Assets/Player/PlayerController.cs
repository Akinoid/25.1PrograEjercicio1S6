using UnityEngine;
using System;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 6f;
    public float dashDistance = 5f;
    public float dashCooldown = 2f;
    public float dashDuration = 0.2f;

    [Header("Shooting")]
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float bulletSpeed = 15f;
    public float fireCooldown = 0.2f;

    private CharacterController controller;
    private Camera cam;
    private Vector3 velocity;
    private float lastFireTime;
    private float lastDashTime;
    private bool isDashing = false;
    private Vector3 dashDirection;
    private float dashTimer;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
        cam = Camera.main;
    }

    private void Update()
    {
        HandleMovement();
        HandleRotation();
        HandleShooting();
        HandleDash();
    }

    private void HandleMovement()
    {
        if (isDashing)
        {
            controller.Move(dashDirection * (dashDistance / dashDuration) * Time.deltaTime);
            dashTimer += Time.deltaTime;
            if (dashTimer >= dashDuration)
                isDashing = false;

            return;
        }

        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        velocity = new Vector3(h, 0f, v).normalized;
        controller.Move(velocity * moveSpeed * Time.deltaTime);
    }

    private void HandleRotation()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        Plane plane = new Plane(Vector3.up, transform.position);
        if (plane.Raycast(ray, out float distance))
        {
            Vector3 hitPoint = ray.GetPoint(distance);
            Vector3 lookDir = hitPoint - transform.position;
            lookDir.y = 0;
            if (lookDir != Vector3.zero)
                transform.rotation = Quaternion.LookRotation(lookDir);
        }
    }

    private void HandleShooting()
    {
        if (Input.GetMouseButton(0) && Time.time > lastFireTime + fireCooldown)
        {
            lastFireTime = Time.time;
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            Rigidbody rb = bullet.GetComponent<Rigidbody>();
            rb.linearVelocity = firePoint.forward * bulletSpeed;
        }
    }

    private void HandleDash()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && Time.time > lastDashTime + dashCooldown)
        {
            lastDashTime = Time.time;
            isDashing = true;
            dashTimer = 0f;
            dashDirection = velocity == Vector3.zero ? transform.forward : velocity;
        }
    }
}
