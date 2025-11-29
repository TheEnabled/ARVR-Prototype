using UnityEngine;

public class Player : MonoBehaviour
{
    //values to store
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
}
