using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainTowerUI : MonoBehaviour
{

    private int speed;
    [SerializeField] private GameObject actionBar;
    [SerializeField] private OverUI overUI;
    [SerializeField] private TroopsUI troopBarUp;
    RectTransform rectTransform;
    // Start is called before the first frame update
    void Start()
    {
        speed = 1000;
        rectTransform = actionBar.GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {

        Vector2 pos = rectTransform.anchoredPosition;

        if (overUI.IsPointerOverUIElement() && !troopBarUp.getBarUP())
        {
            if (pos.y <= -485)
            {
                pos.y += speed * Time.deltaTime;
            }
        }
        else
        {
            pos.y = -625;
        }

        rectTransform.anchoredPosition = pos;
    }
}
