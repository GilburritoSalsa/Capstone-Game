using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{

    public static BuildManager instance;


    //This is to handle the singleton case!
    void Awake()
    {
        if(instance != null)
        {
            Debug.LogError("More than one BuildManager is in scene!");
            return;
        }
        instance = this;
    }

    public GameObject arrowTowerPrefab;
    public GameObject boltTowerPrefab;


    void Start()
    {
        turretToBuild = arrowTowerPrefab;
    }



    private GameObject turretToBuild;

    public GameObject GetTurretToBuild()
    {
        return turretToBuild;
    }

    public void SetTurretToBuildArrow(GameObject turret)
    {
        turretToBuild = arrowTowerPrefab;
    }

    public void SetTurretToBuildBolt(GameObject turret)
    {
        turretToBuild = boltTowerPrefab;
    }
}
