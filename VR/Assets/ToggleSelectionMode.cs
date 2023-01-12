using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;

public class ToggleSelectionMode : MonoBehaviour
{
    public InputActionReference toggleReference;
    public InputActionReference toggleReferenceCanvas;

    public GameObject rightHand;
    public GameObject bubble;

    public GameObject canvas;

    public GameObject rightTeleport;
    public GameObject leftTeleport;

    public bool isDirect = false;
    public bool isCanvas = false;

    private void OnEnable()
    {
        toggleReference.action.started += toggleBubble;
        toggleReferenceCanvas.action.started += toggleCanvas;
    }

    private void OnDisable()
    {
        toggleReference.action.started -= toggleBubble;
        toggleReferenceCanvas.action.started -= toggleCanvas;
    }

    private void setComponents()
    {
        // Set all components in the controller objects to enabled/disabled
        foreach (var component in rightHand.GetComponents<Behaviour>())
            component.enabled = !isDirect;
        foreach (var component in bubble.GetComponents<Behaviour>())
            component.enabled = isDirect;

        // Enable/disable all their children
        foreach (Transform t in rightHand.transform)
            t.gameObject.SetActive(!isDirect);
        foreach (Transform t in bubble.transform)
            t.gameObject.SetActive(isDirect);
    }

    private void toggleBubble(InputAction.CallbackContext context)
    {
        isDirect = !isDirect;
        setComponents();
    }

    private void toggleCanvas(InputAction.CallbackContext context)
    {
        isCanvas = !isCanvas;
        setComponentsCanvas();
    }

    public void setComponentsCanvas()
    {
        canvas.SetActive(isCanvas);
        // Set all components in the controller objects to enabled/disabled
        foreach (var component in leftTeleport.GetComponents<Behaviour>())
            component.enabled = !isCanvas;
        foreach (var component in rightTeleport.GetComponents<Behaviour>())
            component.enabled = !isCanvas;

        // Enable/disable all their children
        foreach (Transform t in leftTeleport.transform)
            t.gameObject.SetActive(!isCanvas);
        foreach (Transform t in rightTeleport.transform)
            t.gameObject.SetActive(!isCanvas);
        
    }

    void Start()
    {
        setComponentsCanvas();
        setComponents();
    }
}
