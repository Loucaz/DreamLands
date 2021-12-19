using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    private float posY;
    private float random;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Inventory.instance.AddItem(1);
            Destroy(gameObject);
        }
    }
    void Start()
    {
        posY = transform.position.y;
        random = Random.Range(0, 1f);
    }

    void Update()
    {
        float move = Mathf.PingPong((Time.time + random) * 0.2f, 0.1f);
        transform.position = new Vector3(transform.position.x, posY + move, transform.position.z);
        
    }
}
