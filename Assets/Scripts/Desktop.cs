using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Cinemachine;
using Unity.VisualScripting;
using UnityEngine.InputSystem;

public class Desktop : MonoBehaviour
{
    

    public GameObject CurrentApplication = null;
    [SerializeField]
    private GameObject WindowOutline;
    [SerializeField]
    private TextMeshProUGUI ApplicationTitle;

    [SerializeField] //Available Windows
    private List<GameObject> ApplicationWindows = new List<GameObject>();
    [SerializeField] //Available Tabs
    private List<GameObject> ApplicationTabs = new List<GameObject>();

    [SerializeField] //Open Windows
    private List<GameObject> ActiveWindows = new List<GameObject>(1);


    private void Start()
    {
        CloseWindow();
    }



    public void OpenWindow()
    {
        if (WindowOutline.activeSelf == false)
        {
            WindowOutline.SetActive(true);
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

        }
    }
    public void HideWindow()
    {
        CloseWindow();
        FindObjectOfType<AudioManager>().Play("Woosh");
    }

    private void HeaderUpdate(GameObject Application, bool Add)
    {
        ApplicationTitle.text = Application.name;

        foreach (GameObject ActiveTab in ApplicationTabs)
        {
            ActiveTab.SetActive(false);
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
        
        foreach (GameObject ActiveWindow in ActiveWindows)
        {
            foreach (GameObject ActiveApplication in ApplicationTabs)
            {
                if (ActiveWindow.name == ActiveApplication.name)
                {
                    ActiveApplication.SetActive(true);
                }
            }

            if (ActiveWindow.name == Application.name)
            {
                ActiveWindow.SetActive(true);
            }
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
            OpenWindow();
            if (CurrentApplication != null)
            {
                if (CurrentApplication.name == ApplicationName)
                {
                    CurrentApplication.SetActive(true);
                    FindObjectOfType<AudioManager>().Play("HighBeep");
                    ApplicationTitle.text = CurrentApplication.name;
                    return;
                } else
                {
                    CurrentApplication.SetActive(false);
                    
                }
            }
            foreach (GameObject Application in ApplicationWindows)
            {
                if (Application.name == ApplicationName)
                {
                    CurrentApplication = Application;

                    HeaderUpdate(Application, true);

                    CurrentApplication.SetActive(true);
                    FindObjectOfType<AudioManager>().Play("HighBeep");
                }
            } 
        }

        
    }

    public void CloseApplication()
    {
        HeaderUpdate(CurrentApplication, false);

        CurrentApplication.SetActive(false);

        if (ActiveWindows.Count == 0)
        {
            Debug.Log("pog");
            CloseWindow();
        } else if (ActiveWindows.Count != 0)
        {
            Debug.Log("poggers");
            OpenApplication(ActiveWindows[0].name);
        }

        FindObjectOfType<AudioManager>().Play("LowBeep");

        //foreach (GameObject Application in ApplicationWindows)
        //{
        //    if (Application.name == ApplicationName)
        //    {
        //        Application.SetActive(false);
        //        ActiveWindows.Remove(Application);
        //        HeaderUpdate(Application, false);

        //        if (ActiveWindows[0] != null)
        //        {
        //            ActiveWindows[0].SetActive(true);
        //        } else
        //        {
        //            CloseWindow();
        //        }
        //        return;
        //    } else if (ApplicationName == null)
        //    {

        //    }
        //}

    }
}
