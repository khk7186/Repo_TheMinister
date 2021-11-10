using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Animated 2D horse main script for platformer movement and jump
/// Author: Indie Marc (Marc-Antoine Desbiens)
/// Company: Falling Flames Games
/// This script can be used in your commercial game only if you officially purchased this script, or an asset package containing this script.
/// If you obtained this script for free, please do not remove this notice and credit the author. Thank you.
/// </summary>


namespace IndieMarc
{

    [RequireComponent(typeof(Horse))]
    public class HorseControls : MonoBehaviour
    {
        public KeyCode left_key;
        public KeyCode right_key;
        public KeyCode up_key;
        public KeyCode down_key;
        public KeyCode kick_key;

        private Vector2 move = Vector2.zero;
        private bool kick = false;
        private Horse horse;

        private void Awake()
        {
            horse = GetComponent<Horse>();
        }

        void Update()
        {
            //init
            move = Vector2.zero;
            kick = false;

            //Get move vector
            if (Input.GetKey(left_key))
                move += -Vector2.right;
            if (Input.GetKey(right_key))
                move += Vector2.right;
            if (Input.GetKey(up_key))
                move += Vector2.up;
            if (Input.GetKey(down_key))
                move += -Vector2.up;

            //Normalize
            float move_length = Mathf.Min(move.magnitude, 1f);
            move = move.normalized * move_length;

            //Get kick
            kick = Input.GetKeyDown(kick_key);

            //Set horse script values
            horse.SetMove(move);
            if (kick){
                if (horse.GetSpeedLevel() >= 2)
                    horse.DoJump();

                horse.DoIncreaseSpeed();
            }
        }


        //------ These functions should be called from the Update function, not FixedUpdate
        public Vector2 GetMove()
        {
            return move;
        }

        public bool GetKick() {
            return kick;
        }
    }

}