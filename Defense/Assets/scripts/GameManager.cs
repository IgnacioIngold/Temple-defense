using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GameManager : MonoBehaviour
{
    List<Enemy> enemies = new List<Enemy>();
    public static GameManager instance;
    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
            instance = this;
        else Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AddEnemy(Enemy e)
    {
        if (enemies.Contains(e))
            return;

        enemies.Add(e);
    }
    public Enemy GiveEnemy(directions dir)
    {
        if (enemies == null || enemies.Count == 0) return null;

        return enemies.SkipWhile(x=> x.GetNextDir()!=dir).First();
    }
}
