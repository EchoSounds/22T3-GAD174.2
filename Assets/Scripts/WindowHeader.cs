using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowHeader : MonoBehaviour
{
    [SerializeField] public GameObject[] tabs;
    [SerializeField] private GameObject Canvas;
    private Canvas Screen;

    private Vector3 Pos, Scale;
    private Quaternion Rotation;

    private void Start()
    {
        Screen = Canvas.GetComponent<Canvas>();    

        Pos = Screen.transform.position;
        Scale = Screen.transform.localScale;
        Rotation = Screen.transform.rotation;
            
    }
    public void ChangeRenderMode()
    {
        if (Screen.renderMode == RenderMode.WorldSpace)
        {
            Screen.renderMode = RenderMode.ScreenSpaceOverlay;
        } else if (Screen.renderMode == RenderMode.ScreenSpaceOverlay)
        {
            Screen.renderMode= RenderMode.WorldSpace;
            Screen.transform.position = Pos;
            Screen.transform.localScale = Scale;
            Screen.transform.rotation = Rotation;
        }
    }

    public void onTabSwitch(GameObject tab)
    {
        tab.SetActive(true);

        for (int i = 0; i < tabs.Length; i++)
        {
            if (tabs[i] != tab)
            {
                tabs[i].SetActive(false);
            }
        }
    }
}

