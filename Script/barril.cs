using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class barrill : MonoBehaviour
{
    [SerializeField] private int lifeBarril = 3;

    public SpriteRenderer barril;
    public Sprite[] barrilImages = new Sprite[3];

    void Start()
    {
        barril = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        switch (lifeBarril)
        {

            case 1:
                barril.sprite = barrilImages[2];
                break;

            case 2:
                barril.sprite = barrilImages[2];
                break;

            case 3:
                barril.sprite = barrilImages[1];
                break;

            case 4:
                barril.sprite = barrilImages[0];
                break;

            case 0:
                GetComponent<Animator>().enabled = true;

                Destroy(GetComponent<Animator>(), 1f);
               
                Destroy(GetComponent<BoxCollider2D>(), 1);
                Destroy(GetComponent<barrill>());
                Destroy(GetComponent<SpriteRenderer>(), 1f);
                Destroy(GetComponent<Rigidbody2D>(), 1f);
                Destroy(GetComponent<Transform>());

                break;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerAttack")
        {
            lifeBarril--;
        }
    }
}
