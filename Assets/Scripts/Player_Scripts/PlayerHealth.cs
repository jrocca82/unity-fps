using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public Image playerHealth;

    public TMP_Text deadText;

    private Timer timeCheck;

    void Start()
    {
        timeCheck = GameObject.Find("Timer").GetComponent<Timer>();
    }

    void Update()
    {
        if (playerHealth.fillAmount <= 0 || timeCheck.timesUp == true)
        {
            GameObject objectToSave =
                gameObject.transform.GetChild(1).gameObject;
            objectToSave.transform.parent = null;
            Destroy (gameObject);
            deadText.text = "YOU'RE DEAD";
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "laser")
        {
            playerHealth.fillAmount -= 0.01f;
        }
    }
}
