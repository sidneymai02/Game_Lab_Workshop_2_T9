using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [SerializeField]public int duration;
    //public GameObject pickupEffect;
    [SerializeField]public int projectileamt;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine (Pickup(other));
        }
    }
    IEnumerator Pickup(Collider2D player)
    {
        //Instantiate(pickupEffect, transform.position, transform.rotation);

        TripleShot effect = player.GetComponent<TripleShot>();
        effect.NumberOfProjectiles += projectileamt;

        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<Collider2D>().enabled = false;

        yield return new WaitForSeconds(duration);
        effect.NumberOfProjectiles -= projectileamt;

        Destroy(this.gameObject);
    }
}
