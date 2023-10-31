using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followPlayer : MonoBehaviour
{
    GameObject go;
    Vector3 offset;
    // Start is called before the first frame update
    Vector3 prevPos;
    void Start()
    {
        go = GameObject.Find("AR Camera");
        offset = transform.position - go.transform.position;
        prevPos = transform.position;
    }


    // Update is called once per frame
    void Update()
    {
        Vector3 forwardVec =  go.transform.TransformPoint(offset);
        transform.LookAt(new Vector3(go.transform.position.x, transform.position.y, go.transform.position.z));
        transform.Rotate(Vector3.up, 180);
        transform.position = Vector3.Lerp(prevPos, forwardVec, 0.99f * Time.deltaTime);
        prevPos = transform.position;
        
    }
}
