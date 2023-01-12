using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followTransform : MonoBehaviour
{
    public Transform target;
    public Transform look;
    public float height = 0;
    public float distance = 1;

    public void followTarget()
    {
        var forward = new Vector3(target.forward.x, 0, target.forward.z);
        var feet = new Vector3(target.position.x, height, target.position.z);
        transform.position = feet + forward * distance;

        transform.LookAt(transform.position + (transform.position - feet));
    }

    private void OnEnable()
    {
        followTarget();
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
