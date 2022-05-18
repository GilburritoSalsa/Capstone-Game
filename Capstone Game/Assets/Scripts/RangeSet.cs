using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeSet : MonoBehaviour
{
    // Start is called before the first frame update
    CircleCollider2D rangeSet;

    private float range = 12.5f;

    void Start()
    {
        rangeSet = GetComponent<CircleCollider2D>();
        rangeSet.radius = range;
    }
}
