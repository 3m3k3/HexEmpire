using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexCell : MonoBehaviour
{
    public enum Biome {
        Desert,
        Grass,
    }

    public Biome biome;

    private void OnMouseDown() {
        Debug.Log("You clicked on me");
    }
}