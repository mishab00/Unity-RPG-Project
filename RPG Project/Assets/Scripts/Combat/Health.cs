using UnityEngine;

namespace RPG.Combat
{
    
    public class Health : MonoBehaviour {

        [SerializeField] float health = 100;

        bool isDead = false;

        public void TakeDamage(float damage) {
            health = Mathf.Max(health - damage, 0);
            print(health);
            if(health == 0 && !isDead) {
                DeathBehaviour();
                isDead = true;
            }
        }

        private void DeathBehaviour() {
            GetComponent<Animator>().SetTrigger("die");
        }
    }

}