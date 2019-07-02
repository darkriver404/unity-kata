using UnityEngine;

public class ColorMapTable
{
    public static readonly float FADE_ALPHA = 0.2f;
    public static readonly float DEFAULT_ALPHA = 1f;

    public static readonly int COUNT = 7;
    public static readonly int START_INDEX = 0;
    public static readonly int INVALID_INDEX = -1;
    public static int END_INDEX { get { return START_INDEX + COUNT - 1; } }

    public static float[] mapAlpha = new float[COUNT];
    public static readonly Color[] mapColor = new Color[] 
    {
        Color.red,
        Color.green,
        Color.blue,
        new Color(1, 1, 0, 1),// Color.yellow;
        Color.cyan,
        Color.magenta,
        Color.black,
    };
    public static readonly Color DEFAULT_COLOR = Color.white;


    public static bool CheckMapTypeValid(int type)
    {
        return type >= START_INDEX && type < COUNT;
    }

    public static int GetMapTypeByColor(Color color)
    {
        for (int i = START_INDEX; i < COUNT; i++)
        {
            color.a = DEFAULT_ALPHA;
            if (color.Equals(GetMapColorByType(i)))
            {
                return i;
            }
        }
        return INVALID_INDEX;
    }

    public static Color GetMapColorByType(int type)
    {
        if(!CheckMapTypeValid(type))
        {
            return DEFAULT_COLOR;
        }
        return mapColor[type];
    }

    public static Color GetMapFadeColorByType(int type)
    {
        Color color = GetMapColorByType(type);
        color.a = FADE_ALPHA;
        return color;
    }

    public static Color GetMapFadeColorByColor(Color color)
    {
        return GetMapFadeColorByType(GetMapTypeByColor(color));
    }

    public static string GetMapNameByType(int type)
    {
        return "map_" + type;
    }

    public static float GetAlphaAfterClickMap(int type)
    {
        if (!CheckMapTypeValid(type))
        {
            return DEFAULT_ALPHA;
        }
        mapAlpha[type] = (mapAlpha[type] == DEFAULT_ALPHA) ? FADE_ALPHA : DEFAULT_ALPHA;
        return mapAlpha[type];
    }
}
