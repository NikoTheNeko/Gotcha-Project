using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistentData : MonoBehaviour
{
    private static PersistentData _instance;
    public static PersistentData instance {get {return _instance;}}

    [Header("Character Database Reference")]
    public GameObject characterDatabasePrefab;
    public GameObject characterDatabase {get; private set;}

    [SerializeField]
    [Header("Points")]
    [Tooltip("This is the amount of points it has, Default = 0")]
    private int points = 0;

    #region Initialization Functions
        //--------------------------------------------------
        // ensures that this doesn't get destroyed on load
        //--------------------------------------------------
        private void Awake()
        {
            if (_instance != null && _instance != this)
            {
                Destroy(this.gameObject);
            }
            else
            {
                _instance = this;
                DontDestroyOnLoad(gameObject);
                Initialize();
            }
        }

        //------------------------------------
        // instantiates all required prefabs
        //------------------------------------
        private void Initialize()
        {
            if (characterDatabase == null)
            {
                //---------------------------------------------------------------------------
                // try to find the character database in the scene and attach to initialize
                // otherwise, instantiate from prefab
                //---------------------------------------------------------------------------
                try
                {
                    characterDatabase = GameObject.FindGameObjectWithTag("Character Database");
                    if (characterDatabase == null)
                    {
                        characterDatabase = Instantiate(characterDatabasePrefab, Vector3.zero, Quaternion.identity);
                    }
                }
                catch
                {
                    characterDatabase = Instantiate(characterDatabasePrefab, Vector3.zero, Quaternion.identity);
                }
                MakeChild(characterDatabase);
            }
        }

        //---------------------------------------------------------
        // makes PersistentData the parent for another gameObject
        //---------------------------------------------------------
        private void MakeChild(GameObject _gameObject)
        {
            if (_gameObject != null)
            {
                _gameObject.transform.SetParent(gameObject.transform);
            }
        }
    #endregion

    #region "Points Functions"
        //---------------------------------------------
        // adds points; make sure the arg is positive
        //---------------------------------------------
        public void AddPoints(int toAdd)
        {
            points += toAdd;
        }

        //--------------------------------------------------
        // subtracts points; make sure the arg is positive
        //--------------------------------------------------
        public void SubtractPoints(int toSub)
        {
            points -= toSub;
        }

        //-----------------
        // returns points
        //-----------------
        public int GetPoints()
        {
            return points;
        }

        //-------------------------------------
        // returns an updated total of points
        //-------------------------------------
        public int CheckUpdatedTotal(int amount)
        {
            return points + amount;
        }
    #endregion
}
