using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DayProgression : MonoBehaviour
{
    public enum SpawnState { Spawning, waiting, counting }

    public SaveLoadMenuTest save;

    [System.Serializable]
    public class Day
    {
        public string name;
        public GameObject[] genericNpc;
        public int slotspecial;
        public int count;
        public float rate;
    }

    public List<Day> week;
    public int nextDay = 0;
    public int randomNpc;

    public Transform spawn;

    public float timeBetweenDays = 5f;
    public float dayCountDown;

    public float searchCountDown = 1f;

    public Text dayText;
    public Tutorial tut;

    public SpawnState state = SpawnState.counting;
    public WaypointManager waypointManager;

    private void Start()
    {
        //Sets dayCountDown to timeBetweenDays
        dayCountDown = timeBetweenDays;
        //Sets the tutorial
        tut = GameObject.FindObjectOfType<Tutorial>().GetComponent<Tutorial>();
        //Sets the save
        save = GameObject.FindObjectOfType<SaveLoadMenuTest>().GetComponent<SaveLoadMenuTest>();
        //Sets the waypointManager
        waypointManager = GameObject.FindObjectOfType<WaypointManager>().GetComponent<WaypointManager>();

    }

    private void Update()
    {
        //Checks if the state is equal to waiting
        if(state == SpawnState.waiting)
        {
            //Check if the bool function NpcIsInScene is equal to false
            if (NpcIsInScene() == false)
            {
                //Runs the DayCompleted function
                DayCompleted();
            }
            else
            {
                return;
            }
        }
        //Checks if dayCountDown is less than or equal to 0
        if(dayCountDown <= 0)
        {
            //Sets the randomNpc bygetting a range between 1 and 4
            randomNpc = Random.Range(1, 4);
            //Check if the state is not equal to spawning
            if (state != SpawnState.Spawning)
            {
                //Starts the coroutine for spawnDay
                StartCoroutine(SpawnDay(week[nextDay]));
            }
        }
        else
        {
            //Decreases dayCountdown by delta time
            dayCountDown -= Time.deltaTime;
        }
    }

    //Completes the day and adds a new day to the List
    void DayCompleted()
    {
        //Sets the state to counting
        state = SpawnState.counting;
        
        dayCountDown = timeBetweenDays;

        if (nextDay + 1 > week.Count - 1)
        {
            Day newDay = new Day();
            nextDay++;
            newDay.name = "Day " + (nextDay + 1).ToString();
            newDay.count = week[0].count;
            newDay.rate = week[0].rate;
            newDay.genericNpc = week[0].genericNpc;
            week.Add(newDay);
            save.Save();

        }
        else
        {
            nextDay++;
            save.Save();
        }
    }

    //Checks if there are NPCs still in scene
    public bool NpcIsInScene()
    {
        searchCountDown -= Time.deltaTime;
        if (searchCountDown <= 0f)
        {
            searchCountDown = 1f;
            if (GameObject.FindGameObjectWithTag("NPC") == null)
            {
                return false;
            }
        }
        return true;
    }

    //IEnumerator which spawn Days and adds NPCS to the scene
    IEnumerator SpawnDay(Day _day)
    {
        dayText.text = "Day " + (nextDay + 1).ToString();
        state = SpawnState.Spawning;
        bool spawnedtut = false;
        for(int i = 0; i < _day.count; i++)
        {
            _day.slotspecial = _day.count - 1;

          
                if(tut.isTutorialing == true)
                {
                    if (spawnedtut == false)
                    {
                        SpawnNpc(_day.genericNpc[0]);
                        spawnedtut = true;
                        waypointManager.AddNpcs();
                    }
                    else
                    {
                        SpawnNpc(_day.genericNpc[randomNpc]);
                        waypointManager.AddNpcs();
                    }

                }
                else
                {
                    SpawnNpc(_day.genericNpc[randomNpc]);
                    waypointManager.AddNpcs();          
                }
            yield return new WaitForSeconds(1f / _day.rate);
        }

        state = SpawnState.waiting;

        yield break;
    }

    //Spawns NPCS with restrictions on their order to show progression in the game
    void SpawnNpc (GameObject _npc)
    {
        GameObject Npc = Instantiate(_npc, spawn.position, Quaternion.identity);
        if(nextDay <= 5)
        {
            Npc.GetComponent<TestDialogueTrigger>().materialGen = 1;
        }
        else if(nextDay > 5 && nextDay <= 10)
        {
            Npc.GetComponent<TestDialogueTrigger>().materialGen = 2;
        }
        else if (nextDay > 10)
        {
            Npc.GetComponent<TestDialogueTrigger>().materialGen = 3;
        }
    }
}
