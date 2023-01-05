using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;

public class ToggleSelectionMode : MonoBehaviour
{
    public InputActionReference toggleReference;

    public GameObject rightHand;
    public GameObject rightHandModel;
    public GameObject bubble;
    public GameObject bubbleModel;
    public GameObject cylinder;

    // Start is called before the first frame update
    void Start()
    {
        rightHand.SetActive(true);
        rightHandModel.SetActive(true);
        bubble.SetActive(false);
        bubbleModel.SetActive(false);
        toggleReference.action.started += toggleBubble;
    }

    private void toggleBubble(InputAction.CallbackContext context)
    {
        rightHand.GetComponent<LineRenderer>().enabled = !rightHand.GetComponent<LineRenderer>().enabled;
        rightHand.GetComponent<XRInteractorLineVisual>().enabled = !rightHand.GetComponent<XRInteractorLineVisual>().enabled;
        rightHand.GetComponent<XRRayInteractor>().enabled = !rightHand.GetComponent<XRRayInteractor>().enabled;
        rightHand.SetActive(!rightHand.activeSelf);
        rightHandModel.SetActive(!rightHandModel.activeSelf);

        if (bubble.activeSelf)
        {
            cylinder.GetComponent<CylinderSelector>().resetColliders();
        }

        bubble.SetActive(!bubble.activeSelf);
        bubbleModel.SetActive(!bubbleModel.activeSelf);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDestroy()
    {
        toggleReference.action.started -= toggleBubble;
    }
}
