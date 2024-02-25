using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;
using System;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject GameoverMenu;
    [SerializeField] private TimeController TimeController;

    [SerializeField] private TextMeshProUGUI totalHoursText;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GameOver()
    {
        GameoverMenu.SetActive(true);
        Time.timeScale = 0;
        totalHoursText.text = (TimeController.totalTime()).ToString("hh\\:mm");
    }
}
