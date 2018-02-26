using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public GameObject RowPrefab;

    List<GameObject> Rows = new List<GameObject>();
    GameObject RowObjects;

    Vector3 CameraOffset = new Vector3(6, 4, -10);
    float cameraSpeed = 1f;

	// Use this for initialization
	void Start () {
        Camera.main.transform.position = CameraOffset;

        RowObjects = new GameObject();
        RowObjects.name = "RowObjects";
        RowObjects.transform.SetParent(this.transform);

        for (int i = 1; i < 10; i++)
        {
            CreateRow(i);
        }
    }
	
	// Update is called once per frame
	void Update () {
        Vector3 player = transform.Find("PlayerObject").position;
        Vector3 camPos = Camera.main.transform.position;
        if(player != null)
        {
            if (player.y > camPos.y - 2)
            {
                camPos.y += cameraSpeed * Time.deltaTime;
                Camera.main.transform.position = camPos;
            }
        }else
        {
            Debug.Log("Null");
        }
	}

    void CreateRow(int y)
    {
        Vector3 pos = new Vector3(0, y, 0);
        
        GameObject go = Instantiate(RowPrefab);
        go.name = "row_" + y;
        go.transform.SetParent(RowObjects.transform);
        go.transform.position = pos;
        Rows.Add(go);
    }
}
