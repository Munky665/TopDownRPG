using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Vector3 playerPosition;
    private GameManager gM;

    float offset = 5;

    // Start is called before the first frame update
    void Start()
    {
        gM = GameManager.instance;
    }

    // Update is called once per frame
    void Update()
    {
        if (gM.player != null)
        {
            playerPosition = gM.player.transform.position;
        }
        if(playerPosition.x > transform.position.x + offset || playerPosition.z > transform.position.z + offset
            || playerPosition.x < transform.position.x + offset || playerPosition.z < transform.position.z + offset)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(playerPosition.x + offset, transform.position.y, playerPosition.z), 1 * Time.deltaTime);
        }
    }
}
