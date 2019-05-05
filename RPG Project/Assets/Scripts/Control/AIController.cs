using UnityEngine;

namespace RPG.Control
{
    public class AIController : MonoBehaviour
    {
        [SerializeField] float chaseDistance = 5f;

        private void Update() {
            GameObject player =  GameObject.FindWithTag("Player");
            bool inChaseRadius = Vector3.Distance(transform.position, player.transform.position) <= chaseDistance;
            print(gameObject.name + " is in chase? " + inChaseRadius);
        }
    }
}