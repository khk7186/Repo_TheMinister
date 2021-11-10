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
    public class Horse : MonoBehaviour {

        [Header("Horse")]
        public float move_speed_walk = 2f;
        public float move_speed_run = 5f;
        public float move_acceleration = 5f;
        public float walk_duration = 1f;
        public float run_duration = 5f;
        public GameObject saddle;

        [Header("Ground Detect")]
        public LayerMask ground_layer;
        public float ground_raycast_dist = 0.1f;
        public float rotate_speed = 90f;
        public float max_angle = 45f;

        [Header("Jump")]
        public bool can_jump = true;
        public float jump_strength = 5f;
        public float jump_duration = 0.5f;
        public float jump_gravity = 1f;
        public float fall_gravity = 4f;
        public float jump_move_percent = 0.5f;

        [Header("Rider")]
        public GameObject rider;
        public Vector2 rider_offset;
        public bool revert_side = false;

        [Header("Audio")]
        public AudioClip audio_walk;
        public AudioClip audio_run;
        public AudioClip audio_jump;
        public AudioClip audio_neigh;

        private Rigidbody2D rigid;
        private Animator animator;
        private AudioSource audio_source;
        private CapsuleCollider2D capsule_coll;
        private ContactFilter2D contact_filter;
        private Vector3 start_scale;
        private float audio_start_vol;

        private int speed_level = 0; // 0=Idle, 1=Walk, 2=Run
        private int move_side = 1;
        private bool is_grounded = false;
        private bool is_grounded_offset = false; //Almost touch ground
        private float is_grounded_inside = 0f; //Inside ground
        private bool is_ceiled = false;
        private float target_angle = 0f;
        private Vector2 controls_move = Vector2.zero;
        private Vector2 horse_move = Vector2.zero;
        private bool is_jumping = false;
        private float speed_timer = 0f;
        private float jump_timer = 0f;

        void Awake() {
            rigid = GetComponent<Rigidbody2D>();
            animator = GetComponent<Animator>();
            audio_source = GetComponent<AudioSource>();
            capsule_coll = GetComponent<CapsuleCollider2D>();
            start_scale = transform.localScale;
            audio_start_vol = audio_source.volume;

            contact_filter = new ContactFilter2D();
            contact_filter.layerMask = ground_layer;
            contact_filter.useLayerMask = true;
            contact_filter.useTriggers = false;
        }

        void Update() {

            jump_timer += Time.deltaTime;

            //Slow down after time
            if (speed_level > 0)
            {
                speed_timer += Time.deltaTime;
                float duration = (speed_level >= 2) ? run_duration : walk_duration;
                if (speed_timer > duration)
                {
                    speed_level--;
                    speed_timer = 0f;
                }
            }

            //Start walking without kick
            if (speed_level <= 1 && Mathf.Abs(controls_move.x) >= 0.2f)
            {
                speed_level = 1;
                speed_timer = walk_duration;
            }

            //Orientation
            if (Mathf.Abs(controls_move.x) >= 0.2f)
            {
                int next_side = Mathf.RoundToInt(Mathf.Sign(controls_move.x));
                if (next_side != move_side)
                {
                    // Change orientation slow down horse
                    speed_level = Mathf.Clamp(speed_level, 0, 1);
                    horse_move.x = 0f;
                }
                move_side = next_side;
                transform.localScale = new Vector3(start_scale.x * move_side, start_scale.y, start_scale.z);
            }

            //Animation
            animator.SetFloat("Move", Mathf.Abs(horse_move.x));
            animator.SetFloat("MoveY", horse_move.y);
            animator.SetBool("Run", speed_level >= 2);
            animator.SetBool("Air", !is_grounded_offset);

            //Sounds
            AudioClip clip = null;
            if (speed_level >= 2 && is_grounded_offset)
                clip = audio_run;
            else if (speed_level == 1 && is_grounded_offset)
                clip = audio_walk;
            PlayAudioLoop(clip);

            //Rider
            if (rider)
            {
                float revert = revert_side ? -1f : 1f;
                Vector3 rider_scale = rider.transform.localScale;
                rider.transform.position = saddle.transform.position + new Vector3(rider_offset.x, rider_offset.y, 0f);
                rider.transform.rotation = saddle.transform.rotation;
                rider.transform.localScale = new Vector3(Mathf.Abs(rider_scale.x) * revert * move_side, rider_scale.y, rider_scale.z);
            }
        }

        void FixedUpdate()
        {
            //Ground / Air 
            DetectGrounded();
            UpdateJump();

            //Inside ground
            if (is_grounded_inside > 0.01f)
                rigid.position += Vector2.up * is_grounded_inside;

            //Do rotate
            float ang_diff = target_angle - rigid.rotation;
            if (ang_diff > 180f) ang_diff -= 360f;
            if (ang_diff < -180f) ang_diff += 360f;
            float ang_speed = Mathf.Min(rotate_speed * Time.fixedDeltaTime, Mathf.Abs(ang_diff));
            float angle = rigid.rotation + Mathf.Sign(ang_diff) * ang_speed;
            rigid.rotation = Mathf.MoveTowards(rigid.rotation, angle, rotate_speed * Time.fixedDeltaTime);

            //Do movement
            float desiredSpeed = move_side * GetSpeed();
            float acceleration = !is_grounded ? jump_move_percent * move_acceleration : move_acceleration;
            horse_move.x = Mathf.MoveTowards(horse_move.x, desiredSpeed, acceleration * Time.fixedDeltaTime);
            rigid.velocity = horse_move;
        }

        private void UpdateJump()
        {
            //Jump end timer
            if (is_jumping && jump_timer > jump_duration)
                is_jumping = false;

            //Jump hit ceil
            if (is_ceiled)
            {
                is_jumping = false;
                horse_move.y = Mathf.Min(horse_move.y, 0f);
            }

            //Fall
            if (can_jump && is_jumping)
                horse_move.y = Mathf.MoveTowards(horse_move.y, -jump_gravity, 2f * jump_gravity * Time.fixedDeltaTime);
            else if (!is_grounded)
                horse_move.y = Mathf.MoveTowards(horse_move.y, -fall_gravity, 2f * fall_gravity * Time.fixedDeltaTime);
            else
                horse_move.y = 0f;
        }

        //----  Actions -----

        private void TryJump()
        {
            if (can_jump && is_grounded)
            {
                horse_move.y = jump_strength;
                jump_timer = 0f;
                is_jumping = true;
                animator.SetTrigger("Jump");
                PlayAudio(audio_jump, audio_start_vol);
            }
        }

        //----  Usefull functions -----
        private void DetectGrounded()
        {
            //Compute variables
            float radius = capsule_coll.size.y * 0.5f * transform.localScale.y;
			Vector2 raycast_start = rigid.position + capsule_coll.offset * transform.localScale.y;
            float ray_size = radius + ground_raycast_dist * transform.localScale.y;
            float ray_size_dist = radius * 2f + ground_raycast_dist * transform.localScale.y;
            Vector3 left_point = RotatePointAroundPivot(raycast_start + Vector2.left * radius * move_side, transform.position, transform.rotation.eulerAngles);
            Vector3 middle_point = RotatePointAroundPivot(raycast_start, transform.position, transform.rotation.eulerAngles);
            Vector3 right_point = RotatePointAroundPivot(raycast_start + Vector2.right * radius * move_side, transform.position, transform.rotation.eulerAngles);

            //Raycasts
            bool top_left = DoRaycastHit(left_point, transform.up, ray_size);
            bool top_middle = DoRaycastHit(middle_point, transform.up, ray_size);
            bool top_right = DoRaycastHit(right_point, transform.up, ray_size);
            bool bottom_left = DoRaycastHit(left_point, -transform.up, ray_size);
            bool bottom_middle = DoRaycastHit(middle_point, -transform.up, ray_size);
            bool bottom_right = DoRaycastHit(right_point, -transform.up, ray_size);
            Vector2 bottom_left_pos = GetRaycastHit(left_point, -transform.up, ray_size_dist);
            Vector2 bottom_middle_pos = GetRaycastHit(middle_point, -transform.up, ray_size_dist);
            Vector2 bottom_right_pos = GetRaycastHit(right_point, -transform.up, ray_size_dist);
            float bottom_left_dist = (bottom_left_pos - new Vector2(left_point.x, left_point.y)).magnitude;
            float bottom_middle_dist = (bottom_middle_pos - new Vector2(middle_point.x, middle_point.y)).magnitude;
            float bottom_right_dist = (bottom_right_pos - new Vector2(right_point.x, right_point.y)).magnitude;

            is_grounded = bottom_left || bottom_middle || bottom_right; //Is touching ground
            is_grounded_offset = is_grounded || (bottom_left_dist < ray_size * 1.2f) || (bottom_middle_dist < ray_size * 1.2f) || (bottom_right_dist < ray_size * 1.2f); //Almost touching ground? Dont do air anim yet
            is_grounded_inside = (bottom_middle_dist < ray_size * 0.98f) ? ray_size - bottom_middle_dist : 0f; //Too low inside ground? Will push back up
            is_ceiled = top_left || top_middle || top_right; //Top is hitting ceiling

            //Angle (right=front, left=back)
            target_angle = transform.rotation.eulerAngles.z;
            if (is_grounded && !bottom_right && bottom_left)
                target_angle = -max_angle * move_side;
            if (is_grounded && !bottom_left && bottom_right)
                target_angle = max_angle * move_side;
            if (!is_grounded_offset)
                target_angle = 0f;

            //More precise angle if grounded
            if (is_grounded_offset && bottom_middle_dist < ray_size_dist * 0.99f && bottom_middle_dist < ray_size_dist * 0.99f)
            {
                Vector2 angle_vect = bottom_right_pos - bottom_left_pos;
                target_angle = Vector2.SignedAngle(Vector2.right * move_side, angle_vect);
                target_angle = Mathf.Clamp(target_angle, -max_angle, max_angle);
            }

            //Debug.Log(bottom_left_dist + " " + bottom_middle_dist + " " + bottom_right_dist + " " + target_angle);
            Debug.DrawRay(left_point, -transform.up * ray_size, bottom_left ? Color.red : Color.white);
            Debug.DrawRay(middle_point, -transform.up * ray_size, bottom_middle ? Color.red : Color.white);
            Debug.DrawRay(right_point, -transform.up * ray_size, bottom_right ? Color.red : Color.white);

        }

        private Vector3 RotatePointAroundPivot(Vector3 point, Vector3 pivot, Vector3 angles) {
            Vector3 dir = point - pivot; // get point direction relative to pivot
            dir = Quaternion.Euler(angles) * dir; // rotate it
            return dir + pivot; // calculate rotated point
        }

        private bool DoRaycastHit(Vector2 pos, Vector2 ori, float ray_size)
        {
            bool hit = false;
            RaycastHit2D[] hitBuffer = new RaycastHit2D[5];
            int count = Physics2D.Raycast(pos, ori, contact_filter, hitBuffer, ray_size);
            for (int j = 0; j < hitBuffer.Length; j++)
            {
                if (hitBuffer[j].collider != null)
                    hit = true;
            }
            return hit;
        }

        private Vector2 GetRaycastHit(Vector2 pos, Vector2 ori, float ray_size)
        {
            Vector2 hit = Vector2.zero;
            RaycastHit2D[] hitBuffer = new RaycastHit2D[5];
            int count = Physics2D.Raycast(pos, ori, contact_filter, hitBuffer, ray_size);
            for (int j = 0; j < hitBuffer.Length; j++)
            {
                if (hitBuffer[j].collider != null)
                    hit += hitBuffer[j].point;
            }

            if (count > 0)
                return hit / count;

            return pos + ori * ray_size;
        }

        // ---- Audio -------
        public void PlayAudio(AudioClip clip, float vol=1f) {
            if (clip != null)
            {
                audio_source.clip = clip;
                audio_source.volume = vol;
                audio_source.loop = false;
                audio_source.Play();
            }
        }

        public void PlayAudioLoop(AudioClip clip)
        {
            if (!audio_source.isPlaying || (audio_source.loop && audio_source.clip != clip))
            {
                audio_source.clip = clip;
                audio_source.volume = audio_start_vol;
                audio_source.loop = true;

                if (!audio_source.isPlaying)
                    audio_source.Play();
            }
        }

        // ---- Receive commands -----
        public void DoKick()
        {
            if (speed_level >= 2)
                TryJump();

            speed_level++;
            speed_level = Mathf.Clamp(speed_level, 0, 2);
            speed_timer = 0f;
        }

        public void DoIncreaseSpeed()
        {
            speed_level++;
            speed_level = Mathf.Clamp(speed_level, 0, 2);
            speed_timer = 0f;
        }

        public void DoJump()
        {
            TryJump();
        }

        public void SetMove(Vector2 move)
        {
            float length = Mathf.Min(move.magnitude, 1f);
            controls_move = move.normalized * length;
        }

        // ---- Getters -------
        public Vector2 GetMove()
        {
            return controls_move;
        }

        public int GetSpeedLevel(){
            return speed_level;
        }

        public float GetSpeed()
        {
            if (speed_level == 1)
                return move_speed_walk;
            if (speed_level == 2)
                return move_speed_run;
            return 0f;
        }
    }

}