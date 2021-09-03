using System.Collections;
using System.Collections.Generic;
using System.Linq;

using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class HexGridManager : MonoBehaviour
{

    public HexCell hexCellSource;
    public int rowCount = 8;
    public int columnCount = 12;
    
    private List<HexCell> cells = new List<HexCell>();
    private Vector3 LeftBottomPoint =  new Vector3(-18,0,-8);
    private Vector3 LeftBottomPoint2 =  new Vector3(-16.5f,0,-7);

    private void CreateHexCell(Vector3 position) {
        var cell = Instantiate(hexCellSource, position, Quaternion.identity);
        // cell.gameObject.hideFlags = HideFlags.HideInHierarchy;
        cells.Add(cell);
    }

    public void Build() {
        Clear();
        if (hexCellSource == null) {
            Debug.LogError("C'mon you forget to provide the hex cell source");
        } else {
            for (int j = 0; j <= rowCount; j++) {
                for (int i = 0; i <= columnCount; i++) {
                    Vector3 position = LeftBottomPoint + new Vector3(3*i,0,2*j);
                    CreateHexCell(position);
                    if( i < columnCount && j < rowCount) {
                        Vector3 position2 = LeftBottomPoint2 + new Vector3(3*i,0,2*j);
                        CreateHexCell(position2);
                    }
                }
            }
        }
    }

    public void PopulateCellsFromScene() {
        cells = FindObjectsOfType<HexCell>().ToList();
    }

    public void Clear() {
        PopulateCellsFromScene();
        foreach (var item in this.cells) {
            DestroyImmediate(item.gameObject);
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