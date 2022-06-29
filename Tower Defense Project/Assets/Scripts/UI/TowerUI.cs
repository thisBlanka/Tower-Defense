using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerUI : MonoBehaviour
{
    [SerializeField] private OverUI overUI;
    [SerializeField] private Collider2D tower;
    [SerializeField] private GameObject showRange;

    void Start()
    {
        overUI = GameObject.Find("Main Camera").GetComponent<OverUI>();
    }

    void Update()
    {
        if (!overUI.IsPointerOverUIElement())
        {
            if (Input.GetMouseButtonDown(0))
            {

                Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero, Mathf.Infinity, LayerMask.GetMask("Tower"));
                if (hit.collider == tower)
                {
                    showRange.GetComponent<SpriteRenderer>().enabled = true;
                }
                else
                {
                    if (showRange.tag != "RangeStatic")
                    {
                        showRange.GetComponent<SpriteRenderer>().enabled = false;
                    }
                }
            }
        }
    }
}
