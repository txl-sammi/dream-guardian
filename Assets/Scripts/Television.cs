using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Television : MonoBehaviour, IInteractable
{
    [SerializeField] private Animator _animator;
    private bool isTVon = true;
    public float resetDelay = 2f;

    public float cooldown = 5f;
    private float timer = 0f;

    [SerializeField] GameObject screen;

    void Start(){

    }

    void Update()
    {
        if(!isTVon){
            timer += Time.deltaTime;
            if(timer > cooldown){
                timer = 0f;
                int random = Random.Range(0, 10);
                if(random >2){
                    TurnOn();
                }
            }
        }
    }


    private void TurnOn(){
        print("TV is on");
        screen.SetActive(true);
        isTVon = true;
        timer = 0f;
    }

    private void TurnOff(){
        print("turn off tv");
        isTVon = false;
        _animator.SetTrigger("pressed");
        StartCoroutine(ResetTriggerAfterDelay());
    }


    public void Interact()
    {
        TurnOff();
    }

    public bool CanInteract()
    {
        return isTVon;
    }

    // Coroutine to reset the trigger after a delay
    private IEnumerator ResetTriggerAfterDelay()
    {
        yield return new WaitForSeconds(resetDelay); // Wait for the specified delay
        screen.SetActive(false);
    }
}
