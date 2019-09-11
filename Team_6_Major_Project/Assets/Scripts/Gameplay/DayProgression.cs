using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DayProgression : MonoBehaviour
{
    public enum SpawnState { Spawning, waiting, counting }

    [System.Serializable]
    public class Day
    {
        public string name;
        public GameObject[] genericNpc;
        public GameObject[] specialNpc;
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

    public SpawnState state = SpawnState.counting;

    private void Start()
    {
        dayCountDown = timeBetweenDays;
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
        Debug.Log("Wave Completed");

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
            newDay.specialNpc = week[0].specialNpc;
            week.Add(newDay);
            dayText.text = "Day " + (nextDay + 1).ToString();
            Debug.Log("New day added");
        }
        else
        {
            nextDay++;
            dayText.text = "Day " + nextDay.ToString();

        }
    }

    bool NpcIsInScene()
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
        Debug.Log("Spawning Wave: " + _day.name);
        state = SpawnState.Spawning;
        for(int i = 0; i < _day.count; i++)
        {
            _day.slotspecial = _day.count - 1;

            if (i == _day.slotspecial)
            {
                SpawnNpc(_day.specialNpc[0]);
            }
            else
            {
                SpawnNpc(_day.genericNpc[0]);
            }
            yield return new WaitForSeconds(1f / _day.rate);
        }

        state = SpawnState.waiting;

        yield break;
    }

    void SpawnNpc (GameObject _npc)
    {
        Instantiate(_npc, spawn.position, Quaternion.identity);
        Debug.Log("Spawning Enemy " + _npc.name);
    }
}
