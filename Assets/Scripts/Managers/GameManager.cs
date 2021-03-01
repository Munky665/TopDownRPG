using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject player;
    public GameObject totum;
    public GameObject inventory;
    public GameObject EnemyObject;
    public Text waveCountText;
    public int wave = 0;
    public int enemiesToSpawn;
    public int modifier = 3;
    bool canSpawn = true;
    bool waveStarted = false;
    public List<GameObject> enemies;
    int timesRun = 0;
    int maxEnemies;
    
    // Start is called before the first frame update
    void Start()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }

        enemies = new List<GameObject>();
    }

    internal void AddExp(float expWorth)
    {
        player.GetComponent<PlayerStats>().AddExp(expWorth);
    }


    // Update is called once per frame
    void Update()
    { 

        if (waveStarted == false)
        {
            StartCoroutine(WaveDelay());
        }
        if (waveStarted)
        {
            CheckAndSpawnEnemies();
        }
    }

    void CheckAndSpawnEnemies()
    {
        if(enemiesToSpawn >= 1 && canSpawn)
        {
            StartCoroutine(EnemySpawner());
        }
        
    }

    void StartWave()
    {
        wave++;
        waveCountText.text = ": " + wave.ToString();
        enemiesToSpawn = wave * modifier;
        maxEnemies = enemiesToSpawn;
        timesRun = 0;
    }

    void SpawnEnemy(GameObject e)
    {
        float x, z;
        if(enemiesToSpawn % 2 == 0 )
        {
            RandomNorth(out x, out z);
        }
        else
        {
            RandomSouth(out x, out z);
        }
        var t = Instantiate(e, new Vector3(x, 0, z), Quaternion.identity);
        enemies.Add(t);
    }

    void RandomNorth(out float x, out float z)
    {
        x = Random.Range(-30, -10);
        z = Random.Range(50, 70);
    }

    void RandomSouth(out float x, out float z)
    {
        x = Random.Range(15, 35);
        z = Random.Range(5, 25);
    }

    IEnumerator EnemySpawner()
    {
        if (timesRun < maxEnemies)
        {
            timesRun++;
            yield return new WaitForSeconds(1);
            enemiesToSpawn--;
            SpawnEnemy(EnemyObject);
        }
    }

    IEnumerator WaveDelay()
    {
        waveStarted = true;
        yield return new WaitForSeconds(5);
        StartWave();
    }

    public void RemoveDeadEnemy(GameObject e)
    {
        enemies.Remove(e);
        if(enemies.Count == 0)
        {
            waveStarted = false;
        }
    }

    public void ItemUsedOnPlayer(Potion potion)
    {
        if (potion.healthOrMana == 0)
        {
            player.GetComponent<Stats>().Heal(potion.amountToRecover);
        }
        else
        {
            player.GetComponent<Stats>().RegenMana(potion.amountToRecover);
        }
    }
}
