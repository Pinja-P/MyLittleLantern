using UnityEditor;
using UnityEngine;

public class trigger_area : MonoBehaviour
{
    public GameObject LepakkoPrefab;
    public GameObject LepakkoSpawn;
    public Transform player;
    public Lepakko_chase Lepakko;
    private bool HasSpawned = false;
  

   

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!HasSpawned && other.CompareTag("Player"))
        {   
            HasSpawned = true;
            GameObject spawnedObj = Instantiate(LepakkoPrefab, LepakkoSpawn.transform.position, Quaternion.identity);
            

            if (spawnedObj.TryGetComponent(out Lepakko_chase batScript))
            {
                Lepakko = batScript;
                Lepakko.StartChasing(other.transform);
            }
            
        }
    }
}