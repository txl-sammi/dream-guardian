using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door : MonoBehaviour, IInteractable
{
    private bool isTVon;

    public float cooldown = 10f;
    private float timer = 0f;

    [SerializeField] public GameObject close;
    [SerializeField] public GameObject open;
    [SerializeField] public GameObject health;
    [SerializeField]public float damage;
    
    void Start(){
        TurnOff();
        timer = 10f;
    }


    void Update(){
        if(!isTVon){
            timer += Time.deltaTime;
            if(timer > cooldown){
                timer = 0f;
                int random = Random.Range(0, 10);
                if(random >5){
                    TurnOn();
                }
            }
        }else{
            health.GetComponent<HealthManager>().ApplyDamage(damage* Time.deltaTime);
        }
    }


    private void TurnOn(){
        open.SetActive(true);
        close.SetActive(false);
        isTVon = true;
        timer = 0f;
    }

    private void TurnOff(){
        open.SetActive(false);
        close.SetActive(true);
        isTVon = false;
    }


    public void Interact(){
        TurnOff();
    }

    public bool CanInteract(){
        return isTVon;
    }


}
