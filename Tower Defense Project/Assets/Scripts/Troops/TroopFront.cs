using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TroopFront : MonoBehaviour
{
    static Queue<GameObject> queueTroops;
    static GameObject inFront;
    static Collider2D frontColl;
    static bool sampleTroopGone;
    [SerializeField] private GameObject sampleTroop;

    private void Start()
    {
        sampleTroopGone = false;
        queueTroops = new Queue<GameObject>();   
        queueTroop(sampleTroop);
    }

    private void Update()
    {
        if (!sampleTroopGone)
        {
            if(queueTroops.Count > 1)
            {
                dequeueTroop();
                sampleTroopGone = true;
            }
        }
        
        if (sampleTroopGone && queueTroops.Count < 1)
        {
            queueTroop(sampleTroop);
            sampleTroopGone = false;
        }

        if (queueTroops.Count > 0)
        {
            inFront = queueTroops.Peek().gameObject;
            setInfront(queueTroops.Peek().gameObject);
            frontColl = inFront.GetComponent<Collider2D>();
        }
    }

    public void queueTroop(GameObject troop)
    {
        queueTroops.Enqueue(troop);
        inFront = queueTroops.Peek();
        frontColl = inFront.GetComponent<Collider2D>();
    }

    public void dequeueTroop()
    {
        queueTroops.Dequeue();
        inFront = queueTroops.Peek();
        frontColl = inFront.GetComponent<Collider2D>();
    }

    public int queueSize()
    {
        return queueTroops.Count;
    }

    public void queueSample()
    {
        //queueTroop(sampleTroop);
    }

    public void queueClear()
    {
        queueTroops.Clear();
    }

    public GameObject getInFront()
    {
        return inFront;
    }

    public void setInfront(GameObject atFrontColl)
    {
        atFrontColl = inFront;
    }

    public Collider2D getInFrontColl()
    {
        return frontColl;
    }

    public void setInfrontColl(Collider2D atFrontColl)
    {
        atFrontColl = frontColl;
    }

}
