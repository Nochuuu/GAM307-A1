using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayerEvent : MonoBehaviour {

    public delegate void DamagePlayerAction(GameObject player);
    public static event DamagePlayerAction OnDamagePlayer;

    private void OnTriggerEnter(Collider collider)
    {
        if (!GetComponentInParent<Enemy> ().isDead)
        {
            if (collider.gameObject.tag == "Player")
            {
                if (OnDamagePlayer != null)
                {
                    //Call our event here
                    OnDamagePlayer(collider.gameObject);
                }
            }
        }
    }

}
