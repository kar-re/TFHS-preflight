using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class GuideManager : MonoBehaviour
{
    [SerializeField]
    CanvasFadeout canvasFadeout;
    [SerializeField]
    ARRaycastManager raycastManager;
    List<ARRaycastHit> hits = new List<ARRaycastHit>();
    [SerializeField]
    GameObject spawnablePrefab;

    [SerializeField]
    Canvas canvas;

    Camera arCam;
    GameObject spawnedObject;
    // Start is called before the first frame update
    void Start()
    {
        spawnedObject = null;
        spawnablePrefab.SetActive(false);
        arCam = GameObject.Find("AR Camera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount == 0)
            return;

        RaycastHit hit;
        Ray ray = arCam.ScreenPointToRay(Input.GetTouch(0).position);

        if (raycastManager.Raycast(Input.GetTouch(0).position, hits)) {
            if (Input.GetTouch(0).phase == TouchPhase.Began && !spawnedObject) {
                if (Physics.Raycast(ray, out hit)) {
                    if (hit.collider.gameObject.tag == "Spawnable") {
                        spawnedObject = hit.collider.gameObject;
                    }
                    else {
                        spawnablePrefab.transform.position = hits[0].pose.position;
                        spawnablePrefab.transform.rotation = hits[0].pose.rotation;
                        spawnablePrefab.SetActive(true);
                        spawnedObject = spawnablePrefab;
                        // spawnedObject = Instantiate(spawnablePrefab, hits[0].pose.position, hits[0].pose.rotation);
                        canvasFadeout.fadeCanvasPub();
                    }
                }
            }
            else if (Input.GetTouch(0).phase == TouchPhase.Moved && spawnedObject) {
                // spawnedObject.transform.position = hits[0].pose.position;
            }
            if (Input.GetTouch(0).phase == TouchPhase.Ended) {
                // spawnedObject = null;
            } 
        }
    }

    
}
