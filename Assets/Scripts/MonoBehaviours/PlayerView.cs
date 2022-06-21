using Components;
using Interfaces;
using UnityEngine;

namespace MonoBehaviours
{
    public class PlayerView : MonoBehaviour, IPlayerView
    {
        [SerializeField] public Transform playerTransform;
        public Transform PlayerTransform => playerTransform;

        public void Move(ref PlayerComponent playerComponent, InputComponent inputComponent)
        {
            var destination = new Vector3(inputComponent.XDirection, 0, inputComponent.ZDirection);
            playerTransform.LookAt(destination);
            playerTransform.position = Vector3.MoveTowards(playerTransform.position, destination, 0.5f * Time.deltaTime);
            playerComponent.Position = playerTransform.localPosition;
        }
    }
}