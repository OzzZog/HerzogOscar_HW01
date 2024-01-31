using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickObject : MonoBehaviour
{
    [SerializeField] private TouchInput _touchInput;

    private Camera _camera;

    private void Awake()
    {
        _camera = Camera.main;
    }

    private void OnEnable()
    {
        TouchInput.Clicked += OnClicked;
    }

    private void OnDisable()
    {
        TouchInput.Clicked -= OnClicked;
    }

    private void OnClicked()
    {
        Ray ray = _camera.ScreenPointToRay(_touchInput.TouchScreenPosition);
        // if our Ray hits a collider
        if(Physics.Raycast(ray, out RaycastHit hitInfo))
        {
            // if our collider is clickable
            Clickable clickable =
                hitInfo.collider.gameObject.GetComponent<Clickable>();
            // if so, click it
            if (clickable != null)
            {
                clickable.Click();
            }
        }
    }
}
