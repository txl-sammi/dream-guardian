using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alarm : MonoBehaviour,IInteractable
{
    // Start is called before the first frame update
    private bool isAlarmOn = false;
    public float cooldown = 6f;
    private float timer = 0f;
    private Animation anim;
    
    private AudioSource sound;
    [SerializeField] public GameObject health;
    [SerializeField] public float damage;

    void Start()
    {
        anim = GetComponent<Animation>();
        sound = GetComponent<AudioSource>();
        sound.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        if(!isAlarmOn){
            timer += Time.deltaTime;
            if(timer > cooldown){
                timer = 0f;
                int random = Random.Range(0, 10);
                if(random >4){
                TurnOnAlarm();
                }
            }
        }else{
            print("Alarm is on");
            health.GetComponent<HealthManager>().ApplyDamage(damage* Time.deltaTime);
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
        sound.Play();
    }

    //call by player when e is pressed
    public void TurnOffAlarm(){
        isAlarmOn = false;
        //animation stop
        anim.Stop();
        //sound stop
        sound.Stop();
    }

    //princess check isAlarmOn: if alarm is on, call ApplyDamage()


        public bool CanInteract()
    {
        return isAlarmOn;
    }
}
