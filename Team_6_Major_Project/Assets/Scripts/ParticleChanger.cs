using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleChanger : MonoBehaviour
{
    public ParticleSystem particle;

    public Color color1;
    public Color color2;

    public Color green;
    public Color blue;
    public Color red;


    // Start is called before the first frame update
    void Start()
    {
        particle = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        ParticleSystem.ColorOverLifetimeModule colour = particle.colorOverLifetime;
        colour.enabled = true;

        Gradient grad = new Gradient();
        color1 = blue;
        color2 = (color1 + new Color(color1.r , color1.g + 0.87f,color1.b))/2;
        grad.SetKeys(new GradientColorKey[] { new GradientColorKey(color1, 0.0f), new GradientColorKey(color2, 1.0f) }, new GradientAlphaKey[] { new GradientAlphaKey(1.0f, 0.0f), new GradientAlphaKey(0.0f, 1.0f) });
        colour.color = grad;


    }

}
