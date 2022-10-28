using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    private TMP_Text timerText;
    public bool timesUp;
    private float deplete = 0.5f;
    private float currentTime = 30.0f;
    // Start is called before the first frame update
    void Start()
    {
        timerText = gameObject.GetComponent<TMP_Text>();
        timerText.text = currentTime.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if(currentTime <= 0){
            currentTime = 0;
            timesUp = true;
        }
        timerText.text = currentTime.ToString();
        currentTime -= deplete * Time.deltaTime;
    }
}
