using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;

public class ToggleSelectionMode : MonoBehaviour
{
    public InputActionReference toggleReference = null;

    public GameObject rightHand;
    public GameObject bubble;
    // Start is called before the first frame update
    void Start()
    {
        rightHand.SetActive(true);
        bubble.SetActive(false);
        toggleReference.action.started += toggleBubble;
    }

    private void toggleBubble(InputAction.CallbackContext context)
    {
        rightHand.SetActive(!rightHand.activeSelf);
        bubble.SetActive(!bubble.activeSelf);
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
