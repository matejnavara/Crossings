using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossingLightScript : MonoBehaviour
{
    private GameObject camera;
    // Start is called before the first frame update
    void Start()
    {
        camera = GameObject.FindWithTag("MainCamera");
        transform.LookAt(camera.transform.position);
    }
}
