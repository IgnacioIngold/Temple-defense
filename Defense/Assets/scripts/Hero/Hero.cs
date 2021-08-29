using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
    Enemy target;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            Attack(directions.Up);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Attack(directions.Down);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Attack(directions.Left);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Attack(directions.Right);
        }
    }

    void Attack(directions dir)
    {
        if(target == null)
        {
            Enemy newEnemy = GameManager.instance.GiveEnemy(dir);
            if (newEnemy == null) return;

            target = newEnemy;
            target.Takedamage();
        }
        else
        {
            if (target.GetNextDir() == dir) target.Takedamage();
            else { 
                Debug.Log("perdi el combo");
                target = null;
            }
        }
            

    }
}
