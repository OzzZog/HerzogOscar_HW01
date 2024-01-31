using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
/// <summary>
/// Add this script to an object with a collider.
/// Specify what you want to happen when this object is clicked by
/// assigning things in the UnityEvent!
/// </summary>
public class Clickable : MonoBehaviour
{
    public UnityEvent Clicked;

    public void Click()
    {
        Debug.Log("Clicked: " + gameObject.name);
        Clicked.Invoke();
    }
}
