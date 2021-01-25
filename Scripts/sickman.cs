using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sickman : MonoBehaviour
{
    public ParticleSystem cough;
    public GameObject mouth;
    public GameObject mucus;

    private void Awake()
    {
        cough.Stop();

    }

    void Cough()
    {
        //cough.Play();
        for (int i = 0; i <= 50; i++)
        {
            Instantiate(mucus, mouth.transform);
        }
    }
}