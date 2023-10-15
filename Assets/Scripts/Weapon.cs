using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;


public class Weapon : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float force;

    public void Fire()
    {
        GameObject bullet = PhotonNetwork.Instantiate(bulletPrefab.name, firePoint.position, firePoint.rotation);
        bullet.GetComponent<Rigidbody2D>().AddForce(firePoint.up * force, ForceMode2D.Impulse);
    }
}
