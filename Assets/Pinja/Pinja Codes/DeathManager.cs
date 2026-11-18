using UnityEngine;

public class DeathManager : MonoBehaviour
{
    public static DeathManager Death;
    public Transform respawnPoint;

    private void Awake()
    {
        Death = this;
    }


     private void OnTriggerEnter2D(Collider2D collision)
     {
         if (collision.CompareTag("Death"))
         {
             transform.position = respawnPoint.position;
         }
     } 

}
