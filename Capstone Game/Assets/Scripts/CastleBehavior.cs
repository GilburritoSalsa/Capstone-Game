using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastleBehavior : MonoBehaviour
{
    public int maxHp;
    private int currentHP;
    public GameObject manager;
    gameManager managerS;

    // Start is called before the first frame update
    void Start()
    {
        currentHP = maxHp;
        managerS = manager.GetComponent<gameManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void heal(int amount)
    {
        if (currentHP + amount >= maxHp)
            currentHP = maxHp;
        else
            currentHP += amount;
    }

    public void takeDamage(int dmg)
    {
        currentHP -= dmg;
        if (currentHP <= 0)
            managerS.lose();
    }

    public int getKeepHP() { return currentHP; }
}
