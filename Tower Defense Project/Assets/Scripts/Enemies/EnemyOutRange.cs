using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyOutRange : MonoBehaviour
{
    private bool outRange;

    public bool getOutRange()
    {
        return this.outRange;
    }

    public void setOutRange(bool outRange)
    {
        this.outRange = outRange;
    }

}
