using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopScript : MonoBehaviour
{
    private int gold;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Buy(GameObject product)
    {
        // gold -= product.price;
    }

    public int getGold() { return gold; }

    public void somethingDied(int reward)
    {
        gold += reward;
    }
}
