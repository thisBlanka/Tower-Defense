using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanPlaceCharacter : MonoBehaviour
{
    private SpriteRenderer sprite;
    private bool isBuying;
    // Start is called before the first frame update
    void Start()
    {
        this.sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isBuying)
        {
            sprite.enabled = true;
        }
        else
        {
            sprite.enabled = false;
        }
    }

    public bool getIsBuying()
    {
        return isBuying;
    }

    public void setIsBuying(bool isBuying)
    {
        this.isBuying = isBuying;
    }
}
