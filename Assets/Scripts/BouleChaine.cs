using UnityEngine;

public class BouleChaine : Interactable
{
    [SerializeField] private Transform pivot;

    public override void StartGrab()
    {
        base.StartGrab();
    }

    public override void EndGrab()
    {
        base.EndGrab();
    }

    public override void UpdateGrab(InteractionContext interaction)
    {
        base.UpdateGrab(interaction);
        if (interaction != null)
        {
            Vector3 inputPosition = interaction.inputPosition;
        }
    }
}
