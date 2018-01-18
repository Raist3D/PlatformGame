using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingTextController : MonoBehaviour
{
    private static FloatingText popUpText;
    private static GameObject canvas;


    public static void Initialize()
    {
        canvas = GameObject.Find("Canvas");
        popUpText = Resources.Load<FloatingText>("Prefabs/PopUpTextParent");
    }

    public static void CreateFloatingText(string text, Transform location)
    {
        FloatingText instance = Instantiate(popUpText);
        instance.transform.SetParent(canvas.transform, false);
        instance.SetText(text);
    }

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
