using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace YB
{


    public class PlayerStatsMo : MonoBehaviour
    {
        //définission des variables
        public int healthLevel = 10;
        public float maxHealth;
        public float currentHealth;

        public bool isDead;


        void Start()
        {
            maxHealth = SetMaxHealthFromHealthLevel(); //fait appelle a la fonction 
            currentHealth = maxHealth; //défini la vie au départ; à la vie maximum.
        
        }


        private float SetMaxHealthFromHealthLevel()
        {
            maxHealth = healthLevel * 10; //simple formule qui détermine le niveau de vie du joueur/ennemi
            return maxHealth; //renvoie la valeur
        }

        public void TakeDamage(int damage) 
        {
            if (isDead) //si le joueur est mort, la fonction est inactive
                return;

            currentHealth = currentHealth - damage; //soustrait la vie du joueur dépendemment de la vie

            if(currentHealth <= 0) //permet au joueur de mourir si sa vie est inférieur à 0
            {
                currentHealth = 0; //permet de normaliser la vie du joueur à 0.
                isDead = true; //active la "mort" du joueur pour ne plus bouger.

            }
        }
    }
}