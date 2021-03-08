using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class towerPlacement : MonoBehaviour
{

    public Material mouseOver;
    public Material originalColor;

    public GameObject turret;

    public Renderer rend;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    //indicates the tile that the mouse is over
    private void OnMouseEnter()
    {
        rend.material = mouseOver;
    }

    //places tower when shit occurs
    private void OnMouseDown()
    {
        if (turret != null)
        {
            Debug.Log("Cannot place tower here");
        }
        else if(getMoney.Instance.money < chooseTower.Instance.chosenTowerCost)
        {
            Debug.Log("Do not have the required funds");
        }
        else
        {
            turret = chooseTower.Instance.chosenTower;
            Instantiate(turret, new Vector3(this.transform.position.x, this.transform.position.y + 3, this.transform.position.z), Quaternion.identity);
            getMoney.Instance.money -= chooseTower.Instance.chosenTowerCost;
        }
    }

    //resets tile to normal color after mouse leaves
    private void OnMouseExit()
    {
        rend.material = originalColor;
    }

}
