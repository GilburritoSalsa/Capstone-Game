using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{

    public static BuildManager instance;


    //This is to handle the singleton case!
    void awake()
    {
        if(instance != null)
        {
            Debug.LogError("More than one BuildManager is in scene!");
            return;
        }
        instance = this;
    }

    public GameObject arrorTowerPrefab;
    public GameObject boltTowerPrefab;

    private GameObject turretToBuild;

    public GameObject GetTurretToBuild()
    {
        return turretToBuild;
    }

    public void SetTurretToBuild(GameObject turret)
    {
        turretToBuild = turret;
    }
}
