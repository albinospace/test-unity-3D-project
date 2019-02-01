using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCube : MonoBehaviour {
    [SerializeField] private GameObject enemyPrefab;
    private GameObject _enemy;

    List<GameObject> enemies;
    int enemyAmount = 10;

    public void Start () {
         enemies = new List<GameObject>();
            for (int i = 0; i < enemyAmount; i++)
            {
            _enemy = (GameObject)Instantiate(enemyPrefab);
            _enemy.SetActive(false);
                enemies.Add(_enemy);
            }
    }
	
	public void Update () {
        Spawn();
    }

    public void Spawn()
    {
       Wandering behavior = GetComponent<Wandering>();
       

        for (int i = 0; i < enemies.Count; i++)
        {
            if (!enemies[i].activeInHierarchy) //disabled/in the pool
            {
                enemies[i].transform.position = new Vector3(Random.Range(-5, 5), (float)0.5, Random.Range(-5, 5));
                float angle = Random.Range(0, 360);
                enemies[i].transform.Rotate(0, angle, 0);
                enemies[i].SetActive(true);
            }
        }
    }

}

