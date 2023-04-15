using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Spawner : MonoBehaviour
{
    public Transform SpawnPos;
    [SerializeField] GameObject Food;
    [SerializeField] GameObject Block;
    private void Start()
    {
        StartCoroutine(SpawnOfFood());
        StartCoroutine(SpawnBlock());
    }
    IEnumerator SpawnOfFood()
    {
        yield return new WaitForSeconds(3.3f);
        Vector3 pos = SpawnPos.position + new Vector3(Random.Range(-2, 2), 0,40);
        Instantiate(Food, pos,Quaternion.identity);
        Repeat();
    }
    
    IEnumerator SpawnBlock()
    {
        yield return new WaitForSeconds(5.5f);
        Vector3 pos = SpawnPos.position + new Vector3(-3, 0, 40);
        Vector3 pos1 = SpawnPos.position + new Vector3(0, 0, 40);
        Vector3 pos2 = SpawnPos.position + new Vector3(3, 0, 40);
        Instantiate(Block, pos, Quaternion.identity);
        Instantiate(Block, pos1, Quaternion.identity);
        Instantiate(Block, pos2, Quaternion.identity);
        RepeatBlock();


    }
    void Repeat()
    {
        StartCoroutine(SpawnOfFood());
        
    }
    void RepeatBlock()
    {
        StartCoroutine(SpawnBlock());
    }
}
