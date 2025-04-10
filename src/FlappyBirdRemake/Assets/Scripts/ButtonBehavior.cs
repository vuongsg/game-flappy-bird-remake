using UnityEngine;

public class ButtonBehavior : MonoBehaviour
{
    public Texture2D hoverTexture2D;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnHover()
    {
        Cursor.SetCursor(hoverTexture2D, Vector2.zero, CursorMode.Auto);
    }

	public void OnExit()
	{
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
	}
}
