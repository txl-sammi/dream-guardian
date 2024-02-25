using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alarm : MonoBehaviour,IInteractable
{
    // Start is called before the first frame update
    private bool isAlarmOn = false;
    public float cooldown = 10f;
    private float timer = 0f;
    private Animation anim;

    void Start()
    {
        anim = GetComponent<Animation>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!isAlarmOn){
            timer += Time.deltaTime;
            if(timer > cooldown){
                timer = 0f;
                int random = Random.Range(0, 10);
                if(random >5){
                TurnOnAlarm();
                }
            }
        }else{
            print("Alarm is on");
        }
    }


        public void Interact()
    {
        TurnOffAlarm();
    }

    public void TurnOnAlarm(){
        isAlarmOn = true;
        //animation
        anim.Play();
        //sound
    }

    //call by player when e is pressed
    public void TurnOffAlarm(){
        isAlarmOn = false;
        //animation stop
        anim.Stop();
        //sound stop
    }

    //princess check isAlarmOn: if alarm is on, call ApplyDamage()


        public bool CanInteract()
    {
        return isAlarmOn;
    }
}
