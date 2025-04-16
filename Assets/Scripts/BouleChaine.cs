using UnityEngine;

public class BouleChaine : Interactable
{
    [SerializeField] private Transform pivot; // L'élément parent à faire tourner (ex: la racine de la chaîne)

    private Vector3 previousInputPosition;

    public override void StartGrab()
    {
        base.StartGrab();

        previousInputPosition = Vector3.zero;

        Rigidbody rigi = GetComponent<Rigidbody>();
        if (rigi != null)
            rigi.isKinematic = true;
    }

    public override void EndGrab()
    {
        base.EndGrab();
        previousInputPosition = Vector3.zero;
    }

    public override void UpdateGrab(InteractionContext interaction)
    {
        base.UpdateGrab(interaction);

        if (interaction == null || pivot == null)
            return;

        Vector3 inputPosition = interaction.inputPosition;

        if (previousInputPosition == Vector3.zero)
        {
            previousInputPosition = inputPosition;
            return;
        }

        // Déplacement horizontal (gauche/droite)
        Vector3 delta = inputPosition - previousInputPosition;

        // Rotation autour de l'axe Y en fonction du déplacement horizontal
        float rotationAmount = delta.x * 300f; // Ajuste le facteur pour la sensibilité
        pivot.Rotate(Vector3.up, rotationAmount, Space.World);

        previousInputPosition = inputPosition;
    }
}
