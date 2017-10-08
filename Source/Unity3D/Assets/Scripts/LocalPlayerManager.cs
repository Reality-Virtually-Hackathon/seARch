using UnityEngine;
using Academy.HoloToolkit.Unity;

/// <summary>
/// Manages local player state.
/// </summary>
public class LocalPlayerManager : Singleton<LocalPlayerManager>
{
    /// <summary>
    /// The selected avatar index for the player.
    /// </summary>
    public int AvatarIndex { get; private set; }

    /// <summary>
    /// Changes the user's avatar and lets everyone know.
    /// </summary>
    /// <param name="AvatarIndex"></param>
    public void SetUserAvatar(int AvatarIndex)
    {
        this.AvatarIndex = 0; // AvatarIndex; //WSLNOW

        // Let everyone else know who we are.
        SendUserAvatar();
    }

    /// <summary>
    /// Broadcasts the user's avatar to other players.
    /// </summary>
    public void SendUserAvatar()
    {
        CustomMessages.Instance.SendUserAvatar(AvatarIndex);
    }


    // Send the user's position each frame.
    void Update()
    {
        if (!AppStateManager.Instance.isCommandCenter)
        {
            if (ImportExportAnchorManager.Instance.AnchorEstablished)
            {
                // Grab the current head transform and broadcast it to all the other users in the session
                Transform headTransform = Camera.main.transform;

                // Transform the head position and rotation into local space
                Vector3 headPosition = this.transform.InverseTransformPoint(headTransform.position);
                Quaternion headRotation = Quaternion.Inverse(this.transform.rotation) * headTransform.rotation;

                //WSL: changed to add gaze target, normal
                CustomMessages.Instance.SendHeadTransform(headPosition, headRotation, GazeManager.Instance.HitInfo.point, GazeManager.Instance.HitInfo.normal, 0x1);
            }
        }
    }
}