using UnityEngine;
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
        {
            Debug.Log("Updated Image: " + image.referenceImage.name + " | Tracking State: " + image.trackingState);
        }

        
    }
}