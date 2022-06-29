using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TroopsInRange : MonoBehaviour
{
    private List<GameObject> troops;
    private TroopLife troopLife;
    private float coolDown;
    private bool priority;
    private Collider2D coll;

    private void Start()
    {
        coll = GetComponent<Collider2D>();
        coolDown = 0f;
        troops = new List<GameObject>();
    }

    private void Update()
    {
        if (priority)
        {
            if (coolDown <= 0f)
            {
                troopLife = getTarget().GetComponent<TroopLife>();
                troopLife.setTroopLife(troopLife.getTroopLife() - 1);
                coolDown = 0.5f;
            }
            else
            {
                coolDown -= Time.deltaTime;
            }
        }
        else if (troops.Count > 0)
        {
            if (coolDown <= 0f)
            {
                troopLife = getTarget().GetComponent<TroopLife>();
                troopLife.setTroopLife(troopLife.getTroopLife() - 3);
                coolDown = 0.5f;
            }
            else
            {
                coolDown -= Time.deltaTime;
            }
        }

    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Troop")
        {
            troops.Add(coll.gameObject);
        }
    }

    void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Troop")
        {
            troops.Remove(coll.gameObject);
        }
    }

    public GameObject getTarget()
    {
        if (troops.Count == 0 && !priority)
        {
            return null;
        }
        else
        {
            return troops[0].gameObject;
        }
    }

    public int getSize()
    {
        if (priority)
        {
            return 1;
        }
        else
        {
            return troops.Count;
        }
    }
}
