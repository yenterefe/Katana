using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    GameObject blade;

    [SerializeField]
    GameObject tsuka1;
    [SerializeField]
    Button buttonTsuka1;

    [SerializeField]
    GameObject tsuka2;
    [SerializeField]
    Button buttonTsuka2;

    [SerializeField]
    GameObject tsuba;
    Rigidbody tsubaRB;

    [SerializeField]
    Button buttonTsuba;

    [SerializeField]
    GameObject mekugi1;
    [SerializeField]
    Button buttonMekugi1;

    [SerializeField]
    GameObject mekugi2;
    [SerializeField]
    Button buttonMekugi2;

    [SerializeField]
    GameObject parent;

    [SerializeField]
    Button tsubaButton;

    [SerializeField]
    Button tsuka1Button;

    [SerializeField]
    Button tsuka2Button;

    [SerializeField]
    Button mekugi1Button;

    [SerializeField]
    Button mekugi2Button;

    private TsubaScript tsubaScript;
    private Tsuka1Script tsuka1Script;
    private Tsuka2Script tsuka2Script;
    private Mekugi1Script mekugi1Script;
    private Mekugi2Script mekugi2Script;
    private BladeScript bladeScript;

    private float tsubaSpeed = 0.25f;
    private float tsuka1Speed = 0.25f;
    private float tsuka2Speed = 0.25f;
    private float mekugi1Speed = 0.25f;
    private float mekugi2Speed = 0.25f;
    private float parentSpeed = 0.01f;
    private float parentSpeed2 = 0.01f;

    bool tsubaActive = false;
    bool tsuka1Active = false;
    bool tsuka2Active = false;
    bool mekugi1Active = false;
    bool mekugi2Active = false;

    private void Awake()
    {
        tsubaScript= tsuba.GetComponent<TsubaScript>();
        tsuka1Script = tsuka1.GetComponent<Tsuka1Script>();
        tsuka2Script = tsuka2.GetComponent<Tsuka2Script>();
        mekugi1Script= mekugi1.GetComponent<Mekugi1Script>();
        mekugi2Script = mekugi2.GetComponent<Mekugi2Script>();
        bladeScript = blade.GetComponent<BladeScript>();
    }

    void Update()
    {
        MoveParts();
    }

    public void Tsuka1ButtonInitializer()
     {
        EnablePartsTsuka1();
     }

    public void Tsuka2ButtonInitializer()
    {
        EnablePartsTsuka2();
    }

    public void TsubaButtonInitializer()
    {
        EnablePartsTsuba();
        // This method will rotate the blade to have a better visual on how to insert the tsuba
        blade.transform.Rotate(new Vector3(0,-90,0));
        // Once the button is pressed the blade rotates the button will not be interactable
        tsubaButton.enabled = false;
    }

    public void Mekugi1ButtonInitializer()
    {
        EnablePartsMekugi1();
    }

    public void Mekugi2ButtonInitializer()
    {
        EnablePartsMekugi2();
    }

    public void EnablePartsTsuba()
    {
            tsuba.gameObject.SetActive(true);
            tsubaActive = true;
    }

    public void EnablePartsTsuka1()
    {
        if (tsubaActive == true)
        {
            tsuka1.gameObject.SetActive(true);
            tsuka1Active = true;
            // once the button is pressed, it will not be interactable 
            tsuka1Button.enabled = false;
        }
    }
            
    public void EnablePartsTsuka2()
    {
        if (tsubaActive == true)
        {
            tsuka2.gameObject.SetActive(true);
            tsuka2Active = true;
            //once the button is pressed, it will not be interactable 
            tsuka2Button.enabled= false;
        }
    }

    public void EnablePartsMekugi1()
    {
        if (tsubaActive == true && tsuka1Active == true && tsuka2Active == true)
        {
            mekugi1.gameObject.SetActive(true);
            mekugi1Active = true;
            //once the button is pressed, it will not be interactable
            mekugi1Button.enabled = false;  
        }
    }

        public void EnablePartsMekugi2()
    {
        if (tsubaActive == true && tsuka1Active == true && tsuka2Active == true)
        {
            mekugi2.gameObject.SetActive(true);
            mekugi2Active = true;
            //once the button is pressed, it will not be interactable
            mekugi2Button.enabled = false;
        }
    }

    void MoveParts()
    {
        if (tsubaActive== true)
        {
            // If the tsuba does not hit the trigger of the invisible cube, it will continue moving in the X axis
            if (tsubaScript.stopObject == false)
            {
                tsuba.transform.Translate(new Vector3(0.1f, 0f, 0f) * tsubaSpeed);
            }

            // If the tsuba hits the trigger, it will move in the z axis
            if (tsubaScript.stopObject == true)
            {
                tsuba.transform.Translate(new Vector3(0f, 0f, 0.1f) * tsubaSpeed);

                // If the tsuba hits the second invisible box, it will stop moving by making the speed equal to zero
                if (tsubaScript.numberOfhits % 2 == 0f)
                {
                    tsubaSpeed = 0f;
                }
            }
        }

        if (tsuka1Active == true)
        {
            // If the tsuka doesn't hit the blade, it will continue moving in the z axis
            if (tsuka1Script.hitBlade == false)
            {
                tsuka1.transform.Translate(new Vector3(0f, 0f, 0.1f) * tsuka1Speed);
            }

            // If the tsuka hits the blade, it will stop moving by making the speed equal to zero
            if (tsuka1Script.hitBlade == true)
            {
                 tsuka1Speed=0f;
            }
        }

        if (tsuka2Active == true)
        {
            // If the tsuka doesn't hit the blade, it will continue moving in the opposite direction of the z axis
            if (tsuka2Script.hitBlade == false)
            {
                tsuka2.transform.Translate(new Vector3(0f, 0f, -0.1f) * tsuka2Speed);
            }

            // If the tsuka hits the blade, it will stop moving by making the speed equal to zero
            if (tsuka2Script.hitBlade == true)
            {
                tsuka2Speed = 0f;
            }
        }

        if (mekugi1Active==true)
        {
            // The katana will rotate so there is a better view of how the mekugi will be inserted
            if (bladeScript.stopObject == false)
            {
                parent.transform.Rotate(new Vector3(0f, -7f, 0f) * parentSpeed);
            }

            if (bladeScript.stopObject==true)
            {
                parentSpeed = 0f;
            }

            // The meguki will move until it hits tsuka2
            if (mekugi1Script.hitTsuka2==false && bladeScript.stopObject== true)
            {
                mekugi1.transform.Translate(new Vector3(0, 0.1f, 0f) * mekugi1Speed);
            }

            if (mekugi1Script.hitTsuka2==true)
            {
                mekugi1Speed = 0f;
            }
        }

        if (mekugi2Active == true)
        {
            // The katana will rotate so there is a better view of how the second mekugi will be inserted
            if (bladeScript.stopObject == true && bladeScript.stopObject2 == false)
            {
                parent.transform.Rotate(new Vector3(0f, 7f, 0f) * parentSpeed2);
            }

            if (bladeScript.stopObject2 == true)
            {
                parentSpeed2 = 0f;
            }

            // The meguki will move until it hits tsuka2
            if (bladeScript.stopObject2 == true )
            {
                mekugi2.transform.Translate(new Vector3(0f, -0.1f, 0f) * mekugi2Speed);
            }

            if (mekugi2Script.hitTsuka1 == true)
            {
               mekugi2Speed = 0f;
            }
        }
    }
}
 
