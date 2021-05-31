using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactible : MonoBehaviour
{
    public bool isLaw;
    public int lawIndex;

    private bool hasBeenBroken = false;


    // trucs qui arrivent quand on interagit (E ou entrer sur zone) avec un truc qui casse une règle
    public void Interacted()
    {
        if (!isLaw || hasBeenBroken)
        {
            return;
        }

        hasBeenBroken = true;
        Debug.Log("Une règle a été brisée");
        // animations d'ui ou jsp quoi

    }
}
