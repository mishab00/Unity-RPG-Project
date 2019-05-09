using UnityEngine;

namespace RPG.Core
{
    
    public class Health : MonoBehaviour {

        [SerializeField] float healthPoints = 100;

        bool isDead = false;

        public bool IsDead() {
            return isDead;
        }

        public void TakeDamage(float damage) {
            healthPoints = Mathf.Max(healthPoints - damage, 0);
            print(gameObject.name + " has " +  healthPoints);
            if(healthPoints == 0) {
                Die();
            }
        }

        private void Die() {
            if(!isDead) {
                GetComponent<Animator>().SetTrigger("die");
                isDead = true;
            }
        }
    }

}