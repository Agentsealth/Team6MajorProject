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

    public Transform spawn;

    public float timeBetweenDays = 5f;
    public float dayCountDown;

    public float searchCountDown = 1f;

    public Text dayText;
    public Tutorial tut;

    public SpawnState state = SpawnState.counting;

    private void Start()
    {
        dayCountDown = timeBetweenDays;
        tut = GameObject.FindObjectOfType<Tutorial>().GetComponent<Tutorial>();
        save = GameObject.FindObjectOfType<SaveLoadMenuTest>().GetComponent<SaveLoadMenuTest>();

    }

    private void Update()
    {
        if(state == SpawnState.waiting)
        {
            if (NpcIsInScene() == false)
            {
                DayCompleted();
            }
            else
            {
                return;
            }
        }

        if(dayCountDown <= 0)
        {
            if(state != SpawnState.Spawning)
            {
                StartCoroutine(SpawnDay(week[nextDay]));
            }
        }
        else
        {
            dayCountDown -= Time.deltaTime;
        }
    }

    void DayCompleted()
    {

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
                    }
                    else
                    {
                        SpawnNpc(_day.genericNpc[1]);
                    }

                }
                else
                {
                    SpawnNpc(_day.genericNpc[1]);

                }
            yield return new WaitForSeconds(1f / _day.rate);
        }

        state = SpawnState.waiting;

        yield break;
    }

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
