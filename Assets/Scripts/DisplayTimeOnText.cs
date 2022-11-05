using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;
using Unity.VisualScripting;

public class DisplayTimeOnText : MonoBehaviour
{
	[SerializeField]
	private GameObject clockText;
	private Component TextComponent;


	// Update is called once per frame
	void Update ()
	{
		System.DateTime time = System.DateTime.Now;

		clockText.GetComponent<TextMeshProUGUI>().text = time.ToString("HH:mm");

	}
}
