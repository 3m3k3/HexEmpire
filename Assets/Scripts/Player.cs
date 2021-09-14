using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    
    public HexGridManager hexGridManager;
    public void move(int id) {
        var cells = hexGridManager.cells;
        var destination = cells[id];
        //mapCells[[]]$


    }

    void Update() {
        /**
        var cells = hexGridManager.cells;
        var destination = cells[id];
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, destination.transform.position, step);
        **/
    }
    
}
