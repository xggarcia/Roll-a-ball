using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Position : MonoBehaviour
{   
    private Vector3 position;
    private float  extra_position_x;
    private float extra_position_y;
    public int limiter_x; 
    public int limiter_y;
    private float new_position_x;
    private float new_position_y;

    public int cube_velocity;


    // Start is called before the first frame update
    void Start()
    {
        position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        extra_position_x = Random.value;
        extra_position_y = Random.value;

        new_position_x = transform.position.x + extra_position_x * Time.deltaTime * cube_velocity*limiter_x;
        new_position_y = transform.position.z + position.y * Time.deltaTime * cube_velocity*limiter_y;
        
        if (new_position_x > 9){

            limiter_x = limiter_x * (-1);
            new_position_x = transform.position.x + extra_position_x * Time.deltaTime * cube_velocity * limiter_x;
        }

        if (new_position_x < -9)
        {

            limiter_x = limiter_x * (-1);
            new_position_x = transform.position.x + extra_position_x * Time.deltaTime * cube_velocity * limiter_x;
        }

        if (new_position_y > 9){

            limiter_y = limiter_y * (-1);
            new_position_y = transform.position.z + position.y * Time.deltaTime * cube_velocity * limiter_y;
        }

        if (new_position_y < -9)
        {

            limiter_y = limiter_y * (-1);
            new_position_y = transform.position.z + position.y * Time.deltaTime * cube_velocity * limiter_y;
        }

        position = new Vector3 (new_position_x, transform.position.y, new_position_y);
        transform.position = position;
    }
}
