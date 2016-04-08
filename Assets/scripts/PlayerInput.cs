using UnityEngine;
using System.Collections;

public class PlayerInput : MonoBehaviour {

    private PlayerMovement m_Character;
    private bool m_Jump;
    public GameObject aShop = null;

    private void Awake()
    {
        m_Character = GetComponent<PlayerMovement>();
    }


    private void Update()
    {
        if (!m_Jump)
        {
            // Read the jump input in Update so button presses aren't missed.
            m_Jump = Input.GetButtonDown("Jump");
        }
        if(Input.GetKeyDown(KeyCode.E) && aShop != null)
        {
            aShop.GetComponent<Shop>().OpenOrClose();
        }
    }


    private void FixedUpdate()
    {
        // Read the inputs.
        bool crouch = Input.GetKey(KeyCode.LeftControl);
        float h = Input.GetAxis("Horizontal");
        if(!m_Character.m_Grounded)
        {
            m_Jump = false;
        }
        // Pass all parameters to the character control script.
        m_Character.Move(h, crouch, m_Jump);
        m_Jump = false;
    }
}
