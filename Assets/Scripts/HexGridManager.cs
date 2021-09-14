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
    public int rowCount = 11;
    public int columnCount = 20;

    private int countCell = 0;
    
    public List<HexCell> cells = new List<HexCell>();
    private List<int> mapGrid = new List<int>();
    public Dictionary<int, List<HexCell>> mapCells = new Dictionary<int, List<HexCell>>();
    private Vector3 firstCell = new Vector3(0,0,-2);

    private void CreateHexCell(Vector3 position, int row) {
        //Debug.LogError(position);
        var cell = Instantiate(hexCellSource, position, Quaternion.identity);
        cell.init(mapGrid.ElementAt(countCell++), countCell);
        // cell.gameObject.hideFlags = HideFlags.HideInHierarchy;
        cells.Add(cell);
        if(!mapCells.ContainsKey(row)) {
            mapCells[row] = new List<HexCell>();
        }
        mapCells[row].Add(cell);
     
    }

    public void Build() {
        Clear();
        var sNumbers = "4,4,4,4,4,3,3,3,3,3,3,4,4,2,3,3,3,2,4,1,4,0,4,1,4,4,2,3,3,3,4,4,4,4,4,4,4,4,0,4,4,4,2,4,2,1,4,3,4,2,1,4,4,4,4,1,4,4,4,4,1,4,2,3,2,4,4,4,4,4,4,4,4,4,3,2,3,3,3,3,4,4,3,3,2,1,4,4,4,4,4,4,1,2,4,3,4,4,4,4,1,4,2,3,2,4,4,1,4,4,4,4,4,4,4,3,4,1,4,4,4,4,4,3,4,1,4,4,4,1,4,4,4,2,3,4,1,4,3,4,4,4,4,3,3,4,4,4,4,4,4,4,4,3,3,2,4,4,4,3,4,4,4,4,4,4,4,3,3,4,4,1,4,2,3,3,3,4,4,4,4,0,4,4,4,4,4,3,4,4,4,4,4,4,4,3,3,2,0,4,1,4,4,3,3,4,4,4,4,4,4,4,1,4,2,3,3,4,4,4";
        this.mapGrid = sNumbers.Split(',').Select(int.Parse).ToList();
        if (hexCellSource == null) {
            Debug.LogError("C'mon you forget to provide the hex cell source");
        } else { 
            Vector3 tmp = new Vector3(0,0,0);
            for (int j = 0; j < rowCount; j++) {
                tmp = new Vector3(0,0,0);
                firstCell = new Vector3(0,0,j*2);  
                for (int i = 0; i < columnCount; i++) {
                    firstCell = firstCell + tmp;
                    CreateHexCell(firstCell,j);
                    if(isPaire(i)) {
                        tmp = new Vector3(1.5f,0,-1);
                    } else {
                        tmp = new Vector3(1.5f,0,1);
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
        this.mapGrid.Clear();
        countCell = 0;
    }

    public void CountCells() {
        Debug.LogError(this.cells.Count);
    }
    private bool isPaire(int x) {
        return x%2 == 0;
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