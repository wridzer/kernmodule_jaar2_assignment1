using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private GameObject playerInstance;
    private List<GameObject> enemies = new List<GameObject>();
    Vector3 playerPos;

    // Start is called before the first frame update
    void Start()
    {

        for (int i = 0; i < 10; ++i)
        {
            GameObject enemy = GameObject.Instantiate(enemyPrefab);
            enemy.transform.position = new Vector3(Random.Range(-100, 100), 0, Random.Range(-100, 100));
            enemies.Add(enemy);
        }
    }

    // Update is called once per frame
    void Update()
    {
        EnimMove();
    }

    private void EnimMove()
    {
        // Update enemies
        for (int i = 0; i < enemies.Count; ++i)
        {
            Vector3 dir = (playerInstance.transform.position - enemies[i].transform.position).normalized;
            enemies[i].GetComponent<Movement>().Move(dir);
        }
    }
}
