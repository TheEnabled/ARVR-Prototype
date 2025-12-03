using UnityEngine;

//inherit this for stuff like players, enemies, etc
public class Entity : MonoBehaviour
{
    //values to store
    [SerializeField] string name = "default";
    [SerializeField] float maxHP = 0;
    [SerializeField] float currentHP = 0;

    void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public float getCurrentHP()
    {
        return currentHP;
    }

    public float getMaxHP()
    {
        return maxHP;
    }

    public string getName()
    {
        return name;
    }
}
