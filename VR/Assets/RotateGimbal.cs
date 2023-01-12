using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateGimbal : MonoBehaviour
{
    public Transform horizontal;
    public Transform vertical;

    public void rotateHorizontal(float angle)
    {
        horizontal.localRotation = Quaternion.Euler(0, angle, 0);
    }

    public void rotateVertical(float angle)
    {
        vertical.localRotation = Quaternion.Euler(angle, 0, 0);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
