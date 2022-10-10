using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

[RequireComponent(typeof(ARTrackedImageManager))]
public class TrackingManager : MonoBehaviour
{
    
    private ARTrackedImageManager trackedImageManager;
    private Camera Camera;

    private void Awake()
    {
        trackedImageManager = GetComponent<ARTrackedImageManager>();
        Camera = GetComponent<Camera>();
    }

    void OnEnable()
    {
        trackedImageManager.trackedImagesChanged += OnChanged;
    }

    void OnDisable()
    {
        trackedImageManager.trackedImagesChanged -= OnChanged;
    }

    void OnChanged(ARTrackedImagesChangedEventArgs eventArgs)
    {
        foreach (var i in eventArgs.added)
        {
           GameManager.ShowCursor(i.transform.position);
        }

        foreach (var i in eventArgs.updated)
        { 
           GameManager.ShowCursor(i.transform.position);
        }

        foreach (var i in eventArgs.removed)
        {
        }
    }
}
