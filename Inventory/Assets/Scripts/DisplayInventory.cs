using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayInventory : MonoBehaviour
{

    public InventoryObject Inventory;
    public int X_SPACE_BETWWEEN_ITEM;
    public int NUMER_OF_COLUMN;
    public int Y_SPACE_BETWEEN_ITEM;

    public int X_START;
    public int Y_START;

    Dictionary<InventorySlot,GameObject> itemsDisplayed=new Dictionary<InventorySlot, GameObject>();


    // Start is called before the first frame update
    void Start()
    {
        CreateDisplay();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateDisplay();
    }

    private void CreateDisplay(){

        for (int i = 0; i < Inventory.Container.Count; i++)
        {
            var obj=Instantiate(Inventory.Container[i].item.prefab,Vector3.zero,Quaternion.identity,transform);
            obj.GetComponent<RectTransform>().localPosition=GetPosition(i);
            obj.GetComponentInChildren<Text>().text=Inventory.Container[i].amount.ToString("n0");
            itemsDisplayed.Add(Inventory.Container[i],obj);
        }

    }

    public Vector3 GetPosition(int i){

        return new Vector3(X_START+(X_SPACE_BETWWEEN_ITEM*(i%NUMER_OF_COLUMN)),(Y_START+(-Y_SPACE_BETWEEN_ITEM*(i/NUMER_OF_COLUMN))),0f);
    }


    private void UpdateDisplay(){
        
        for (int i = 0; i < Inventory.Container.Count; i++)
        {
            if (itemsDisplayed.ContainsKey(Inventory.Container[i]))
            {
                itemsDisplayed[Inventory.Container[i]].GetComponentInChildren<Text>().text=Inventory.Container[i].amount.ToString("n0");
            }
             else
        {
            var obj=Instantiate(Inventory.Container[i].item.prefab,Vector3.zero,Quaternion.identity,transform);
            obj.GetComponent<RectTransform>().localPosition=GetPosition(i);
            obj.GetComponentInChildren<Text>().text=Inventory.Container[i].amount.ToString("n0");
            itemsDisplayed.Add(Inventory.Container[i],obj);
        }
        }
       



    }



}
