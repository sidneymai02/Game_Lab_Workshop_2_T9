using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TripleShot : MonoBehaviour
{
    [SerializeField] public Transform firePoint;
    [SerializeField] public GameObject bulletPrefab;
    [SerializeField] public int NumberOfProjectiles;
    [SerializeField] private Transform ProjectileSpawnPosition;
    [SerializeField] private Transform AimOrigin;

    [SerializeField] public float bulletForce = 10f;
    [Range(0, 360)]
    [SerializeField] private float SpreadAngle = 20;
    

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    public void Shoot()
    {
        float angleStep = SpreadAngle / NumberOfProjectiles;
        float aimingAngle = AimOrigin.rotation.eulerAngles.z;
        float centeringOffset = (SpreadAngle / 2) - (angleStep / 2); //offsets every projectile so the spread is                                                                                                                         //centered on the mouse cursor
  
        for (int i = 0; i < NumberOfProjectiles; i++)
        {
            float currentBulletAngle = angleStep * i;
            
            Quaternion rotation = Quaternion.Euler(new Vector3(0, 0, aimingAngle + currentBulletAngle - centeringOffset));
            GameObject bullet = Instantiate(bulletPrefab, ProjectileSpawnPosition.position, rotation);
           
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(bullet.transform.right * bulletForce, ForceMode2D.Impulse);
        }
    }

}
