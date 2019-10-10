using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ConsoleWindow : MonoBehaviour
{
    public List<GameObject> listeners = new List<GameObject>();

    public GameObject smallSword;
    public GameObject mediumSword;
    public GameObject largeSword;

    public string[] parameters;
    public string handle;
    public string guard;
    public int qualityPar;
    public bool on;

    public GameObject player;
    public GameObject inputfield;

    // Start is called before the first frame update
    void Start()
    {
        AddListener(gameObject);
    }

    public void AddListener(GameObject listener)
    {
        if(!listeners.Contains(listener))
        {
            listeners.Add(listener);
        }
    }

    public void Command(string input)
    {
        string[] parts = input.Split(new char[] { '.', '(', ')' }, 4);
        parameters = input.Split(new char[] { '.', '(', ',', ')' }, 7);
        GameObject go = listeners.Where(obj => obj.name == parts[0]).SingleOrDefault();
        if(go != null)
        {
            go.SendMessage(parts[1], parts[2]);
            
        }
    }

    public void CreateSmallSword(string blade)
    {
        if (parameters[2] != null)
        {
            blade = parameters[2];
        }
        else
        {
            blade = "bronze";
        }

        if (parameters[3] != null)
        {
            handle = parameters[3];
        }
        else
        {
            handle = "bronze";
        }

        if(parameters[4] != null)
        {
            guard = parameters[4];
        }
        else
        {
            guard = "bronze";
        }

        if (parameters[5] != null)
        {
            qualityPar = int.Parse(parameters[5]);
        }
        else
        {
            qualityPar = 50;
        }

        GameObject go = Instantiate(smallSword, player.transform.position, Quaternion.identity);

        if (blade == "bronze")
        {
            go.GetComponent<Sword>().materialBlade = Sword.MaterialBlade.bronze;
        }
        else if (blade == "iron")
        {
            go.GetComponent<Sword>().materialBlade = Sword.MaterialBlade.iron;
        }
        else if (blade == "steel")
        {
            go.GetComponent<Sword>().materialBlade = Sword.MaterialBlade.steel;
        }

        if (handle == "bronze")
        {
            go.GetComponent<Sword>().materialHandle = Sword.MaterialHandle.bronze;
        }
        else if (handle == "iron")
        {
            go.GetComponent<Sword>().materialHandle = Sword.MaterialHandle.iron;
        }
        else if (handle == "steel")
        {
            go.GetComponent<Sword>().materialHandle = Sword.MaterialHandle.steel;
        }

        if (guard == "bronze")
        {
            go.GetComponent<Sword>().materialGuard = Sword.MaterialGuard.bronze;
        }
        else if (guard == "iron")
        {
            go.GetComponent<Sword>().materialGuard = Sword.MaterialGuard.iron;
        }
        else if (guard == "steel")
        {
            go.GetComponent<Sword>().materialGuard = Sword.MaterialGuard.steel;
        }

        go.GetComponent<Sword>().quality = qualityPar;
    }

    public void CreateMediumSword(string blade)
    {
        if (parameters[2] != null)
        {
            blade = parameters[2];
        }
        else
        {
            blade = "bronze";
        }

        if (parameters[3] != null)
        {
            handle = parameters[3];
        }
        else
        {
            handle = "bronze";
        }

        if (parameters[4] != null)
        {
            guard = parameters[4];
        }
        else
        {
            guard = "bronze";
        }

        if (parameters[5] != null)
        {
            qualityPar = int.Parse(parameters[5]);
        }
        else
        {
            qualityPar = 50;
        }

        GameObject go = Instantiate(mediumSword, player.transform.position, Quaternion.identity);

        if (blade == "bronze")
        {
            go.GetComponent<Sword>().materialBlade = Sword.MaterialBlade.bronze;
        }
        else if (blade == "iron")
        {
            go.GetComponent<Sword>().materialBlade = Sword.MaterialBlade.iron;
        }
        else if (blade == "steel")
        {
            go.GetComponent<Sword>().materialBlade = Sword.MaterialBlade.steel;
        }

        if (handle == "bronze")
        {
            go.GetComponent<Sword>().materialHandle = Sword.MaterialHandle.bronze;
        }
        else if (handle == "iron")
        {
            go.GetComponent<Sword>().materialHandle = Sword.MaterialHandle.iron;
        }
        else if (handle == "steel")
        {
            go.GetComponent<Sword>().materialHandle = Sword.MaterialHandle.steel;
        }

        if (guard == "bronze")
        {
            go.GetComponent<Sword>().materialGuard = Sword.MaterialGuard.bronze;
        }
        else if (guard == "iron")
        {
            go.GetComponent<Sword>().materialGuard = Sword.MaterialGuard.iron;
        }
        else if (guard == "steel")
        {
            go.GetComponent<Sword>().materialGuard = Sword.MaterialGuard.steel;
        }

        go.GetComponent<Sword>().quality = qualityPar;

    }

    public void CreateLargeSword(string blade)
    {
        if (parameters[2] != null)
        {
            blade = parameters[2];
        }
        else
        {
            blade = "bronze";
        }

        if (parameters[3] != null)
        {
            handle = parameters[3];
        }
        else
        {
            handle = "bronze";
        }

        if (parameters[4] != null)
        {
            guard = parameters[4];
        }
        else
        {
            guard = "bronze";
        }

        if (parameters[5] != null)
        {
            qualityPar = int.Parse(parameters[5]);
        }
        else
        {
            qualityPar = 50;
        }

        GameObject go = Instantiate(largeSword, player.transform.position, Quaternion.identity);

        if (blade == "bronze")
        {
            go.GetComponent<Sword>().materialBlade = Sword.MaterialBlade.bronze;
        }
        else if (blade == "iron")
        {
            go.GetComponent<Sword>().materialBlade = Sword.MaterialBlade.iron;
        }
        else if (blade == "steel")
        {
            go.GetComponent<Sword>().materialBlade = Sword.MaterialBlade.steel;
        }

        if (handle == "bronze")
        {
            go.GetComponent<Sword>().materialHandle = Sword.MaterialHandle.bronze;
        }
        else if (handle == "iron")
        {
            go.GetComponent<Sword>().materialHandle = Sword.MaterialHandle.iron;
        }
        else if (handle == "steel")
        {
            go.GetComponent<Sword>().materialHandle = Sword.MaterialHandle.steel;
        }

        if (guard == "bronze")
        {
            go.GetComponent<Sword>().materialGuard = Sword.MaterialGuard.bronze;
        }
        else if (guard == "iron")
        {
            go.GetComponent<Sword>().materialGuard = Sword.MaterialGuard.iron;
        }
        else if (guard == "steel")
        {
            go.GetComponent<Sword>().materialGuard = Sword.MaterialGuard.steel;
        }

        go.GetComponent<Sword>().quality = qualityPar;

    }

    // Update is called once per frame
    void Update()
    {
        #if (UNITY_EDITOR)
        if(Input.GetKeyDown(KeyCode.BackQuote) && on == false)
        {
            player.GetComponent<PlayerController>().enabled = false;
            inputfield.SetActive(true);
            on = true;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;

        }
        else if (Input.GetKeyDown(KeyCode.BackQuote) && on == true)
        {
            player.GetComponent<PlayerController>().enabled = true;
            inputfield.SetActive(false);
            on = false;
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
        #endif      
    }
}
