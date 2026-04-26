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
        foreach (Transform child in Planets) {
            if (child == this.gameObject){
            }else
            {

                Debug.Log(child);
                Debug.Log(this.gameObject);

                double distance = Vector3.Distance(child.position, transform.position);      
                double g_value = gravity * mass * child.GetComponent<Planet>().mass / distance / distance;

                Vector3 targetDir = child.position - transform.position;
                float angle = Vector3.Angle(targetDir, transform.forward);

                Quaternion rotation = Quaternion.Euler(0, angle, 0);

                g = rotation * Vector3.forward * (float)g_value;
    
            }
        }
        forces = g;
        Debug.Log(g);


        accelaration.x = forces.x/(float)mass;
        accelaration.y = forces.y/(float)mass;
        accelaration.z = forces.z/(float)mass;


        forces = new Vector3(0, 0, 0);


        return accelaration;

    }



    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + movement() * Time.deltaTime ;
    }

}
