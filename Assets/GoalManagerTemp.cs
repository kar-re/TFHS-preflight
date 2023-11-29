using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalManagerTemp : MonoBehaviour
{
    [SerializeField]
    List<GameObject> checks;
    int current = 0;
    void Start() {
        checks = new List<GameObject>();
        for(int i = 0; i < transform.childCount; ++i){
            Transform child = transform.GetChild(i);
            checks.Add(child.gameObject);
        }
        
        
        foreach (GameObject check in checks) {
            check.SetActive(false);
        }
        checks[current].SetActive(true);
    }

    public void next() {
        checks[current].SetActive(false);
        current++;
        checks[current].SetActive(true);
    }
   
}
