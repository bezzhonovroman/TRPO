using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BagUI : MonoBehaviour
{
    // Start is called before the first frame update
    public Text CoinCount;

    public void Start()
    {
        Bag.Instance.OnUpdate += UpdateUI;
    }
    // Update is called once per frame
    public void UpdateUI (Bag bag)
    {
        CoinCount.text = bag.CoinCount.ToString();
    }

    private void OnDestroy()
    {
        Bag.Instance.OnUpdate -= UpdateUI;
    }
}
