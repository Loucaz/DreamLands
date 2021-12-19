using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    private int hitBroke;
    Vector3 scaleChange = new Vector3(-0.01f, -0.005f, -0);
    int anime;
    float scaleBase;
    // Start is called before the first frame update
    void Start()
    {
        hitBroke=0;
        anime = 2;
        scaleBase = this.transform.localScale.y;
    }

    // Update is called once per frame
    void Update()
    {
        
        if(anime < 2)
        {
            this.transform.localScale += scaleBase*scaleChange;
            if (this.transform.localScale.y < scaleBase * 0.7f || this.transform.localScale.y > scaleBase * 1.0f)
            {
                scaleChange = -scaleChange;
                anime++;
                if (hitBroke>2 && anime>1)
                {
                    StartCoroutine(DestroyTree());
                }
            }
        }

    }
    void OnMouseDown()
    {

        if (anime>1)
        {
            hitBroke++;
            MovePlayer.instance.AnimationPlay("Player_Axe");
            StartCoroutine(animeRAZ());
        }
    }
    private IEnumerator DestroyTree()
    {
        yield return new WaitForSeconds(0.2f);
        Spawn.Item("items/wood", this.transform.position);
        Destroy(gameObject);
    }

    private IEnumerator animeRAZ()
    {
        yield return new WaitForSeconds(0.2f);
        anime = 0;
    }
}

