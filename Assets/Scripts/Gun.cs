using System;
using System.Collections;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject bulletPrefab; //prefab asset
    public Transform bulletSpawn; //empty object at barell location
    public float bulletVelocity = 30; //velocity of bullet
    private float bulletPrefabLifeTime = 3f; //time before bullet object is destroyed

    void Update()
    {
        //left mouse click shoots bullet
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        // creates bullet object
        GameObject bullet =  Instantiate(bulletPrefab, bulletSpawn.position, Quaternion.identity); //prefab effect, spawns on barrel  opening empty game object, bullet rotation
        bullet.GetComponent<Rigidbody>().AddForce(bulletSpawn.forward.normalized  *  bulletVelocity, ForceMode.Impulse); //applies force to bullet based on velocity and mass

        // destory bullet for memory sake
        StartCoroutine(DestroyBullet(bullet, bulletPrefabLifeTime));

    }

    // gets ride of cloned bullet object after a set ammount of time
    private IEnumerator DestroyBullet(GameObject bullet, float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(bullet);
    }
}
