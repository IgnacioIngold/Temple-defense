using System.Collections;
using System.Collections.Generic;
//using System.Numerics;
using UnityEngine;

public enum directions { 

    Up,
    Down,
    Left,
    Right,
    Count
}
public class Enemy : MonoBehaviour
{
    #region variables publicas
    public Transform target;
    public float speed;
    public directions mydirections;
    public List<directions> myCombo = new List<directions>();

    public float arrowWidth;
    public Transform comboHolder;

    public GameObject upArrow;
    public GameObject downArrow;
    public GameObject leftArrow;
    public GameObject rightArrow;



    #endregion
    Vector3 dir;
    public Queue<int> KillCombo;

    void Start()
    {
        //GetMyCombo(1);
        myCombo.Add(directions.Up);
        myCombo.Add(directions.Right);
        showcombo();
        GameManager.instance.AddEnemy(this);
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
            return;
        dir = (target.transform.position - transform.position).normalized;
        transform.position += dir * speed * Time.deltaTime;
    }

    void GetMyCombo(int dif)
    {
        for (int i = 1; i <= dif; i++)
        {
            int rnd = Random.Range(0, (int)directions.Count);
            myCombo.Add((directions)rnd);
        }
    }
    public void Takedamage()
    {
        Debug.Log("me pegaron");
        if (myCombo.Count > 1)
            myCombo.Remove(0);
        else Destroy(gameObject);

        

        StartCoroutine(FlashMaterial());

    }

    public directions GetNextDir()
    {
        if (myCombo == null || myCombo.Count == 0)
            return directions.Count;
        else return myCombo[0];
    }

    void showcombo()
    {
        for (int i = 0; i < myCombo.Count; i++)
        {
            //P-L*c%2-I
            Vector3 pos = new Vector3(comboHolder.transform.position.x-arrowWidth*((myCombo.Count/2)-i), comboHolder.transform.position.y, comboHolder.transform.position.z);
            switch (myCombo[i])
            {
                case directions.Up:
                    Instantiate(upArrow, pos, Quaternion.identity);
                    break;
                case directions.Down:
                    Instantiate(downArrow, pos, Quaternion.identity);
                    break;
                case directions.Left:
                    Instantiate(leftArrow, pos, Quaternion.identity);
                    break;
                case directions.Right:
                    Instantiate(rightArrow, pos, Quaternion.identity);
                    break;

            }
        }

    }
    IEnumerator FlashMaterial()
    {
        Renderer ren = GetComponentInChildren<Renderer>();
        Color oldColor = ren.material.color;
        ren.material.color = Color.yellow;
        yield return new WaitForSeconds(0.1f);
        ren.material.color = oldColor;

    }

}
