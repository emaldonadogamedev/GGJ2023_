using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveStraightTowardsTarget : MonoBehaviour
{
    [SerializeField]
    private Transform m_target;

    void Update()
    {
        if(m_target == null)
            return;


    }
}
