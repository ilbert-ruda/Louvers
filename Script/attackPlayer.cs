using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackPlayer : MonoBehaviour
{
    private BoxCollider2D colliderAtkPlayer;


    // Start is called before the first frame update
    void Start()
    {
        colliderAtkPlayer = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerController.move < 0)
        {
            colliderAtkPlayer.offset = new Vector2(-0.6f, 0);
        }
        else if (PlayerController.move > 0)
        {
            colliderAtkPlayer.offset = new Vector2(-0.6f, 0);
        }
    }
}
