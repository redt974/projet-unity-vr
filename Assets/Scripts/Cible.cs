using UnityEngine;

public class Cible : Interactable
{
    public override void StartGrab()
    {
        base.StartGrab();

        Rigidbody rigi = GetComponent<Rigidbody>();
        if (rigi != null)
            rigi.isKinematic = true; // toujours kinematic
    }

    public override void EndGrab()
    {
        base.EndGrab();
    }

    public override void UpdateGrab(InteractionContext interaction)
    {
        base.UpdateGrab(interaction);

        // Déplacement de l'objet
        transform.position = interaction.inputPosition;
    }
}
