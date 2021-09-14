 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexCell : MonoBehaviour
{


    public Material seaMaterial;
    public Material grassMaterial;
    public Material cityMaterial;
    public Material capitalMaterial;
    public Material portMaterial;

     private bool isPort = false;
    private bool isCity = false;
    private bool isCapital = false;
    private bool isSea = false;
    private bool isGrass = false;
    private string materialName;
    public string nature ="";
    public int id;
    public void init (int nature, int id) {
        switch (nature)
        {
            case 0 : 
                setCapital();
                break;
            case 1 : 
                setCity();
                break;
            case 2 : 
                setPort();
                break;
            case 3 : 
                setSea();
                break;
            case 4 : 
                setGrass();    
                break;
            default: 
                Debug.LogError("Nature cell incorrect");
                break;
        }
        
        this.id = id;

    }
    public string getNature() {
        return this.nature;
    }
   

    private void setCapital() { // 0
        this.isCapital = true;
        this.nature = "Capital";
        this.GetComponent<MeshRenderer> ().material = this.capitalMaterial;
        
    }




    private void setCity() { // 1
        this.isCity = true;
        this.nature = "city";
        this.GetComponent<MeshRenderer> ().material = this.cityMaterial;
    }
    private void setPort() { // 2 
        this.isPort = true;
        this.nature = "port";
        this.GetComponent<MeshRenderer> ().material = this.portMaterial;
    }
    private void setSea() { // 3
        this.isSea= true;
        this.nature = "Sea";
        this.GetComponent<MeshRenderer> ().material = this.seaMaterial;
    }

    private void setGrass() { // 4
        this.isGrass = true;
        this.nature = "Grass";
        this.GetComponent<MeshRenderer> ().material = this.grassMaterial;
    }

    public void OnMouseDown() {
        Debug.LogError(id+" : "+nature );
    }

    public bool IsCity() {
        return this.isCity;
    }
}