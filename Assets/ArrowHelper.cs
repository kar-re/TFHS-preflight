using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowHelper : MonoBehaviour
{
    [SerializeField]
    GoalManagerTemp goalmanager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var lookat = Quaternion.LookRotation(transform.position - goalmanager.currentTransform.position);
        transform.rotation = lookat;
    }
}
