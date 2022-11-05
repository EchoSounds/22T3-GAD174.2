using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Desktop : MonoBehaviour
{
    public GameObject CurrentApplication = null;
    [SerializeField]
    private GameObject WindowOutline;
    [SerializeField]
    private TextMeshProUGUI ApplicationTitle;

    [SerializeField]
    private List<GameObject> ApplicationWindows = new List<GameObject>();
    [SerializeField]
    private List<GameObject> ApplicationTabs = new List<GameObject>();

    [SerializeField]
    private List<GameObject> ActiveWindows = new List<GameObject>();

    private void Start()
    {
        CloseWindow();
    }
    public void OpenWindow(string ApplicationName)
    {
        if (WindowOutline.activeSelf == false)
        {
            WindowOutline.SetActive(true);
            OpenApplication(ApplicationName);

        } else
        {
            OpenApplication(ApplicationName);
        }
    }

    public void CloseWindow()
    {
        if (WindowOutline.activeSelf == true)
        {
            WindowOutline.SetActive(false);
            foreach (GameObject Application in ApplicationWindows)
            {
                Application.SetActive(false);
            }
            foreach (GameObject Application in ActiveWindows)
            {
                Application.SetActive(true);
            }
        }
        else
        {
            return;
        }
    }
    private void HeaderUpdate(GameObject Application, bool Add)
    {
        ApplicationTitle.text = Application.name;

        foreach (GameObject ActiveApplication in ApplicationTabs)
        {
            ActiveApplication.SetActive(false);
        }
        
        if (!ActiveWindows.Contains(Application))
        {
            if (Add)
            {
                ActiveWindows.Add(Application);
            }
        } else if (!Add)
        {
           ActiveWindows.Remove(Application);
        }
        

        foreach (GameObject ActiveApplication in ActiveWindows)
        {
            ActiveApplication.SetActive(true);
        }
    }


    public void OpenApplication(string ApplicationName)
    {
        if (ApplicationName == null)
        {
            Debug.Log("No Application Selected");
                                    
            return;
        } else
        {
            if (CurrentApplication != null && CurrentApplication.name == ApplicationName)
            {
                CurrentApplication.SetActive(false);
            }
            foreach (GameObject Application in ApplicationWindows)
            {
                
                if (Application.name == ApplicationName)
                {
                    CurrentApplication = Application;

                    HeaderUpdate(Application, true);

                    CurrentApplication.SetActive(true);
                    return;
                }
            } 
        }
    }

    public void CloseApplication(string ApplicationName)
    {
        foreach (GameObject Application in ApplicationWindows)
        {
            if (Application.name == ApplicationName)
            {
                Application.SetActive(false);
                ActiveWindows.Remove(Application);
                HeaderUpdate(Application, false);

                if (ActiveWindows[0] != null)
                {
                    ActiveWindows[0].SetActive(true);
                } else
                {
                    CloseWindow();
                }
                return;
            }
        }

    }
}
