using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public GameObject birb;
    public Camera mainCam;

    // Start is called before the first frame update
    void Start()
    {
        mainCam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        mainCam.transform.LookAt(birb.transform);
        
    }
}
