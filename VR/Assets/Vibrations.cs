using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class Vibrations : MonoBehaviour
{

    public ActionBasedController left;

    public ActionBasedController right;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Vibrate(ActionBasedController controller)
    {
        controller.SendHapticImpulse(1.0f, 2.0f);
    }

    public void VibrateLeft() => Vibrate(left);
    public void VibrateRight() => Vibrate(right);
    // Update is called once per frame
    void Update()
    {
        
    }
}
