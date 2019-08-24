using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillSelf : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("DelayKill");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator DelayKill()
    {
        yield return new WaitForSeconds(2.5f);
        this.GetComponent<ParticleSystem>().Stop();
        yield return new WaitForSeconds(5);
        Destroy(this.gameObject);

    }
}
