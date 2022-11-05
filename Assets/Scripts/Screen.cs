using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screen : MonoBehaviour
{
    [SerializeField] private GameObject Desktop;

    private void Start()
    {
        Desktop.SetActive(false);
    }

    public void TurnOnComputer()
    {
        if (!Desktop.activeSelf)
        {
            Invoke("TurnOnScreen", 2);
            FindObjectOfType<AudioManager>().Play("StartUpFan");
        }
    }
    private void TurnOnScreen()
    {
        Desktop.SetActive(true);
        FindObjectOfType<AudioManager>().Play("ContinuousFan");
        FindObjectOfType<AudioManager>().Play("On");
    }

    public void TurnOffComputer()
    {
        if (Desktop.activeSelf)
        {
            Invoke("TurnOffScreen", 1);
            FindObjectOfType<AudioManager>().Play("Off");
        }
    }
    private void TurnOffScreen()
    {
        Desktop.SetActive(false);
        FindObjectOfType<AudioManager>().Stop("ContinuousFan");
    }
}
