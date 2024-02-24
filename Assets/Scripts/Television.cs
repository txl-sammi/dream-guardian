using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Television : MonoBehaviour, IInteractable
{
    [SerializeField] private Animator _animator;
    private bool _isPressed;
    public float resetDelay = 2f;

    [SerializeField] GameObject screen;

    void Start()
    {
        
    }
    public void Interact()
    {
        _isPressed = true;
        _animator.SetTrigger("pressed");
        StartCoroutine(ResetTriggerAfterDelay());
    }

    public bool CanInteract()
    {
        return !_isPressed;
    }

    // Coroutine to reset the trigger after a delay
    private IEnumerator ResetTriggerAfterDelay()
    {
        yield return new WaitForSeconds(resetDelay); // Wait for the specified delay
        
        screen.SetActive(false);
    }
}
