using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
public class XROffsetGrabInteractable : XRGrabInteractable
{

    private Vector3 initialLocalPos;
    private Quaternion initialLocalRot;

    public GameObject leftController;
    public GameObject rightController;

    public GameObject Cylinder;

    // Start is called before the first frame update
    void Start()
    {
        if (!attachTransform)
        {
            GameObject attachPoint = new GameObject("Offset Grab Pivot");
            attachPoint.transform.SetParent(transform, false);
            attachTransform = attachPoint.transform;
        }
        else
        {
            initialLocalPos = attachTransform.localPosition;
            initialLocalRot = attachTransform.localRotation;
        }
    }

    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        if(args.interactableObject is XRDirectInteractor)
        {
            attachTransform.position = args.interactableObject.transform.position;
            attachTransform.rotation = args.interactableObject.transform.rotation;
        }
        else
        {
            attachTransform.localPosition = initialLocalPos;
            attachTransform.localRotation = initialLocalRot;
            leftController.GetComponent<XRInteractorLineVisual>().enabled=false;
            rightController.GetComponent<XRInteractorLineVisual>().enabled=false;
            transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
            Cylinder.GetComponent<CylinderSelector>().resetColliders();
            Cylinder.SetActive(false);
        }
        base.OnSelectEntered(args);
    }

    protected override void OnSelectExiting(SelectExitEventArgs args)
    {
        leftController.GetComponent<XRInteractorLineVisual>().enabled=true;
        rightController.GetComponent<XRInteractorLineVisual>().enabled=true;
        transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
        Cylinder.GetComponent<CylinderSelector>().resetColliders();
        Cylinder.SetActive(true);
        base.OnSelectExiting(args);
    }
}
