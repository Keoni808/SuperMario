using UnityEngine;

public class CameraSystem : MonoBehaviour
{


    private GameObject player;
    public float xMin;
    public float xMax;
    public float yMin;
    public float yMax;

    void Start() {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void LateUpdate() {
        float x = Mathf.Clamp(player.transform.position.x, xMin, xMax);
        float y = Mathf.Clamp(player.transform.position.y, yMin, yMax);
        gameObject.transform.position = new Vector3(x, y, gameObject.transform.position.z);
    }

//    public Transform target;
//    public Vector3 offset;
//    [Range(1,10)]
//    public float smoothFactor;

//    private void FixedUpdate(){
//        Follow();
//    }

//    void Follow(){

//        Vector3 targetPosition = target.position + offset;
//        Vector3 smoothPosition = Vector3.Lerp(transform.position, targetPosition, smoothFactor*Time.fixedDeltaTime);
//        transform.position = targetPosition;
//    }

}