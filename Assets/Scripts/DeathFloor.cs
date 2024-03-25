using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathFloor : MonoBehaviour
{
    public Vector3 checkPos;
    public GameObject player;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {

            Player playerHealth = player.GetComponent<Player>();

            if (playerHealth != null)
            {
                
                playerHealth.TakeDamage(20f);
            }

            player.transform.position = checkPos;


         
        }
    }
}
