using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CastleBehavior : MonoBehaviour
{
    public int maxHp;
    private int currentHP;
    public GameObject manager;
    gameManager managerS;
    public Text t;
    public GameObject GM;

    private Color hurtColor = Color.red;
    private SpriteRenderer rend;
    private Color startColor;
    private GameObject instantiatedObj;
    private float timer = 0.6f;
    private float waitTime = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        startColor = rend.color;
        currentHP = maxHp;
        managerS = manager.GetComponent<gameManager>();
        t.text = "100/100";
        t.fontSize = 60;
        t.color = Color.black;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHP < 75 && currentHP > 49)
        {
            t.color = Color.yellow;
        }
        else if (currentHP < 50 && currentHP > 24)
        {
            t.color = new Color32(227, 145, 9, 255);
        }
        else if (currentHP < 25)
        {
            t.color = Color.red;
        }

        if (rend.color == hurtColor)
        {
            timer += Time.deltaTime;
                if (timer > waitTime)
            {
                rend.color = startColor;
                timer = timer - waitTime;
            }
        }

        t.text = currentHP.ToString() + "/100";

        if (currentHP <= 0)
        {
            DeathScreen();
        }
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

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            instantiatedObj = collision.gameObject;
            Destroy(instantiatedObj);
            rend.color = hurtColor;
            currentHP -= 10;
            spawnerBehavior.instance.enemyDies();
        }
    }

    void DeathScreen()
    {
        SceneManager.LoadScene("DeathScene");
    }
}
