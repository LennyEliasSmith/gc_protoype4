using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    public float flapTime = 5f;
    public int maxFlaps = 3;
    public float flapMagnitude = 500f;
    public float maxFallSpeed = 5;
    private float flapTimer = 0f;
    private int currentFlaps;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        currentFlaps = maxFlaps;
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentFlaps < maxFlaps)
        {
            flapTimer += Time.deltaTime;

            if (flapTimer > flapTime)
            {
                flapTimer = 0;
                currentFlaps += 1;
                Debug.Log("Lol");
            }
        }

        if (Input.GetKeyDown(KeyCode.Space) && currentFlaps > 0)
        {
            currentFlaps -= 1;
            rb.AddForce(0, flapMagnitude, 0);
        }
        var vel = rb.velocity;
        if(vel.y <= -maxFallSpeed)
        {
            vel.y = -maxFallSpeed;
        }
    }
}
