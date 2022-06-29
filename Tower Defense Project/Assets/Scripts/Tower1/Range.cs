using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Range : MonoBehaviour
{
    private List<GameObject> enemies;
    private bool priority;
    private Collider2D coll;

    private void Start()
    {
        coll = GetComponent<Collider2D>();
        enemies = new List<GameObject>();
    }

/*    private void Update()
    {

    }*/

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Enemy")
        {
            enemies.Add(coll.gameObject);
        }
    }

    void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Enemy")
        {
            enemies.Remove(coll.gameObject);
        }
    }

    public GameObject getTarget()
    {
        if (enemies.Count == 0 && !priority)
        {
            return null;
        }
        else
        {
            return enemies[0].gameObject;
        }
    }

    public int getSize()
    {

        return enemies.Count;
        
    }

    public List<GameObject> getList()
    {
        return enemies;
    }
}
