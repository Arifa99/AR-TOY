using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;


[RequireComponent(typeof(ARTrackedImageManager))]
public class TrackedImageMultipleManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] arObjectToPlace;

    [SerializeField]
    private Vector3 scaleFactor = new Vector3(0.1f, 0.1f, 0.1f);

    private ARTrackedImageManager m_TrackedImageManager;

    private Dictionary<string, GameObject> arObjects = new Dictionary<string, GameObject>();


    void Awake()
    {
        m_TrackedImageManager = GetComponent<ARTrackedImageManager>();

        //Setup all Gameobject in Dictionary

        foreach(GameObject arObject in arObjectToPlace)
        {
            GameObject newARObject = Instantiate(arObject, Vector3.zero, Quaternion.identity);
            newARObject.name = arObject.name;
            arObjects.Add(arObject.name, newARObject);
        }

    }

    void OnEnable()
    {
        m_TrackedImageManager.trackedImagesChanged += OnTrackedImagesChanged;
    }

    private void OnTrackedImagesChanged(ARTrackedImagesChangedEventArgs obj)
    {
        foreach(ARTrackedImage trackedImage in obj.added)
        {
            UpdateARImage(trackedImage);
        }
        foreach (ARTrackedImage trackedImage in obj.updated)
        {
            UpdateARImage(trackedImage);
        }
        foreach (ARTrackedImage trackedImage in obj.removed)
        {
            arObjects[trackedImage.name].SetActive(false);
        }
    }

    private void UpdateARImage(ARTrackedImage trackedImage)
    {
        // Name of the tracked image
        string imgname = trackedImage.referenceImage.name;

        // Assignand place Game Object
        AssignedGameObject(trackedImage.referenceImage.name, trackedImage.transform.position);
        

    }

    private void AssignedGameObject(string name, Vector3 newPosition)
    {
      if(arObjectToPlace!= null)
        {
            arObjects[name].SetActive(true);
            arObjects[name].transform.position = newPosition;
            arObjects[name].transform.localScale = scaleFactor;
            foreach(GameObject go in arObjects.Values)
            {
                if(go.name != name)
                {
                    go.SetActive(false);
                }
            }
        }
    }

    void OnDisable()
    {
        m_TrackedImageManager.trackedImagesChanged -= OnTrackedImagesChanged;
    }
    
}
