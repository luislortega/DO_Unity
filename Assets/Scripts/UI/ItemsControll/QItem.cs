using UnityEngine;

//Clasa de baza pentru orice tip de Item din meniurile cu Iteme\\
public abstract class QItem : MonoBehaviour {

    public Sprite itemIcon;
    public int itemQuantity;
    [HideInInspector] public GameObject playerShip;

    //Functia apelata la necesitatea utilizarii itemului din barele de actiune\\
    public abstract void Use();

    void Awake()
    {
        playerShip = GameObject.FindGameObjectWithTag("Player"); 
    }
}
