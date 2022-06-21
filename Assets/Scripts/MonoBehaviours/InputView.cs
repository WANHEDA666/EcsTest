using Interfaces;
using UnityEngine;

namespace MonoBehaviours
{
    public class InputView : MonoBehaviour, IInputView
    {
        private float xDirection;
        private float zDirection;
        
        private void Update()
        {
            if (Input.GetMouseButtonDown(1))
            {
                var screenPosition = Input.mousePosition;
                screenPosition.z = Camera.main.nearClipPlane + 1;
                var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                var hit = new RaycastHit();
                if (Physics.Raycast(ray, out hit))
                {
                    xDirection = hit.point.x;
                    zDirection = hit.point.z;
                }
            }
        }

        public (float, float) GetMouseCoordinates()
        {
            return (xDirection, zDirection);
        }
    }
}