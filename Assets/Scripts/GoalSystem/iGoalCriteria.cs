using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void Success();
public delegate void Failure();
public interface iGoalCriteria 
{
    event Success success;
    event Success failure;

}
