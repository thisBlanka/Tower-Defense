using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleTroop : MonoBehaviour
{
    private Vector2 mousePosition;
    private Buy isBuying;
    private CanPlaceCharacter canPlace;
    // Start is called before the first frame update
    void Start()
    {
        canPlace = GameObject.Find("CanPlaceCharacter").GetComponent<CanPlaceCharacter>();
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    // Update is called once per frame
    void Update()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        transform.Translate(mousePosition);
        if (Input.GetMouseButtonDown(1))
        {
            canPlace.setIsBuying(false);
            Destroy(gameObject);
        }
    }
}
