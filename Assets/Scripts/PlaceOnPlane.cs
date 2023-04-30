using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class PlaceOnPlane : MonoBehaviour
{
    private GameObject spawnPrefebs;
    public bool isMap = false;

    UIButtonManager uiButton = null;
    List<ARRaycastHit> m_Hits = new List<ARRaycastHit>();
    ARRaycastManager m_RaycastManger;

    // Start is called before the first frame update
    void Start()
    {
        m_RaycastManger = GetComponent<ARRaycastManager>();
        GameObject tmp = GameObject.Find("UIButtonManager");
        uiButton = tmp.GetComponent<UIButtonManager>();
        spawnPrefebs = GameObject.Find("Map_p").transform.Find("Map").gameObject;

        Time.timeScale = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount == 0)
            return;

        Touch touch = Input.GetTouch(0);
        if (touch.phase != TouchPhase.Began)
            return;

        if (m_RaycastManger.Raycast(touch.position, m_Hits, TrackableType.PlaneWithinPolygon))
        {
            Pose hitPose = m_Hits[0].pose;
            if (!isMap)
            {
                spawnPrefebs.SetActive(true);
                spawnPrefebs.transform.position = hitPose.position;
                spawnPrefebs.transform.rotation = hitPose.rotation;
                
                Time.timeScale = 1.0f;
                uiButton.CreateMap();
                isMap = true;
            }
        }
    }
}
