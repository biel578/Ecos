using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
public class Timer : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] float remaingtime;

    // Update is called once per frame
    void Update()
    {
        remaingtime -= Time.deltaTime;
        int minutes = Mathf.FloorToInt(remaingtime / 60);
        int seconds = Mathf.FloorToInt(remaingtime % 60);
        timerText.text = String.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
