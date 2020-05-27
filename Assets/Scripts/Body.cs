using UnityEngine;

public class Body : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _image_ = null;
    public void SetSize(uint width, uint height)
    {
        _image_.size = new Vector2(width, height);
    }
}
