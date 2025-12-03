<<<<<<< Updated upstream
using UnityEngine;
=======
﻿using UnityEngine;
>>>>>>> Stashed changes
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using System.Collections.Generic;

public class TrackedImageObjectHandler : MonoBehaviour
{
    [SerializeField] private GameObject virtualObjPrefab;
    [SerializeField] private float yOffset = 0.05f;

    private ARTrackedImageManager trackedImageManager;

    void Start()
    {
        Debug.Log("TrackedImageObjectHandler started!");
        if (virtualObjPrefab == null)
        {
            Debug.LogError("Virtual Object Prefab is NOT assigned!");
        }
        else
        {
            Debug.Log("Virtual Object Prefab is assigned: " + virtualObjPrefab.name);
        }
    }

<<<<<<< Updated upstream
    public void OnTrackedImageChanged(ARTrackablesChangedEventArgs<ARTrackedImage> eventArgs)
    {
        foreach (var image in eventArgs.added)
        {
            Debug.Log("New tracked image added: " + image.referenceImage.name + " | Tracking State: " + image.trackingState);

            GameObject virtualObj = GameObject.Instantiate(virtualObjPrefab);
            virtualObj.transform.parent = image.gameObject.transform;
            virtualObj.transform.localPosition = new Vector3(0f, yOffset, 0f);
        }

        foreach (var image in eventArgs.updated)
=======
    void OnEnable()
    {
        trackedImageManager = GetComponent<ARTrackedImageManager>();
        trackedImageManager.trackablesChanged.AddListener(OnTrackedImagesChanged);
    }

    void OnDisable()
    {
        trackedImageManager.trackablesChanged.RemoveListener(OnTrackedImagesChanged);
    }

    private void OnTrackedImagesChanged(ARTrackablesChangedEventArgs<ARTrackedImage> eventArgs)
    {
        // Handle newly detected images
        foreach (ARTrackedImage image in eventArgs.added)
        {
            Debug.Log("New tracked image added: " + image.referenceImage.name + " | Tracking State: " + image.trackingState);

            if (virtualObjPrefab != null)
            {
                GameObject virtualObj = GameObject.Instantiate(virtualObjPrefab);

                if (virtualObj != null)
                {
                    virtualObj.transform.parent = image.transform;
                    virtualObj.transform.localPosition = new Vector3(0f, yOffset, 0f);
                    virtualObj.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);

                    Debug.Log("✅ SPAWN OBJECT SUCCESS! Object spawned on image: " + image.referenceImage.name);
                    Debug.Log("Object position: " + virtualObj.transform.position);
                }
                else
                {
                    Debug.LogError("❌ SPAWN FAILED! Could not instantiate prefab.");
                }
            }
            else
            {
                Debug.LogError("❌ SPAWN FAILED! virtualObjPrefab is null!");
            }
        }

        // Handle updated images
        foreach (ARTrackedImage image in eventArgs.updated)
>>>>>>> Stashed changes
        {
            Debug.Log("Updated Image: " + image.referenceImage.name + " | Tracking State: " + image.trackingState);
        }

<<<<<<< Updated upstream
        
=======
        // Handle removed images
        foreach (var kvp in eventArgs.removed)
        {
            ARTrackedImage image = kvp.Value;
            Debug.Log("Removed Image: " + image.referenceImage.name + " | Tracking State: " + image.trackingState);
        }
>>>>>>> Stashed changes
    }
}