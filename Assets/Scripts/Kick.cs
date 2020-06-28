using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kick : MonoBehaviour
{
    public Rigidbody rb;
    public float defForce;
    public float kickForce;

    public float forceMultiplier;
    public float multiplierCap;

    public bool kicking;
    public bool multiplierRise;
    public bool multiplierLower;

    // Start is called before the first frame update
    void Start()
    {
        multiplierCap = 2;
        defForce = 1000;
 
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("Fire1") && !kicking)
        {
            kicking = true;
            multiplierRise = true;
        }
        else if (Input.GetButtonDown("Fire1") && kicking)
        {
            KickRigidBody();
        }

        ForceLogic();


    }

    void ForceLogic()
    {
        if(multiplierRise)
        {
            if (kicking && forceMultiplier < multiplierCap)
            {
                forceMultiplier = forceMultiplier + Time.deltaTime;
            }
            else if (kicking && forceMultiplier >= multiplierCap)
            {
                multiplierRise = false;
                multiplierLower = true;
            }
        }
        else if (multiplierLower)
        {
            if(kicking && forceMultiplier > 0)
            {
                forceMultiplier = forceMultiplier - Time.deltaTime;
            }
            else if (kicking && forceMultiplier <= 0)
            {
                multiplierRise = true;
                multiplierLower = false;
            }
        }
        
    }

    void KickRigidBody()
    {
        kickForce = defForce * forceMultiplier;
        rb.AddForce((transform.up + transform.forward) * kickForce);
        forceMultiplier = 0;
        kicking = false;
    }

    
}
