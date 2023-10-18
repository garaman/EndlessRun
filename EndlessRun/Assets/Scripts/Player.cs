using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum RoadLine
{
    LEFT = -1,
    MIDDLE = 0,
    RIGHT = 1
}

public class Player : MonoBehaviour
{    
    [SerializeField] float positionX = 4f;
    [SerializeField] RoadLine roadLine;

    [SerializeField] ObjectSound objectSound = new ObjectSound();

    public float PositionX { get; private set; }
    void Start()
    {
        roadLine = RoadLine.MIDDLE;
    }

    
    void Update()
    {
        Move();
        Status(roadLine);
    }

    public void Move()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            AudioManager.instance.Sound(objectSound.clips[0]);
            if(roadLine == RoadLine.LEFT)
            {
                roadLine = RoadLine.LEFT;
            }
            else { roadLine--; }
            
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            AudioManager.instance.Sound(objectSound.clips[0]);
            if (roadLine == RoadLine.RIGHT)
            {
                roadLine = RoadLine.RIGHT;
            }
            else { roadLine++; }
        }
    }

    public void Status(RoadLine roadLine)
    {
        switch (roadLine)
        {
            case RoadLine.LEFT:
                transform.position = new Vector3(-positionX, 0, 0);
                break;
            case RoadLine.MIDDLE:
                transform.position = new Vector3(0, 0, 0);
                break;
            case RoadLine.RIGHT:
                transform.position = new Vector3(positionX, 0, 0);                
                break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        IItem item = other.GetComponent<IItem>();

        if(item != null)
        {
            item.Use();
        }
    }

}
