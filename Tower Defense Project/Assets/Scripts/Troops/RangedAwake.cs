using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedAwake : MonoBehaviour
{
    public RangedFront front;

    private void Awake()
    {
        front.queueTroop(this.gameObject);
    }
}
