using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bag : MonoBehaviour
{
    // Start is called before the first frame update
    public int CoinCount { get; private set; }
    public static Bag Instance { get; private set; }
    public event System.Action<Bag> OnUpdate;
    public void Awake()
    {
        Instance = this;
    }

    public void AddCoin(int count)
    {
        CoinCount += count;
        OnUpdate?.Invoke(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDestroy()
    {
        Instance = null;
    }
}
