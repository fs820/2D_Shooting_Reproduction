using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//---------------------------------------------
// Enemy‚ð“®‚©‚·ƒNƒ‰ƒX
//---------------------------------------------
public class EnemyController : MonoBehaviour
{
    [SerializeField] private float minChangeTime = 0.2f;
    [SerializeField] private float maxChangeTime = 2.0f;

    private Rigidbody2D rb = null;

    private Vector2 angle = new Vector2();

    private float waitTime = 0.0f;

    private float startTime = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        startTime = Time.time;
        waitTime = Random.Range(minChangeTime, maxChangeTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        if (Time.time - startTime >= waitTime)
        {
            angle = new Vector2(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f));
            angle.Normalize();

            startTime = Time.time;
            waitTime = Random.Range(minChangeTime, maxChangeTime);
        }

        Vector2 newPosition = rb.position + angle * Time.fixedDeltaTime;
        rb.MovePosition(newPosition);
    }
}
