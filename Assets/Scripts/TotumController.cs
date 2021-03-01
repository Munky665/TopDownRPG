using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TotumController : IController
{
    List<Vector3> positions = new List<Vector3>();
    float moveTime = 30;
    float timeHolder = 30;
    int position = 0;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.instance.totum = this.gameObject;
        positions.Add(transform.position);
        positions.Add(new Vector3(25, transform.position.y, 55));
    }

    // Update is called once per frame
    void Update()
    {
        moveTime -= 1 * Time.deltaTime;

        if(moveTime < 1)
        {
            position++;

            switch(position)
            {
                case 1:
                    transform.position = positions[position];
                    break;
                case 2:
                    position = 0;
                    transform.position = positions[position];
                    break;
            }

            moveTime = timeHolder;
        }
    }
}
