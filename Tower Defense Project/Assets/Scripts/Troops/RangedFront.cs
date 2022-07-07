using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedFront : MonoBehaviour
{
    static Queue<GameObject> queueRange;
    static GameObject rangeFront;
    static Collider2D rangeFrontColl;
    static bool sampleRangeGone;
    [SerializeField] private GameObject sampleTroop;


    private void Start()
    {
        sampleRangeGone = false;
        queueRange = new Queue<GameObject>();   
        queueTroop(sampleTroop);
    }

    private void Update()
    {
        if (!sampleRangeGone)
        {
            if(queueRange.Count > 1)
            {
                dequeueTroop();
                sampleRangeGone = true;
            }
        }
        
        if (sampleRangeGone && queueRange.Count < 1)
        {
            queueTroop(sampleTroop);
            sampleRangeGone = false;
        }

        if (queueRange.Count > 0)
        {
            rangeFront = queueRange.Peek().gameObject;
            setInfront(queueRange.Peek().gameObject);
            rangeFrontColl = rangeFront.GetComponent<Collider2D>();
        }
    }

    public void queueTroop(GameObject troop)
    {
        queueRange.Enqueue(troop);
        rangeFront = queueRange.Peek();
        rangeFrontColl = rangeFront.GetComponent<Collider2D>();
    }

    public void dequeueTroop()
    {
        queueRange.Dequeue();
        rangeFront = queueRange.Peek();
        rangeFrontColl = rangeFront.GetComponent<Collider2D>();
    }

    public int queueSize()
    {
        return queueRange.Count;
    }

    public void queueSample()
    {
        //queueTroop(sampleTroop);
    }

    public void queueClear()
    {
        queueRange.Clear();
    }

    public GameObject getInFront()
    {
        return rangeFront;
    }

    public void setInfront(GameObject atFrontColl)
    {
        atFrontColl = rangeFront;
    }

    public Collider2D getInFrontColl()
    {
        return rangeFrontColl;
    }

    public void setInfrontColl(Collider2D atFrontColl)
    {
        atFrontColl = rangeFrontColl;
    }
}
