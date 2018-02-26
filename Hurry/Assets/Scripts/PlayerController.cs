using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    
    // Grab instance of the sprite
    public Sprite playerSprite;

    // Create an object of the PLAYER
    public GameObject playerGO { get; protected set; }

    // Use this for initialization
    void Start () {
        playerGO = new GameObject();
        playerGO.name = "PlayerObject";
        playerGO.transform.position = new Vector3(6, 0, 0);
        SpriteRenderer player_sr = playerGO.AddComponent<SpriteRenderer>();
        player_sr.sprite = playerSprite;
        playerGO.transform.SetParent(this.transform);
    }
	
	// Update is called once per frame
	void Update () {
        if (playerGO != null)
        {
            Vector3 playerPosition = playerGO.transform.position;

            if (Input.GetKeyUp(KeyCode.UpArrow))
            {
                playerPosition.y++;
            }
            if (Input.GetKeyUp(KeyCode.DownArrow))
            {
                playerPosition.y--;
            }
            if (Input.GetKeyUp(KeyCode.LeftArrow))
            {
                playerPosition.x--;
            }
            if (Input.GetKeyUp(KeyCode.RightArrow))
            {
                playerPosition.x++;
            }

            playerGO.transform.position = playerPosition;
        }
    }
}
