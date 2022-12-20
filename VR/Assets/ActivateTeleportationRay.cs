using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;



public class ActivateTeleportationRay : MonoBehaviour
{
    public GameObject leftTeleportation;
    public GameObject rightTeleportation;

    public GameObject leftController;
    public GameObject rightController;

    public InputActionProperty leftActivate;
    public InputActionProperty rightActivate;

    // Update is called once per frame
    void Update()
    {
        
        if (leftActivate.action.ReadValue<float>() <= 0.1f){
            leftTeleportation.SetActive(false);
            leftController.SetActive(true);
        }

        if (leftActivate.action.ReadValue<float>() > 0.1f){
            leftTeleportation.SetActive(true);
            leftController.SetActive(false);
        }
        
        if(rightActivate.action.ReadValue<float>() > 0.1f){
            rightTeleportation.SetActive(true);
            rightController.SetActive(false);
        }

        if(rightActivate.action.ReadValue<float>() <= 0.1f){
            rightTeleportation.SetActive(false);
            rightController.SetActive(true);
        }
    

    }
}
