using UnityEngine;

namespace CodeBase
{
    public class Painter : MonoBehaviour
    {
        [SerializeField] private int canvasWidth = 800;
        [SerializeField] private int canvasHeight = 600;
        [SerializeField] private int pixelsPerUnit = 100;
        [SerializeField] private int brushRadius = 10;
        [Range(1f, 8f)]
        [SerializeField] private float brushDensity = 6f;
        public Color color = Color.black;

        [SerializeField] private Camera camera;
        private Texture2D texture;
        private Vector2 prevMousePosition;
        private Vector2 mousePosition;
        private Vector2 circlePosition;

        private Vector2 leftBottom;
        private Vector2 rightTop;

        private Vector2 size;

        private Vector2 textureMousePositionTmp;
        private Vector2Int textureMousePosition;
        private Vector2Int brushSize;
        private Vector2Int leftBottomRect;
        private Vector2Int rightTopRect;

        private float distance;

        private Vector2 paintDirection;
        private float brushRadiusInWorld;

        void Start()
        {
            texture = new Texture2D(canvasWidth, canvasHeight);
            Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f), pixelsPerUnit);
            SpriteRenderer spriteRenderer = gameObject.AddComponent<SpriteRenderer>();
            spriteRenderer.sprite = sprite;
            spriteRenderer.sortingLayerName = "OpenedWindow";
            spriteRenderer.sortingOrder = 2;

            size = new Vector2(canvasWidth / (float)pixelsPerUnit, canvasHeight / (float)pixelsPerUnit);
            leftBottom = (Vector2)transform.position - size / 2;
            rightTop = (Vector2)transform.position + size / 2;

            brushSize = new Vector2Int(brushRadius, brushRadius); //
            brushRadiusInWorld = brushRadius / (float)pixelsPerUnit;

            if (camera == null) camera = Camera.main;

        }

        void Update()
        {
            mousePosition = camera.ScreenToWorldPoint(Input.mousePosition);

            if (
                Input.GetMouseButton(0)
                && mousePosition.x > leftBottom.x
                && mousePosition.x < rightTop.x
                && mousePosition.y > leftBottom.y
                && mousePosition.y < rightTop.y)
            {
                paintDirection = (mousePosition - prevMousePosition).normalized;

                circlePosition = prevMousePosition;
                do
                {
                    circlePosition += paintDirection * brushRadiusInWorld / brushDensity;
                    textureMousePositionTmp = (circlePosition - (Vector2)transform.position + size / 2f) * pixelsPerUnit;
                    textureMousePosition = new Vector2Int((int)textureMousePositionTmp.x, (int)textureMousePositionTmp.y);
                    Debug.Log(textureMousePosition);
                    DrawCircle(textureMousePosition);
                }
                while (Vector2.Distance(circlePosition, mousePosition) > brushRadiusInWorld);
                texture.Apply();
            }
            prevMousePosition = mousePosition;
        }


        private void DrawCircle(Vector2Int center)
        {
            leftBottomRect = center - brushSize;
            rightTopRect = center + brushSize;

            for (int y = leftBottomRect.y; y < rightTopRect.y; y++)
            {
                for (int x = leftBottomRect.x; x < rightTopRect.x; x++)
                {
                    distance = Vector2Int.Distance(center, new Vector2Int(x, y));
                    if (distance < brushRadius)
                    {
                        texture.SetPixel(x, y, color);
                    }
                }
            }
        }

    }
}
