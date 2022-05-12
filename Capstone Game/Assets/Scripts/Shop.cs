using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    BuildManager buildManager;

    void start()
    {
        buildManager = buildManager.instance;
    }

   public void PurchaseArrowTower()
    {
        Debug.Log("Arrow Tower Purchased");
        buildManager.SetTurretToBuild(buildManager.arrowTowerPrefab);
    }

    public void PurchaseBoltTower()
    {
        Debug.Log("Bolt Tower Purchased");
        buildManager.SetTurretToBuild(buildManager.boltTowerPrefab);
    }
}
