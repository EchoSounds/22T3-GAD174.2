using Microsoft.Win32.SafeHandles;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager.UI;
using UnityEngine;
using UnityEngine.UI;

public class ColorPicker : MonoBehaviour
{
    [SerializeField] private Image Sample;

    [SerializeField] private Vector4 ColorVec;
    [SerializeField] private List<GameObject> Sliders = new List<GameObject>();

    private void Start()
    {
        Sample = Sample.gameObject.GetComponent<Image>();

        ColorVec.w = 1;
    }

    private void Update()
    {
        ColorVec.x = Sliders[0].GetComponent<Scrollbar>().value;
        ColorVec.y = Sliders[1].GetComponent<Scrollbar>().value;
        ColorVec.z = Sliders[2].GetComponent<Scrollbar>().value;

        Sample.gameObject.GetComponent<Image>().color = ColorVec;
    }
}
