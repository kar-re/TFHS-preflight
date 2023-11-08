using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    [SerializeField]
    iGoalCriteria criteria;
    public Success success;
    [SerializeField]
    Sprite image;
    [TextAreaAttribute]
    [SerializeField]
    string text;
    // Start is called before the first frame update
    void Start()
    {
        criteria.success += success;
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
