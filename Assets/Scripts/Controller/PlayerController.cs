using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//----------------------------------------------
// PlayerController
//----------------------------------------------
public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab = null; // 弾

    [SerializeField] private float moveSpeed = 5.0f;
    [SerializeField] private float maxSpeed = 20.0f;
    [SerializeField] private float rotationSpeed = 100f; // 回転の感度
    [SerializeField] private float stickDeadZone = 0.1f; // スティックのデッドゾーン

    private Rigidbody2D rb = null;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            GameObject bullet = Instantiate(bulletPrefab);
            bullet.transform.position = transform.position + transform.right;
        }
    }

    void FixedUpdate()
    {
        // 移動制御
        HandleMovement();

        // 回転制御
        HandleWheelRotation();
    }

    void HandleMovement()
    {
        float vertical = Input.GetAxis("Vertical");
        if (Mathf.Abs(vertical) < stickDeadZone) vertical = 0;

        rb.AddForce(transform.right * vertical * moveSpeed);

        if (rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity = rb.velocity.normalized * maxSpeed;
        }
    }

    void HandleWheelRotation()
    {
        float horizontal = Input.GetAxis("Horizontal");
        if (Mathf.Abs(horizontal) < stickDeadZone) horizontal = 0;

        rb.rotation -= horizontal * rotationSpeed * Time.fixedDeltaTime;
    }
}