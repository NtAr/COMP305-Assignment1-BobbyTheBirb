// ===============================
// AUTHOR:        Nataliia Arsenieva
// CREATE DATE:   September 30, 2019
// PURPOSE:       Control computer generated objects (clouds and evil birds). Control the counter.
// SPECIAL NOTES: 
// ===============================
// Change History: #1 - Clouds are being created;
//                 #2 - Attempts to detect collision of 2 prefabs;
//                 #3 - Score detection added;
//                 #4 - Lives and Score counters added;
//                 #5 - Evil Bird added;
//=================



using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Util
{
    [System.Serializable]
    public class GameController : MonoBehaviour
    {
        [Header("Scene Game Objects")]
        public GameObject cloud;
        public GameObject evilBirb;

        [Header("Cloud and Birb Control")]
        public int NumberOfClouds = 3;
        public List<GameObject> clouds;
        //public int NumberOfBirbs = 2;
        public List<GameObject> birbs;

        [Header("Score board")]
        [SerializeField]
        private int _score;
        public Text scoreLabel;

        [SerializeField]
        private int _lives;
        public Text livesLabel;

        
        //score get-setter 
        public int Score
        {
            get { return _score; }
            set
            {
                _score = value;
                scoreLabel.text = "Score: " + _score.ToString();
            }
        }

        //lives get-setter 
        public int Lives
        {
            get { return _lives; }
            set
            {
                _lives = value;
                if (_lives <= 0)
                {
                    SceneManager.LoadScene("end");
                }
                livesLabel.text = "Lives: " + _lives.ToString();
            }
        }

        // Start is called before the first frame update
        void Start()
        {
            Lives = 5;
            Score = 0;

            for (int cloudNum = 0; cloudNum < NumberOfClouds; cloudNum++)
            {
                clouds.Add(Instantiate(cloud));
            }


            Instantiate(evilBirb);
           
        }
        // Update is called once per frame
        void Update()
        {
            //chechk if the "+100" object is on the scene
            if (GameObject.FindGameObjectWithTag("fly") != null)
            {
                //start adding points
                Score += 1;
            }
        }
    }
}