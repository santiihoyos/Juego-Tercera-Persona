using UnityEngine;

public class CameraController : MonoBehaviour
{
  public GameObject Target;
  public float Xoffset;
  public float Yoffset;
  public float Zoffset;

  private Vector3 _positionReal = new Vector3();

  private void LateUpdate()
  {
    Vector3 targetPos = Target.transform.position;
    _positionReal.x = targetPos.x + Xoffset;
    _positionReal.y = targetPos.y + Yoffset;
    _positionReal.z = targetPos.z + Zoffset;
    transform.position = _positionReal;
  }
}