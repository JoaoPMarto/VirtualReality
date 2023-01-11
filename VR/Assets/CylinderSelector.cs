using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class CylinderSelector : MonoBehaviour
{
    public List<Collider> activeColliders;

    public Collider selected = null;

    public void OnTriggerEnter(Collider other)
    {
        activeColliders.Add(other);

        Debug.Log(other.gameObject.name + " Entered");
    }

    public void OnTriggerExit(Collider other)
    {
        activeColliders.Remove(other);
        Debug.Log(other.gameObject.name + "Exited");
    }

    void Update()
    {
        var best = GetSelected(activeColliders);

        if (best != selected)
        {
            if (best != null)
                best.transform.localScale = new Vector3(0.6f, 0.6f, 0.6f);
            if (selected != null)
                selected.transform.localScale = Vector3.one * 0.4f;
            selected = best;
        }
    }

    private Collider GetSelected(List<Collider> activeColliders)
    {
        if (activeColliders == null) return null;
        if (activeColliders.Count == 0) return null;

        Collider best = null;
        float minDot = float.PositiveInfinity;

        foreach (Collider collider in activeColliders)
        {
            if (collider.GetComponent<XRGrabInteractable>() == null) continue;
            float colliderDot = Vector3.Dot(transform.forward, collider.transform.position - transform.position);
            if (colliderDot < minDot)
            {
                best = collider;
                minDot = colliderDot;
            }
        }

        return best;
    }

    public void resetColliders()
    {
        foreach (var collider in activeColliders)
        {
            if (collider != null)
            {
                if(collider.gameObject.tag == "balls" || collider.gameObject.name == "Bottle Energy Drink A" || collider.gameObject.name == "Bottle Energy Drink B" ||
                    collider.gameObject.name == "Bottle Energy Drink A (1)" || collider.gameObject.name == "Bottle Energy Drink A (2)" ||
                    collider.gameObject.name == "Bottle Energy Drink A (3)" || collider.gameObject.name == "Bottle Energy Drink B (1)" ||
                    collider.gameObject.name == "Bottle Energy Drink B (2)" || collider.gameObject.name == "Bottle Energy Drink B (3)") {
                    collider.transform.localScale = Vector3.one * 0.4f;
                }
            }
        }
        activeColliders.Clear();
        if (selected != null)
        {
            selected.transform.localScale = Vector3.one * 0.4f;
        }
    }
}
