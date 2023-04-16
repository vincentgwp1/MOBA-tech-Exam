using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Abilities : MonoBehaviour
{

    [Header("Ability 1")]
    private Animator animator = null;
    public Image abilityImage1;
    public float cooldown1 = 5;
    bool isCooldown = false;
    public KeyCode ability1;
    public ParticleSystem fireball;
    private int attackTrigger1 = 0; 

    //Ability 1 Input Variables
    Vector3 position;
    public Canvas ability1Canvas;
    public Image skillshot;
    public Transform player;

    [Header("Ability 2")]
    public Image abilityImage2;
    public float cooldown2 = 10;
    public KeyCode ability2;

    public ParticleSystem lightning;
    
    public Image skillshot2;
    private int attackTrigger2 = 0;

    

    //Particle System of Firespell
    void IsFiring(int Fire1)
    {
        if (Fire1 == 1)
        {
            fireball.Play();    
        }
    }
    //Particle System of LightningSpell
    void IsLightning(int Light1)
    {
        if (Light1 == 1)
        {
            lightning.Play();   
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        abilityImage1.fillAmount = 0;
        abilityImage2.fillAmount = 0;
        animator = GetComponent<Animator>();
        attackTrigger1 = Animator.StringToHash("AttackTrigger1");
        attackTrigger2 = Animator.StringToHash("AttackTrigger2");
        skillshot.GetComponent<Image>().enabled = false;
        skillshot2.GetComponent<Image>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        Ability1();
        Ability2();
       

        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        //Ability 1 Inputs
        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            position = new Vector3(hit.point.x, hit.point.y, hit.point.z);
        }


        //Ability 1 Canvas Inputs
        Quaternion transRot = Quaternion.LookRotation(position - player.transform.position);
        ability1Canvas.transform.rotation = Quaternion.Lerp(transRot, ability1Canvas.transform.rotation, 0f);

    }

    void Ability1()
    {
        if (Input.GetKey(ability1) && isCooldown == false)
        {
            skillshot.GetComponent<Image>().enabled = true;
            
           
        }

        if (skillshot.GetComponent<Image>().enabled == true && Input.GetMouseButtonDown(0))
        {
            animator.SetTrigger(attackTrigger1);
            
            isCooldown = true;
            abilityImage1.fillAmount = 1;
        }

        if (isCooldown)
        {
            abilityImage1.fillAmount -= 1 / cooldown1 * Time.deltaTime;
            skillshot.GetComponent<Image>().enabled = false;

            if (abilityImage1.fillAmount <= 0)
            {
                abilityImage1.fillAmount = 0;
                isCooldown = false;
            }
        }
    }

    void Ability2()
    {
        if (Input.GetKey(ability2) && isCooldown == false)
        {
            skillshot2.GetComponent<Image>().enabled = true;

            //Disable Other UI
           
        }

        if (skillshot2.GetComponent<Image>().enabled == true && Input.GetMouseButtonDown(0))
        {
            animator.SetTrigger(attackTrigger2);
            isCooldown = true;
            abilityImage2.fillAmount = 1;
        }

        if (isCooldown)
        {
            abilityImage2.fillAmount -= 1 / cooldown1 * Time.deltaTime;
            skillshot2.GetComponent<Image>().enabled = false;

            if (abilityImage2.fillAmount <= 0)
            {
                abilityImage2.fillAmount = 0;
                isCooldown = false;
            }
        }
    }

   
}
