using UnityEngine;

public class trigger_area : MonoBehaviour
{
    public Transform player;
    public Lepakko_chase Lepakko;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {Debug.Log("Player entered the trigger area.");
            if (Lepakko != null)
            {
                Lepakko.StartChasing(other.transform);
            }
        
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && Lepakko != null)
        {
            Lepakko.StopChasing();
        }
    }
}