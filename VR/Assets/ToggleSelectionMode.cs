using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;

public class ToggleSelectionMode : MonoBehaviour
{
    public InputActionReference toggleReference;

    public GameObject rightHand;
    public GameObject bubble;

    public bool isDirect = false;

    private void OnEnable()
    {
        toggleReference.action.started += toggleBubble;
    }

    private void OnDisable()
    {
        toggleReference.action.started -= toggleBubble;
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

    void Start()
    {
        setComponents();
    }
}
