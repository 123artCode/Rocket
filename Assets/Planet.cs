using System;
using UnityEngine;

public class main : MonoBehaviour
{
        public Transform Planets;


        [SerializeField]
        public double density = 5;
       



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {            
        double gravity = 6.6743015 / 10000000;
        double volume = 4/3 * 1/2 * transform.localScale.x * 1/2 * transform.localScale.y * 1/2 * transform.localScale.z * Math.PI;
        double mass = density * volume;

        double[] forces;
        double g;
        
        
        foreach (Transform child in Planets) {
            if (other.gameObject != this.gameObject):
                g += gravity * mass * 
        }
        

        
        forces = forces.Append(g).ToArray();


    }





    Vector3 movement()
    {
        return new Vector3(0, 0, 0);
    }



    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + movement() * Time.deltaTime ;
    }

}
