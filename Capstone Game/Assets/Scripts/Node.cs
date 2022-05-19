using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{

    public Color hoverColor;

    public GameObject turret;

    private SpriteRenderer rend;
    private Color startColor;
<<<<<<< Updated upstream


=======
    private Vector3 pos;
   
    private Color buildColor = Color.gray;
>>>>>>> Stashed changes
    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        startColor = rend.color;
    }

    

    void update()
    {
       
    }

    void OnMouseDown()
    {
        if (turret != null)
        {
            Debug.Log("Can't build turret there! - TODO: Display on screen");
            return;
        }
        //first add a build delay and change the color!
        //build a turret
        GameObject turretToBuild = BuildManager.instance.GetTurretToBuild();
<<<<<<< Updated upstream
        turret = (GameObject)Instantiate(turretToBuild, transform.position, transform.rotation);
    
=======
        pos = transform.position;
        pos.z += -0.5f;

        turret = (GameObject)Instantiate(turretToBuild, transform.position, transform.rotation);
        rend.color = Color.clear;
        startColor = Color.clear;
        hoverColor = Color.clear;
>>>>>>> Stashed changes
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
