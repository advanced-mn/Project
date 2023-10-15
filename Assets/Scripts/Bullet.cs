using UnityEngine;
using Photon.Pun;

public class Bullet : MonoBehaviourPun
{
    public GameObject hit_effect; // Assign the hit effect prefab in the Inspector
    public int damageAmount = 5; // Set the amount of damage the bullet does

    void Start()
    {
        if(photonView.IsMine)
            Destroy(gameObject, 5f); // Bullet will despawn after 5 seconds
    }

    void OnTriggerEnter2D(Collider2D col)
    {            
        Health health = col.gameObject.GetComponent<Health>();
        PhotonView v = col.gameObject.GetComponent<PhotonView>();

        //Debug.Log(v.ViewID+ ": " + health.ToString());

        if (health != null)
        {
            health.TakeDamage(damageAmount);
            ShowHitEffect(col.transform.position);

            if(health.currentHealth <= 0)
            {
                Debug.Log("DEAD");
                //health.Die();
                Destroy(col.gameObject);
            }
        }
        else
        {
            Debug.Log("No object detected");
        }

        Debug.Log("Bullet Hit: " + health.currentHealth);
        PhotonNetwork.Destroy(gameObject);
    }

    void ShowHitEffect(Vector3 position)
    {
        if (hit_effect != null)
        {
            Vector3 effectPosition = new Vector3(position.x, position.y, hit_effect.transform.position.z);
            GameObject effect = PhotonNetwork.Instantiate(hit_effect.name, effectPosition, Quaternion.identity);
            Destroy(effect, 0.1f); // Destroy the effect after 2 seconds, adjust according to your effect's duration
        }
    }
}
