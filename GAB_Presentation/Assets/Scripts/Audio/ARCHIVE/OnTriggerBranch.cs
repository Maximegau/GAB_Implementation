using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTriggerBranch : MonoBehaviour {

    public MX_BranchingSegment newBranch;


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && MX_Branching.instance.currentBranch != newBranch)
        {
            MX_Branching.instance.ChangeToNewBranch(newBranch);
        }
    }
}
