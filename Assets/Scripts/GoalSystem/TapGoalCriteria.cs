using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class TapGoalCriteria: MonoBehaviour, iGoalCriteria
{
    Collider col;

    public event Success success;
    public event Success failure;

    void Start() {
        col = GetComponent<SphereCollider>();
    }
    void Update(){
        if (Input.GetMouseButtonDown(0)){
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit, Mathf.Infinity)){
                GameObject obj = hit.collider.gameObject;
                if (hit.collider == col) {
                    success.Invoke();
                }
            }
        }
    }

}
