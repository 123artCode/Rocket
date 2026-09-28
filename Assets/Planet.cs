using System;
using UnityEngine;

public class Planet : MonoBehaviour
{
        [SerializeField]
        public Transform Planets;
        public double density = 5;


        [HideInInspector]
        public double mass = 5;
        [HideInInspector]
        public double gravity = 6.6743015 / 10000000;
        [HideInInspector]
        public double volume;
        [HideInInspector]
        public Vector3 forces;
        [HideInInspector]
        public Vector3 g;
        [HideInInspector]
        public Vector3 accelaration;
        [HideInInspector]
        public Vector3 g_vector;
        public Vector3 velocity;
        public float max_velocity = 1;




    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gravity = 6.6743015 / 10000000;
        
    }





    Vector3 movement()
    {
        forces = new Vector3(0, 0, 0);
        g = new Vector3(0, 0, 0);


        volume = 0.1666666667 * transform.localScale.x * transform.localScale.y * transform.localScale.z * Math.PI;
        mass = density * volume;

        foreach (Transform child in Planets) {
            if (child.gameObject != this.gameObject){

                double distance = Vector3.Distance(child.position, transform.position);      
                double g_value = gravity * mass * child.GetComponent<Planet>().mass / distance / distance;


                Vector3 targetDir = child.position - transform.position;

                g_vector = targetDir * (float) (g_value / targetDir.magnitude);
                if (g_vector == (float) g_value * targetDir.normalized)
                {
                    print("ups");
                }
                if (child.gameObject.bounds.min < transform.bounds.min)
                {
                    if (child.gameObject.bounds.max)
                } 
                g += g_vector;
    
            }
        }
        forces = g;

        accelaration = forces/(float)mass;
        velocity += accelaration * Time.deltaTime;
        velocity = Vector3.ClampMagnitude(velocity, max_velocity);
        return velocity;
    }



    // Update is called once per frame
    void Update()
    {

        transform.position = transform.position + movement();
    }

}
