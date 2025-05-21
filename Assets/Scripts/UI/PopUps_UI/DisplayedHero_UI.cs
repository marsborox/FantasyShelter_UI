using UnityEngine;

public class DisplayedHero_UI : UI
{
    public Hero displayedHero;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetHero(Hero hero)
    {
        displayedHero = hero;

    }

}
