using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class HexGridManager : MonoBehaviour
{

    public GameObject hexCellSource;
    public int rowCount = 8;
    public int columnCount = 12;
    private ArrayList cells = new ArrayList();
    private Vector3 LeftBottomPoint =  new Vector3(-18,0,-8);
    private Vector3 LeftBottomPoint2 =  new Vector3(-16.5f,0,-7);


    public void Build() {
        
        if (hexCellSource == null) {
            Debug.LogError("Cmon you forget to provide the hex cell source");
        } else {
            for (int j = 0; j <= rowCount; j++) {
                for (int i = 0; i <= columnCount; i++) {
                    Vector3 position = LeftBottomPoint + new Vector3(3*i,0,2*j);
                    this.cells.Add(Instantiate(hexCellSource, position, Quaternion.identity));
                    if( i < columnCount && j < rowCount) {
                    Vector3 position2 = LeftBottomPoint2 + new Vector3(3*i,0,2*j);
                    this.cells.Add(Instantiate(hexCellSource, position2, Quaternion.identity));
                    }
                }
            }
        }
    }

    public void Clear() {
        foreach (GameObject item in this.cells)
        {
            DestroyImmediate(item);
        }
        this.cells.Clear();
    }

    public void CountCells() {
        Debug.LogError(this.cells.Count);
    }


#if UNITY_EDITOR
    [CustomEditor(typeof(HexGridManager))]
    class MyEditor : Editor {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            if (GUILayout.Button("Build")) {
                (target as HexGridManager).Build();
            }
            if (GUILayout.Button("Clear")) {
                (target as HexGridManager).Clear();
            }
            if (GUILayout.Button("CountCells")) {
                (target as HexGridManager).CountCells();
            }
        }
    }
#endif
}