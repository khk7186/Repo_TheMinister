using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace IndieMarc
{

    [RequireComponent(typeof(PlayerCharacter))]

    public class PlayerCharacterAnim : MonoBehaviour
    {

        private PlayerCharacter character;
        private SpriteRenderer render;
        private Animator animator;

        private bool prev_air = false;
        private bool prev_crouch = false;

        void Awake()
        {
            character = GetComponent<PlayerCharacter>();
            animator = GetComponent<Animator>();
            render = GetComponent<SpriteRenderer>();
        }

        void Update()
        {

            Vector2 move = character.GetMove();
            animator.SetBool("Jump", character.IsJumping());
            animator.SetBool("InAir", !character.IsGrounded());
            animator.SetBool("Crouch", character.IsCrouching());
            animator.SetFloat("Speed", move.magnitude);

            //Notice a change in state
            bool cur_air = character.IsJumping() || !character.IsGrounded();
            bool cur_crouch = character.IsCrouching();
            if (cur_air != prev_air || cur_crouch != prev_crouch)
                animator.SetTrigger("Action");
            prev_crouch = cur_crouch;
            prev_air = cur_air;

        }
    }

}