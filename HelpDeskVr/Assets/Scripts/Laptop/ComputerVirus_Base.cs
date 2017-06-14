using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Virus
{
    public enum VirusType
    {
        NULL = -1,
        Phishing,
        Password,
        USB,
        Encryption,
        Wannacry,
        END
    }

    public class ComputerVirus_Base : MonoBehaviour
    {
        [SerializeField]
        protected GameObject computerMonitor;
        [SerializeField]
        protected GameObject computerBase;
        [SerializeField]
        protected GameObject monitorCanvas;

        protected bool problemSolved = false;

        // Just for others that might need to know the virus type,
        // I don't want to see immense switch statements, let's use 
        // some Inheritance ;)
        protected VirusType type = VirusType.NULL;

        // For the progress bsr, we need to decide if it is on the screen
        // or somewhere else (above or in a thought bubble)
        public int stepsToFix = 0;
        public int fixingProgress = 0;
     

        // Use this for initialization
        protected virtual void Start()
        {
            problemSolved = false;
        }

        // Update is called once per frame
        void Update()
        {

        }

        public virtual void VirusActivate()
        {

        }

        public virtual void VirusDisable()
        {

        }

        public virtual void VirusClear()
        {
            type = Virus.VirusType.NULL;
            problemSolved = true;
        }
    }
}