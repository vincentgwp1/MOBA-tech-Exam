using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.VFX;

public class Abilities : MonoBehaviour
{
    [Header("Ability 1")]
    public Image abilityImage1;
    public Text abilityText1;
    public KeyCode ability1Key;
    public float ability1CoolDown = 5;
    public GameObject Fireball;
   

    private bool isAbility1Cooldown = false;
    private float currentAbility1cooldown;
    



    // Start is called before the first frame update
    void Start()
    {
        abilityImage1.fillAmount = 0;
        abilityText1.text = "";
        Fireball.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        Ability1Input();
        AbilityCooldown(ref currentAbility1cooldown, ability1CoolDown, ref isAbility1Cooldown,abilityImage1,abilityText1);
        

    }
    private void Ability1Input()
    {
        if(Input.GetKeyDown(ability1Key) && !isAbility1Cooldown)
        {
            Fireball.SetActive(true);
            isAbility1Cooldown = true;
            currentAbility1cooldown = ability1CoolDown;
            
            Debug.Log("Fire 1!!");
        }
        
    }
   

    private void AbilityCooldown(ref float currentCooldown, float maxCooldown, ref bool isCoolDown, Image skillImage, Text skillText)
    {
        if(isCoolDown)
        {
            currentCooldown -= Time.deltaTime;
            if(currentCooldown <= 0f)
            {
                isCoolDown = false;
                currentCooldown = 0f; 

                if(skillImage != null)
                { 
                skillImage.fillAmount = 0f;   
                }
                if(skillText.text != null)
                {
                    skillText.text = "";
                }
           else
           {
                    if(skillImage != null)
                    {
                        skillImage.fillAmount = currentCooldown/maxCooldown;
                    }
                    if(skillText.text != null)
                    {
                        skillText.text = Mathf.Ceil(currentCooldown).ToString();    
                    }
                }
            }
        }
    }
}
