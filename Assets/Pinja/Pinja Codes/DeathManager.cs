using UnityEngine;

public class DeathManager : MonoBehaviour
{
    public static DeathManager Death;
    public Transform respawnPoint;
    public GameObject Camera;

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
