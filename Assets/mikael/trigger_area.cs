using UnityEditor;
using UnityEngine;

public class trigger_area : MonoBehaviour
{
    public GameObject LepakkoPrefab;
    public GameObject LepakkoSpawn;
    public Transform player;
    public Lepakko_chase Lepakko;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {   
            Instantiate(LepakkoPrefab, LepakkoSpawn.transform.position, Quaternion.identity);

           
                Lepakko.StartChasing(other.transform);
            
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && Lepakko != null)
        {
         
        }
    }
}