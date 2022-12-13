using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFieldOfView : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var localCamera = GetComponent<Camera>();
        localCamera.stereoTargetEye = StereoTargetEyeMask.None;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
