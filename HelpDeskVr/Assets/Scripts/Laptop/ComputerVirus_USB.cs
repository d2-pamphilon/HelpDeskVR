using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;

namespace Virus
{
    public class ComputerVirus_USB : ComputerVirus_Base
    {
        [SerializeField]
        GameObject FirstStage;
        [SerializeField]
        GameObject SecondStage;
        [SerializeField]
        GameObject FixedState;

        // Use this for initialization
        protected override void Start()
        {
            base.Start();
        }

        // Update is called once per frame
        void Update()
        {

        }

        public override void VirusActivate()
        {
            base.VirusActivate();
        }

        public override void VirusDisable()
        {
            base.VirusDisable();
        }

        public override void VirusClear()
        {
            base.VirusClear();
            FixedState.SetActive(true);
        }
    }
}
