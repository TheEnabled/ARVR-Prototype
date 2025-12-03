<<<<<<< Updated upstream
<<<<<<< Updated upstream
using UnityEngine;
=======
﻿using UnityEngine;
>>>>>>> Stashed changes
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
=======
﻿using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using System.Collections;
>>>>>>> Stashed changes
using System.Collections.Generic;

public class TrackedImageObjectHandler : MonoBehaviour
{
<<<<<<< Updated upstream
    [SerializeField] private GameObject virtualObjPrefab;
    [SerializeField] private float yOffset = 0.05f;

=======
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private GameObject interactablePrefab;
    [SerializeField] private float yOffset = 0.05f;

    // IDE0044: Make field readonly
    private readonly Dictionary<string, GameObject> spawnedObjects = new();

>>>>>>> Stashed changes
    private ARTrackedImageManager trackedImageManager;

    void Start()
    {
<<<<<<< Updated upstream
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
=======
        Debug.Log("=== TrackedImageObjectHandler START ===");
        Debug.Log("Player Prefab: " + (playerPrefab != null ? playerPrefab.name : "NULL"));
        Debug.Log("Enemy Prefab: " + (enemyPrefab != null ? enemyPrefab.name : "NULL"));
        Debug.Log("Interactable Prefab: " + (interactablePrefab != null ? interactablePrefab.name : "NULL"));
    }

    void OnEnable()
    {
        trackedImageManager = GetComponent<ARTrackedImageManager>();
        if (trackedImageManager != null)
        {
            trackedImageManager.trackablesChanged.AddListener(OnTrackedImagesChanged);
            Debug.Log("Listener added successfully");

            // Log all images in the reference library
            if (trackedImageManager.referenceLibrary != null)
            {
                Debug.Log("Reference library contains " + trackedImageManager.referenceLibrary.count + " images:");
                for (int i = 0; i < trackedImageManager.referenceLibrary.count; i++)
                {
                    var refImage = trackedImageManager.referenceLibrary[i];
                    Debug.Log("  [" + i + "] Name: '" + refImage.name + "' | Texture: " + (refImage.texture != null ? refImage.texture.name : "NULL"));
                }
            }
        }
        else
        {
            Debug.LogError("ARTrackedImageManager not found!");
        }
>>>>>>> Stashed changes
    }

    void OnDisable()
    {
<<<<<<< Updated upstream
        trackedImageManager.trackablesChanged.RemoveListener(OnTrackedImagesChanged);
=======
        if (trackedImageManager != null)
        {
            trackedImageManager.trackablesChanged.RemoveListener(OnTrackedImagesChanged);
        }
>>>>>>> Stashed changes
    }

    private void OnTrackedImagesChanged(ARTrackablesChangedEventArgs<ARTrackedImage> eventArgs)
    {
<<<<<<< Updated upstream
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
=======
        Debug.Log("=== Images Changed - Added: " + eventArgs.added.Count + " ===");

        // Handle newly detected images
        foreach (object entry in (IEnumerable)eventArgs.added)
        {
            ARTrackedImage trackedImage;
            string imageId;

            if (entry is ARTrackedImage ai)
            {
                trackedImage = ai;
                imageId = ai.trackableId.ToString();
            }
            else if (entry is KeyValuePair<TrackableId, ARTrackedImage> kv)
            {
                trackedImage = kv.Value;
                imageId = kv.Key.ToString();
            }
            else
            {
                // Unknown entry type - skip
                continue;
            }

            string imageName = trackedImage.referenceImage.name;
            string textureName = trackedImage.referenceImage.texture != null ? trackedImage.referenceImage.texture.name : "NO_TEXTURE";

            Debug.Log("NEW IMAGE DETECTED");
            Debug.Log("  Reference Name: '" + imageName + "'");
            Debug.Log("  Texture Name: '" + textureName + "'");
            Debug.Log("  Tracking State: " + trackedImage.trackingState);

            // WORKAROUND: Use texture name if reference name is empty
            string nameToUse = string.IsNullOrEmpty(imageName) ? textureName : imageName;
            Debug.Log("  Using name: '" + nameToUse + "'");

            // Get the correct prefab based on name
            GameObject prefabToSpawn = GetPrefabForImageName(nameToUse);

            if (prefabToSpawn != null)
            {
                Debug.Log("✅ Spawning prefab: " + prefabToSpawn.name);

                // Instantiate the object
                GameObject spawnedObject = Instantiate(prefabToSpawn);

                // Parent it to the tracked image
                spawnedObject.transform.SetParent(trackedImage.transform, false);

                // Set local position and scale
                spawnedObject.transform.localPosition = new Vector3(0f, yOffset, 0f);
                spawnedObject.transform.localScale = new Vector3(0.05f, 0.05f, 0.05f);

                Debug.Log("Object spawned at: " + spawnedObject.transform.position);

                // Store the spawned object
                spawnedObjects[imageId] = spawnedObject;
            }
            else
            {
                Debug.LogError("❌ No prefab found for: '" + nameToUse + "'");
>>>>>>> Stashed changes
            }
        }

        // Handle updated images
<<<<<<< Updated upstream
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
=======
        foreach (object entry in (IEnumerable)eventArgs.updated)
        {
            ARTrackedImage trackedImage;
            string imageId;

            if (entry is ARTrackedImage ai)
            {
                trackedImage = ai;
                imageId = ai.trackableId.ToString();
            }
            else if (entry is KeyValuePair<TrackableId, ARTrackedImage> kv)
            {
                trackedImage = kv.Value;
                imageId = kv.Key.ToString();
            }
            else
            {
                continue;
            }

            if (spawnedObjects.ContainsKey(imageId))
            {
                bool shouldShow = trackedImage.trackingState == TrackingState.Tracking;
                spawnedObjects[imageId].SetActive(shouldShow);
            }
        }

        // Handle removed images
        foreach (object entry in (IEnumerable)eventArgs.removed)
        {
            ARTrackedImage trackedImage;
            string imageId;

            if (entry is ARTrackedImage ai)
            {
                trackedImage = ai;
                imageId = ai.trackableId.ToString();
            }
            else if (entry is KeyValuePair<TrackableId, ARTrackedImage> kv)
            {
                trackedImage = kv.Value;
                imageId = kv.Key.ToString();
            }
            else
            {
                continue;
            }

            if (spawnedObjects.ContainsKey(imageId))
            {
                Destroy(spawnedObjects[imageId]);
                spawnedObjects.Remove(imageId);
            }
        }
    }

    private GameObject GetPrefabForImageName(string name)
    {
        if (string.IsNullOrEmpty(name))
        {
            Debug.LogError("Name is empty!");
            return null;
        }

        Debug.Log("Matching against: '" + name + "'");

        // Check if name contains certain keywords (case-insensitive)
        string lowerName = name.ToLower();

        if (lowerName.Contains("player") || lowerName == "Player")
        {
            Debug.Log("  -> Matched Player");
            return playerPrefab;
        }
        else if (lowerName.Contains("enemy") || lowerName == "Enemy")
        {
            Debug.Log("  -> Matched Enemy");
            return enemyPrefab;
        }
        else if (lowerName.Contains("interactable") || lowerName == "Interactable")
        {
            Debug.Log("  -> Matched Interactable");
            return interactablePrefab;
        }

        Debug.LogWarning("  -> No match found for: '" + name + "'");
        return null;
>>>>>>> Stashed changes
    }
}