using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;


[RequireComponent(typeof(ARReferencePointManager))]
[RequireComponent(typeof(ARRaycastManager))]
[RequireComponent(typeof(ARPlaneManager))]
public class AnchorCreator : MonoBehaviour
{
    [SerializeField]
    GameObject m_AnchorPrefab;

    public GameObject anchorPrefab
    {
        get => m_AnchorPrefab;
        set => m_AnchorPrefab = value;
    }

    public void RemoveAllAnchors()
    {
        foreach (var anchor in m_Anchors)
        {
            m_AnchorManager.RemoveReferencePoint(anchor);
        }
        m_Anchors.Clear();
    }

    void Awake()
    {
        m_RaycastManager = GetComponent<ARRaycastManager>();
        m_AnchorManager = GetComponent<ARReferencePointManager>();
        m_PlaneManager = GetComponent<ARPlaneManager>();
        m_Anchors = new List<ARReferencePoint>();
    }

    void Update()
    {
        if (Input.touchCount == 0)
            return;

        var touch = Input.GetTouch(0);
        if (touch.phase != TouchPhase.Began)
            return;

        if (m_RaycastManager.Raycast(touch.position, s_Hits, TrackableType.PlaneWithinPolygon))
        {
            // Raycast hits are sorted by distance, so the first one
            // will be the closest hit.
            var hitPose = s_Hits[0].pose;
            var hitTrackableId = s_Hits[0].trackableId;
            var hitPlane = m_PlaneManager.GetPlane(hitTrackableId);
            var anchor = m_AnchorManager.AttachReferencePoint(hitPlane, hitPose);
            Instantiate(m_AnchorPrefab, hitPose.position, hitPose.rotation);
            if (anchor == null)
            {
                Debug.Log("Error creating anchor");
            }
            else
            {
                m_Anchors.Add(anchor);
            }
        }
    }

    static List<ARRaycastHit> s_Hits = new List<ARRaycastHit>();

    List<ARReferencePoint> m_Anchors;

    ARRaycastManager m_RaycastManager;

    ARReferencePointManager m_AnchorManager;

    ARPlaneManager m_PlaneManager;
}
