using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace IMedia9
{

    public class SpriteAutoTrack : MonoBehaviour
    {

        public enum SpriteType { ZoomIn, ZoomOut, MoveLeft, MoveRight, MoveUp, MoveDown }
        public SpriteType spriteType;
        public GameObject ActiveSprite;
        public float Speed = 0.5f;
        public bool hasStopTime;
        public int StopTime;
        bool isMove = true;
        int TimerTrigger = 0;

        // Use this for initialization
        void Start()
        {
            InvokeRepeating("TimerLoop", 1, 1);
        }

        void TimerLoop() {
            TimerTrigger = TimerTrigger + 1;
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            if (isMove)
            {
                if (spriteType == SpriteType.MoveLeft)
                {
                    ActiveSprite.transform.Translate(Vector3.left * Speed * Time.deltaTime);
                }
                if (spriteType == SpriteType.MoveRight)
                {
                    ActiveSprite.transform.Translate(Vector3.right * Speed * Time.deltaTime);
                }
                if (spriteType == SpriteType.MoveUp)
                {
                    ActiveSprite.transform.Translate(Vector3.up * Speed * Time.deltaTime);
                }
                if (spriteType == SpriteType.MoveDown)
                {
                    ActiveSprite.transform.Translate(Vector3.down * Speed * Time.deltaTime);
                }
                if (spriteType == SpriteType.ZoomIn)
                {
                    Vector3 temp = ActiveSprite.transform.localScale;
                    temp.x += Speed * Time.deltaTime;
                    temp.y += Speed * Time.deltaTime;
                    temp.z += Speed * Time.deltaTime;
                    ActiveSprite.transform.localScale = temp;
                }
                if (spriteType == SpriteType.ZoomOut)
                {
                    Vector3 temp = ActiveSprite.transform.localScale;
                    temp.x -= Speed * Time.deltaTime;
                    temp.y -= Speed * Time.deltaTime;
                    temp.z -= Speed * Time.deltaTime;
                    ActiveSprite.transform.localScale = temp;
                }
            }
            if (hasStopTime) {
                if (TimerTrigger == StopTime)
                {
                    isMove = false;
                }
            }
        }
    }
}
