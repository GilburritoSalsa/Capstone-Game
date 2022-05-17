using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{

    public Color hoverColor;

    public GameObject turret;

    private SpriteRenderer rend;
    private Color startColor;


    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        startColor = rend.color;
    }

    

    void OnMouseDown()
    {
        if (turret != null)
        {
            Debug.Log("Can't build turret there! - TODO: Display on screen");
            return;
        }
        //build a turret
        GameObject turretToBuild = BuildManager.instance.GetTurretToBuild();
        turret = (GameObject)Instantiate(turretToBuild, transform.position, transform.rotation);
    
    }
    void OnMouseEnter()
    {
        rend.color = hoverColor;
    }

    void OnMouseExit()
    {
        rend.color = startColor;
    }
}
