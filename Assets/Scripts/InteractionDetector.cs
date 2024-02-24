using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionDetector : MonoBehaviour
{
    private List<IInteractable> interactablesInRange = new List<IInteractable>();

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space) && interactablesInRange.Count > 0)
        {
            var interactable = interactablesInRange[0];
            interactable.Interact();
            if (!interactable.CanInteract())
            {
                interactablesInRange.Remove(interactable);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        var interactable = other.GetComponent<IInteractable>();
        if (interactable != null && interactable.CanInteract())
        {
            interactablesInRange.Add(interactable);
        }
    }

    private void OnTriggerExist2D(Collider2D other)
    {
        var interactable = other.GetComponent<IInteractable>();
        if (interactablesInRange.Contains(interactable))
        {
            interactablesInRange.Remove(interactable);
        }
    }
}
