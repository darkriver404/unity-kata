using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class ClickMap : MonoBehaviour
{
    public GameObject gMap;

    private EventTrigger trigger;
    private RectTransform rectTrans;
    private Material mat;

    void Awake()
    {
        InitComponents();
        InitShaderValues();
    }

    void OnDestroy()
    {
        InitShaderValues();
    }

    void InitComponents()
    {
        trigger = gMap.GetComponent<EventTrigger>();
        if (trigger == null)
        {
            trigger = gMap.AddComponent<EventTrigger>();
        }
        rectTrans = gMap.GetComponent<RectTransform>();
        Image image = gMap.GetComponent<Image>();
        mat = image.material;
    }

    void InitShaderValues()
    {
        for (int i = 0; i < ColorMapTable.COUNT; i++)
        {
            ColorMapTable.mapAlpha[i] = ColorMapTable.DEFAULT_ALPHA;
            mat.SetFloat("_Float" + i, ColorMapTable.mapAlpha[i]);
            mat.SetColor("_Color" + i, ColorMapTable.GetMapColorByType(i));
        }
    }

    void Start()
    {
        EventTool.TryAddEventCallback(trigger, EventTriggerType.PointerClick, OnPointerClick);
    }

    void OnPointerClick(BaseEventData eventData)
    {
        PointerEventData pd = eventData as PointerEventData;
        Vector2 localPoint;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(
            rectTrans,
            pd.position, 
            pd.pressEventCamera, 
            out localPoint))
        {
            Vector2 uv = localPoint + rectTrans.sizeDelta * 0.5f;
            uv.x /= rectTrans.sizeDelta.x;
            uv.y /= rectTrans.sizeDelta.y;
            //Debug.Log(localPoint.x + " , " + localPoint.y);
            //Debug.Log(rectTrans.sizeDelta.x + " , " + rectTrans.sizeDelta.y);
            //Debug.Log(uv.x +" , "+ uv.y);
            int x = (int)(uv.x * 512);
            int y = (int)(uv.y * 512);
            //Debug.Log(x + " , " + y);

            //get click point color
            Texture2D tex = mat.mainTexture as Texture2D;
            Color color = tex.GetPixel(x, y);
            //Debug.Log(color);

            int mapType = ColorMapTable.GetMapTypeByColor(color);
            if (mapType != ColorMapTable.INVALID_INDEX)
            {
                Debug.Log(ColorMapTable.GetMapNameByType(mapType));

                float newAlpha = ColorMapTable.GetAlphaAfterClickMap(mapType);
                //Debug.Log(newAlpha);
                mat.SetFloat("_Float" + mapType, newAlpha);
            }
        }
    }
}
