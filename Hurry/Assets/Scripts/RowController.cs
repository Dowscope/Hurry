using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RowController : MonoBehaviour {

    public Sprite[] sprites;
    Sprite thisSprite;

    float Speed;
    bool isReverse = false;

    List<GameObject> enemies = new List<GameObject>();

	// Use this for initialization
	void Start () {
        int randomIndex = Random.Range(0, sprites.Length);
        thisSprite = sprites[randomIndex];

        if (transform.position.y < 4)
        {
            Speed = Random.Range(2, 5);
            if (Random.Range(0, 100) > 50)
            {
                Speed *= -1;
                isReverse = true;
            }
            createEnemys(2, 1);
        }else if (transform.position.y < 10)
        {
            Speed = Random.Range(5, 8);
            if (Random.Range(0, 100) > 50)
            {
                Speed *= -1;
                isReverse = true;
            }
            createEnemys(3, 1);
        }
    }
	
	// Update is called once per frame
	void Update () {

        foreach(GameObject go in enemies)
        {
            Vector3 pos = go.transform.position;
            pos.x += Speed * Time.deltaTime;

            if (isReverse && pos.x < -2)
            {
                pos.x = 14;
            }
            else if (!isReverse && pos.x > 14)
            {
                pos.x = -2;
            }

            go.transform.position = pos;
        }
        
	}

    void createEnemys(int numOfEnemies, int difficulty)
    {
        for (int i = 0; i < numOfEnemies; i++)
        {
            GameObject go = new GameObject("EnemyGO_" + i);
            go.transform.SetParent(this.transform,false);
            go.transform.position = new Vector3(Random.Range(0, 12), transform.position.y, 0);
            SpriteRenderer sr = go.AddComponent<SpriteRenderer>();
            sr.sprite = thisSprite;

            enemies.Add(go);
        }
    }
}
