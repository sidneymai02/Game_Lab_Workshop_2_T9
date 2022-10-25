using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public float duration = 4f;
    public GameObject pickupEffect;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine (Pickup(other));
        }
    }
    IEnumerator Pickup(Collider2D player)
    {
        Instantiate(pickupEffect, transform.position, transform.rotation);

        TripleShot effect = player.GetComponent<TripleShot>();
        effect.NumberOfProjectiles += 2;

        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<Collider2D>().enabled = false;

        yield return new WaitForSeconds(duration);

        Destroy(this.gameObject);
    }
}
