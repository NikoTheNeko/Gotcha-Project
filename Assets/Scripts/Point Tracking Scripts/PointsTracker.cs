using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsTracker : MonoBehaviour{

#region Variables
    [Header("Points")]
    [Tooltip("This is the amount of points it has, Default = 0")]
    public int Points = 0;

    private static PointsTracker original;
#endregion

#region Awake Function
    //This will set it so that way it doesn't get destroyed on load
    private void Awake() {
        if(original == null){
            original = this;
            DontDestroyOnLoad(gameObject);
        } else if (original != this){
            Destroy(gameObject);
        }
    }
#endregion

#region Core Functions
    /**
        This function adds a certain amount of points.
        int AmountToAdd is the value that will be added
        Note make sure the value is positive
    **/
    public void AddPoints(int AmountToAdd){
        Points += AmountToAdd;
    }

    /**
        Does the same as the AddPoints function does
        Except you know, subtracts
        int AmountToSubtract is the value that will be removed
        Note make sure the value is positive
    **/
    public void SubtractPoints(int AmountToSubtract){
        Points -= AmountToSubtract;
    }

    /**
        This returns points from the thingy that way you can like
        you know, get the current amount of points
    **/ 
    public int GetPoints(){
        return Points;
    }
#endregion 

#region Check Functions
    /**
        This will give you an updated total so basically
        you can tell the user how much they will have after
        you add or subtract each thing.
    **/
    public int CheckUpdatedTotal(int AmountToChange){
        return Points + AmountToChange;
    }
#endregion


}
