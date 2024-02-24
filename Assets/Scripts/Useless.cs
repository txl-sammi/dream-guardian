using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Useless : MonoBehaviour, IInteractable
{
    private Animator _animator;
    private bool _isPressed;
    public float resetDelay = 2f;

    void Start()
    {
        _animator = GetComponent<Animator>();
    }
    public void Interact()
    {
        _isPressed = true;
        _animator.SetTrigger("pressed");
        //StartCoroutine(ResetTriggerAfterDelay());
    }

    public bool CanInteract()
    {
        return !_isPressed;
    }

    // Coroutine to reset the trigger after a delay
    // private IEnumerator ResetTriggerAfterDelay()
    // {
    //     yield return new WaitForSeconds(resetDelay); // Wait for the specified delay
    //     _animator.ResetTrigger("pressed"); // Reset the trigger
    // }
}
