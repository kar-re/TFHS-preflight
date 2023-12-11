using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class PlaneAligner : MonoBehaviour
{
    [SerializeField]
    ARTrackedImageManager mgr;
    [SerializeField]
    GameObject go0;
    [SerializeField]
    GameObject go1; 

    // Start is called before the first frame update
    void OnEnable() => mgr.trackedImagesChanged += OnChanged;

    void OnDisable() => mgr.trackedImagesChanged -= OnChanged;

    void OnChanged(ARTrackedImagesChangedEventArgs eventArgs)
    {
        foreach (var newImage in eventArgs.added)
        {
            var pos = newImage.transform.position;
            var rot = newImage.transform.rotation;

            Vector3 offsetRot = go1.transform.rotation.eulerAngles - go0.transform.rotation.eulerAngles;
            go0.transform.rotation = Quaternion.Euler(rot.eulerAngles - offsetRot);
            Vector3 offsetPos = go1.transform.position - go0.transform.position;
            go0.transform.position = pos - offsetPos;
           
        }

        foreach (var updatedImage in eventArgs.updated)
        {
            var pos = updatedImage.transform.position;
            var rot = updatedImage.transform.rotation;

            Vector3 offsetRot = go1.transform.rotation.eulerAngles - go0.transform.rotation.eulerAngles;
            go0.transform.rotation = Quaternion.Euler(rot.eulerAngles - offsetRot);
            Vector3 offsetPos = go1.transform.position - go0.transform.position;
            go0.transform.position = pos - offsetPos;
        }

        foreach (var removedImage in eventArgs.removed)
        {
            // Handle removed event
        }
    }

}
