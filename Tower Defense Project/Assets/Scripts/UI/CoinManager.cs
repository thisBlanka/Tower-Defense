using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CoinManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI coinText;
    private float coinAmount;
    private float currentCost;

    // Start is called before the first frame update
    void Start()
    {
        coinAmount = 30f;
        coinText.text = coinAmount.ToString("0");
    }

    // Update is called once per frame
    void Update()
    {
        coinAmount += Time.deltaTime;
        coinText.text = coinAmount.ToString("0");    
    }

    public void setCoin(float coinAmount)
    {
        this.coinAmount = coinAmount;
    }

    public float getCoin()
    {
        return this.coinAmount;
    }

    public void setCurrentCost(float currentCost)
    {
        this.currentCost = currentCost;
    }

    public float getCurrentCost()
    {
        return this.currentCost;
    }

}
