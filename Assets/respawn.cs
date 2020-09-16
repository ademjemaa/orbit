using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class respawn : MonoBehaviour {
    public GameObject asteroidPrefab;
    public GameObject outersphere;
    public float respawnTime = 10.0f;
    private Vector2 screenBounds;

    // Use this for initialization
    void Start () {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        StartCoroutine(asteroidWave());
    }
    private void spawnEnemy(){
        GameObject a = Instantiate(asteroidPrefab) as GameObject;
        GameObject b = Instantiate(outersphere) as GameObject;
        a.transform.position = new Vector2(screenBounds.x * -1, Random.Range(-screenBounds.y - 2, screenBounds.y + 2));
        b.transform.position = a.transform.position;
    }
    IEnumerator asteroidWave(){
        while(true){
            yield return new WaitForSeconds(1);
            spawnEnemy();
        }
    }
}