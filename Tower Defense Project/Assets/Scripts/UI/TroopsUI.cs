using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TroopsUI : MonoBehaviour
{
    [SerializeField] private Collider2D mainTowerColl;
    [SerializeField] private GameObject showRange;
    [SerializeField] private GameObject actionBar;
    [SerializeField] private OverUI overUI;
    RectTransform rectTransform;
    private bool barUp;
    private float speed;

    private void Awake()
    {
        speed = 1000;
        rectTransform = actionBar.GetComponent<RectTransform>();
        EventSystem.current.SetSelectedGameObject(this.gameObject);
    }

    public void Update()
    {
        if (!overUI.IsPointerOverUIElement())
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero, Mathf.Infinity, LayerMask.GetMask("MainTower"));
                if (hit.collider == mainTowerColl)
                {
                    barUp = true;
                    showRange.GetComponent<SpriteRenderer>().enabled = true;
                }
                else
                {
                    showRange.GetComponent<SpriteRenderer>().enabled = false;
                    barUp = false;
                }
            }
        }

        if (barUp)
        {
            OnSelect();
        }
        else
        {
            OnDeselect();
        }

    }

    public void OnSelect()
    {
        Vector2 pos = rectTransform.anchoredPosition;
        if (pos.y <= -485)
        {
            pos.y += speed * Time.deltaTime;
        }
           
        rectTransform.anchoredPosition = pos;
    }

    public void OnDeselect()
    {
        Vector2 pos = rectTransform.anchoredPosition;
        if(pos.y >= -625)
        {
            pos.y-= speed*Time.deltaTime;
        }
        rectTransform.anchoredPosition = pos;
    }

    public bool getBarUP()
    {
        return this.barUp;
    }
}
