using UnityEngine;
using RPG.Combat;
using RPG.Core;
namespace RPG.Control
{
    public class AIController : MonoBehaviour
    {
        [SerializeField] float chaseDistance = 5f;

        Fighter fighter;
        Health health;
        GameObject player;

        private void Start() {
            player = GameObject.FindWithTag("Player");
            fighter = GetComponent<Fighter>();
            health = GetComponent<Health>();
        }

        private void Update()
        {
            if(health.IsDead()) return;

            if(InAttackRangeOfPlayer() && CanAttack()) {
                print(gameObject.name + " is in chase radius");
                fighter.Attack(player.gameObject);

            } else {
                fighter.Cancel();
            }
        }

        private bool CanAttack() {
            bool playerIsValid = fighter.CanAttack(player.gameObject);
            //bool enemyIsValid = fighter.CanAttack(gameObject);
            return playerIsValid;
        }

        private bool InAttackRangeOfPlayer()
        {
            float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);
            return distanceToPlayer <= chaseDistance; 
        }
    }
}