using UnityEditor;
using UnityEngine;

public class trigger_area : MonoBehaviour
{
    public GameObject LepakkoPrefab;
    private GameObject LepakkoSpawn;
   
    public Lepakko_chase Lepakko;
    private bool HasSpawned = false;
  
    void Start() 
    {
        LepakkoSpawn = GameObject.FindGameObjectWithTag("Lepakko_Spawn");
    }
   

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!HasSpawned && other.CompareTag("Player"))
        {   
            HasSpawned = true;
            var spawnedObj = Instantiate(LepakkoPrefab, LepakkoSpawn.transform.position, Quaternion.identity);
            

            if (spawnedObj.TryGetComponent(out Lepakko_chase batScript))
            {
                Lepakko = batScript;
                Lepakko.StartChasing(other.transform);
            }
            
        }
    }
}