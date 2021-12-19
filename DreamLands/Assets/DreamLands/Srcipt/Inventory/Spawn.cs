using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public static void Item(string name, Vector3 cordinate)
    {
        Texture2D texture = (Texture2D)Resources.Load(name);

        GameObject ressource = new GameObject(name);

        ressource.transform.position = cordinate;

        ressource.AddComponent<SpriteRenderer>();
        ressource.GetComponent<SpriteRenderer>().sortingOrder = 100;
        ressource.GetComponent<SpriteRenderer>().sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f), 32.0f);

        ressource.AddComponent<CircleCollider2D>();
        ressource.GetComponent<CircleCollider2D>().isTrigger = true;

        ressource.AddComponent<PickUpItem>();
    }

    public static void Tree(Vector3 cordinate)
    {
        Texture2D texture = (Texture2D)Resources.Load("element/tree");

        GameObject ressource = new GameObject("tree" + cordinate);

            ressource.AddComponent<SpriteRenderer>();
        ressource.GetComponent<SpriteRenderer>().sortingOrder = 100;
        ressource.GetComponent<SpriteRenderer>().sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f), 32.0f);

        ressource.AddComponent<BoxCollider2D>();


        ressource.AddComponent<Tree>();
        ressource.transform.position = cordinate;


        if (UnityEngine.Random.Range(1, 101) <= 25)
        {
            ressource.GetComponent<BoxCollider2D>().size = new Vector2(0.5f, 0.75f); ;
            if (UnityEngine.Random.Range(1, 101) <= 25)
            {
                ressource.transform.localScale *= 4;
            }
            else
            {

                ressource.transform.localScale *= 2;
            }
        }
        else
            {

            ressource.GetComponent<BoxCollider2D>().size = new Vector2(1f, 1f); ;
        }


    }

}
