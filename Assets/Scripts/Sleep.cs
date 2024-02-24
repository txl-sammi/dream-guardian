using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sleep : MonoBehaviour
{
    HealthManager healthManager;
    // Start is called before the first frame update
    void Start()
    {
        healthManager = GetComponent<HealthManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //when there is a noise, health starts decrease in a high rate, call ApplyDamage()
    //when noise stops, health slowly restores (call Heal)
}
