using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    public GameObject hoopStand;
    public GameObject hoop;
    public GameObject lattice;
    public MeshFilter initialMeshStand;
    public MeshFilter initialMeshHoop;
    public MeshFilter initialMeshLattice;
    public MeshFilter meshStand;
    public MeshFilter meshHoop;
    public MeshFilter meshLattice;

    public float timeRemaining = 2.0f;
    public bool isActive = false;

    public string ballsTag;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isActive)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
            }
            else
            {
                hoopStand.GetComponent<MeshFilter>().mesh = initialMeshStand.mesh;
                hoop.GetComponent<MeshFilter>().mesh = initialMeshHoop.mesh;
                lattice.GetComponent<MeshFilter>().mesh = initialMeshLattice.mesh;
                timeRemaining = 2.0f;
                isActive = false;
            }
        }
    }

    public void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag(ballsTag))
        {
            hoopStand.GetComponent<MeshFilter>().mesh = meshStand.mesh;
            hoop.GetComponent<MeshFilter>().mesh = meshHoop.mesh;
            lattice.GetComponent<MeshFilter>().mesh = meshLattice.mesh;
            isActive = true;
        }
    }
}
