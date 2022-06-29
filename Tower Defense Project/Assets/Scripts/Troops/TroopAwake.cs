using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TroopAwake : MonoBehaviour
{
    public TroopFront front;

    private void Awake()
    {
        front.queueTroop(this.gameObject);
    }
}
