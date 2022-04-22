using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace YB
{
    public class DamagePlayerMo : MonoBehaviour
    {
        public int damage = 25; //variable pour le montant de dégâts

        private void OnTriggerEnter(Collider other) //si le collider est Triggered (touché/activé)
        {
            PlayerStatsMo playerStats = other.GetComponent<PlayerStatsMo>(); //appel au script player stats

            if (playerStats != null) 
            {
                playerStats.TakeDamage(damage);
            }
        }
    }
}