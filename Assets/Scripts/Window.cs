using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Window : MonoBehaviour, IInteractable
{
    private bool isWindowOpen = false;
    public float resetDelay = 2f;

    public float cooldown = 5f;
    private float timer = 0f;

    [SerializeField] GameObject close;
    [SerializeField] GameObject light;

    [SerializeField] public GameObject health;
    [SerializeField] public float damage;
    void Start(){

    }

    void Update()
    {
        if(!isWindowOpen){
            timer += Time.deltaTime;
            if(timer > cooldown){
                timer = 0f;
                int random = Random.Range(0, 10);
                if(random >2){
                    Open();
                }
            }
        }
        else
        {
            print("Windows is on");
            health.GetComponent<HealthManager>().ApplyDamage(damage* Time.deltaTime);
        }
    }


    private void Open(){
        print("Window is open");
        close.SetActive(false);
        light.SetActive(true);
        isWindowOpen = true;
        timer = 0f;
    }

    private void TurnOff(){
        print("close window");
        isWindowOpen = false;
        close.SetActive(true);
        light.SetActive(false);
    }


    public void Interact()
    {
        TurnOff();
    }

    public bool CanInteract()
    {
        return isWindowOpen;
    }

}
