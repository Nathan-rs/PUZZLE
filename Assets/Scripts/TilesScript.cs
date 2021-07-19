using UnityEngine;

public class TilesScript : MonoBehaviour
{

    public Vector2 targetPosition;
    private  Vector2 correctPosition;
    private SpriteRenderer _sprite;
    public int number;
    public bool flag = true;

    void Awake()
    {
        targetPosition = transform.position;
        correctPosition = transform.position;
        _sprite = GetComponent<SpriteRenderer>();

    }

    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, targetPosition, 0.08f);
        if(targetPosition == correctPosition){
            _sprite.color = Color.green;
            flag = true;
        }else{
            _sprite.color = Color.white;
            flag = false;
        }
    }

    public SpriteRenderer getCor(){
        return _sprite;
    }
}
