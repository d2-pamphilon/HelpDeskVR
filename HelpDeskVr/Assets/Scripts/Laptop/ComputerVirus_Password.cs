using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;

namespace Virus
{
    public class ComputerVirus_Password : ComputerVirus_Base
    {
        [SerializeField]
        Text inputField;
        [SerializeField]
        string currentPassword;
        [SerializeField]
        GameObject FirstStage;
        [SerializeField]
        GameObject SecondStage;
        [SerializeField]
        GameObject PopupMessage;
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
            StartCoroutine(PasswordActivate());
        }

        IEnumerator PasswordActivate()
        {
            string newString = "";
            for (int i = 0; i < currentPassword.Length; i++)
            {
                newString = new Regex("\\S").Replace(newString, "*");
                inputField.text = newString;
                yield return new WaitForSeconds(0.2f);
                newString = newString + currentPassword[i];
                inputField.text = newString;
                yield return new WaitForSeconds(0.2f);
            }
            newString = new Regex("\\S").Replace(newString, "*");
            inputField.text = newString;
            yield return new WaitForSeconds(0.2f);

            SecondStage.SetActive(true);
            FirstStage.SetActive(false);
            PopupMessage.SetActive(!problemSolved);

            yield return null;
        }

        public override void VirusDisable()
        {
            base.VirusDisable();
            SecondStage.SetActive(false);
            FirstStage.SetActive(true);
        }

        public override void VirusClear()
        {
            base.VirusClear();
            FixedState.SetActive(true);

        }
    }
}
