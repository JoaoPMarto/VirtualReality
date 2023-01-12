using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallisticCalculation : MonoBehaviour
{
    public LineRenderer lr;
    [Range(1, 100)]
    public float speed = 1;
    public LayerMask mask;

    public float calcPos(float initialPos, float velocity, float time, float acceleration = 0)
    {
        return initialPos + velocity * time - 0.5f * acceleration * time * time;
    }

    public float xPos(float initialPos, float xVelocity, float time)
    {
        return initialPos + xVelocity * time;
    }
    public float yPos(float initialPos, float yVelocity, float time)
    {
        return initialPos + yVelocity * time - 0.5f * 9.8f * time * time;
    }

    public List<Vector3> GetPoints()
    {
        List<Vector3> list = new List<Vector3>();


        int guardian = 0;
        while (guardian < 100)
        {
            list.Add(new Vector3(
                calcPos(transform.position.x, transform.forward.x * speed, guardian * 0.1f),
                calcPos(transform.position.y, transform.forward.y * speed, guardian * 0.1f, 9.8f),
                calcPos(transform.position.z, transform.forward.z * speed, guardian * 0.1f)
                ));

            // check Collisions
            if (list.Count > 1)
            {
                var last = list[list.Count - 1];
                var second = list[list.Count - 2];

                RaycastHit hit;
                if (Physics.Raycast(second, last - second, out hit, (last - second).magnitude, mask))
                {
                    list[list.Count - 1] = hit.point;
                    return list;
                }
            }

            guardian++;
        }

        //for (int i = 0; i < 10; i++)
        //{
        //    list.Add(new Vector3(
        //        calcPos(transform.position.x, transform.forward.x * speed, i * 0.1f),
        //        calcPos(transform.position.y, transform.forward.y * speed, i * 0.1f, 9.8f),
        //        calcPos(transform.position.z, transform.forward.z * speed, i * 0.1f)
        //        ));

        //    // check Collisions
        //    if (list.Count > 1)
        //    {
        //        var last = list[list.Count - 1];
        //        var second = list[list.Count - 2];

        //        RaycastHit hit;
        //        if (Physics.Raycast(second, last - second, out hit, (last - second).magnitude))
        //        {
        //            list[list.Count - 1] = hit.point;
        //            return list;
        //        }
        //    }
        //}
        return list;
    }

    public void ChangeSpeed(float newSpeed) => speed = newSpeed;

    public Rigidbody ball;

    public void ShootBall()
    {
        ball.isKinematic = true;
        ball.transform.position = transform.position;
        ball.isKinematic = false;
        ball.velocity = transform.forward * speed;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //LineRenderer lr = GetComponent<LineRenderer>();
        var l = GetPoints();
        lr.positionCount = l.Count;
        lr.SetPositions(l.ToArray());
    }
}
