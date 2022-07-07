using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float panSpeed;
    private Vector3 origin;
    private Vector3 difference;
    private Vector2 resetCamera;
    private bool isDragging;
    private CanPlaceCharacter isBuying;
    // Start is called before the first frame update
    void Start()
    {
        isBuying = GameObject.Find("CanPlaceCharacter").GetComponent<CanPlaceCharacter>();
        resetCamera = Camera.main.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (!isBuying.getIsBuying())
        {
            handleMousePosition();
            if (isDragging)
            {
                Camera.main.transform.position = origin - difference;
                Camera.main.transform.position = new Vector3(
                Mathf.Clamp(Camera.main.transform.position.x, -5f, 6f),
                Mathf.Clamp(Camera.main.transform.position.y, -4.5f, 4.5f), transform.position.z);
            }
        }
    }

    private void handleMousePosition()
    {
        if (Input.GetMouseButton(0))
        {
            difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - Camera.main.transform.position;
            if (!isDragging)
            {
                isDragging = true;
                origin = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            }   
        }
        else
        {
            isDragging = false;
        }
    }

}
