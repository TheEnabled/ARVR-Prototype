using NUnit.Framework.Constraints;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;

public class TrackedImageManager : MonoBehaviour
{
    [SerializeField] GameObject HPbarPrefab;
    [SerializeField] float HPBarYoffset = 0;

    public void OnTrackedImageChanged(ARTrackablesChangedEventArgs<ARTrackedImage> eventArgs)
    {
        foreach(var image in eventArgs.added)
        {
            Debug.Log("Image detected: " + image.referenceImage.name);

            GameObject prefab = Instantiate(HPbarPrefab);
            prefab.transform.parent = image.gameObject.transform;
            prefab.transform.localPosition = new Vector3(0, HPBarYoffset, 0);
        }

        foreach(var image in eventArgs.updated)
        {
            
        }

        foreach(var image in eventArgs.removed)
        {
            
        }
    }
}
