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
        public double gravity;
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



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {            
        gravity = 6.6743015 / 10000000;
        volume = 0.1666666667 * transform.localScale.x * transform.localScale.y * transform.localScale.z * Math.PI;
        mass = density * volume;

        forces = new Vector3(0, 0, 0);
        g = new Vector3(0, 0, 0);
        
    }





    Vector3 movement()
    {
        forces = new Vector3(0, 0, 0);
        g = new Vector3(0, 0, 0);

        foreach (Transform child in Planets) {
            if (child.gameObject != this.gameObject){

                double distance = Vector3.Distance(child.position, transform.position);      
                double g_value = gravity * mass * child.GetComponent<Planet>().mass / distance / distance;
                Debug.Log(gravity);
                Debug.Log(mass);
                Debug.Log(child.GetComponent<Planet>().mass);
                Debug.Log(distance);


                Vector3 targetDir = child.position - transform.position;
                float angle = Vector3.Angle(targetDir, Vector3.forward);

                Quaternion rotation = Quaternion.Euler(0, angle, 0);


                g_vector = targetDir * (float) (g_value / targetDir.magnitude);
                if (g_vector == (float) g_value * targetDir.normalized)
                {
                    print("ups");
                }

                g += g_vector;
    
            }
        }
        forces = g;

        accelaration = forces/(float)mass;

        return accelaration;

    }



    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + movement() * Time.deltaTime ;
    }

}
