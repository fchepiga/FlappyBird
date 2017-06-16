
using UnityEngine;

public class BGLooper : MonoBehaviour
{
    int BGPanel = 6;
    float pipeMIN = 0.753f;
    float pipeMAX = 1.615f;
    private void Start()
    {
        GameObject[] pipes = GameObject.FindGameObjectsWithTag("Pipe");

        foreach(GameObject pipe in pipes)
        {
            Vector3 pos = pipe.transform.position;
           
                pos.y = Random.Range(pipeMIN, pipeMAX);
            

            pipe.transform.position = pos;

        }

    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("Trigger" + collider.name);
        float widthBGObject = ((BoxCollider2D)collider).size.x;
        Vector3 pos = collider.transform.position;
        pos.x += widthBGObject * BGPanel-widthBGObject/2f;

        if(collider.tag=="Pipe")
        {
            pos.y = Random.Range(pipeMIN, pipeMAX);
        }

        collider.transform.position = pos;



    }

}

