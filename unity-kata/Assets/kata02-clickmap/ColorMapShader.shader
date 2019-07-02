Shader "Unlit/ColorMapShader"
{
	Properties
	{
		_MainTex("Texture", 2D) = "white" {}

		[HideInInspector]_Color0("_Color", Color) = (1,1,1,1)
		[HideInInspector]_Color1("_Color", Color) = (1,1,1,1)
		[HideInInspector]_Color2("_Color", Color) = (1,1,1,1)
		[HideInInspector]_Color3("_Color", Color) = (1,1,1,1)
		[HideInInspector]_Color4("_Color", Color) = (1,1,1,1)
		[HideInInspector]_Color5("_Color", Color) = (1,1,1,1)
		[HideInInspector]_Color6("_Color", Color) = (1,1,1,1)

		[HideInInspector]_Float0("_Float",Float) = 0
		[HideInInspector]_Float1("_Float",Float) = 0
		[HideInInspector]_Float2("_Float",Float) = 0
		[HideInInspector]_Float3("_Float",Float) = 0
		[HideInInspector]_Float4("_Float",Float) = 0
		[HideInInspector]_Float5("_Float",Float) = 0
		[HideInInspector]_Float6("_Float",Float) = 0
	}
	SubShader
	{
		Tags { "Queue"="Transparent" "IgnoreProjector" = "True" "RenderType"="Transparent" }
		Cull Off

		Pass
		{
			ZWrite Off
			Blend SrcAlpha OneMinusSrcAlpha

			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			
			#include "UnityCG.cginc"

			struct appdata
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
			};

			struct v2f
			{
				float2 uv : TEXCOORD0;
				float4 vertex : SV_POSITION;
			};

			sampler2D _MainTex;
			float4 _MainTex_ST;
			float4 _Color0;
			float4 _Color1;
			float4 _Color2;
			float4 _Color3;
			float4 _Color4;
			float4 _Color5;
			float4 _Color6;

			float _Float0;
			float _Float1;
			float _Float2;
			float _Float3;
			float _Float4;
			float _Float5;
			float _Float6;

			float r;
			float g;
			float b;

			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = TRANSFORM_TEX(v.uv, _MainTex);
				return o;
			}
			
			fixed4 frag (v2f i) : SV_Target
			{
				fixed4 col = tex2D(_MainTex, i.uv);
				if (col.r == _Color0.r && col.g == _Color0.g && col.b == _Color0.b)
				{
					col.a = _Float0;
				}
				else if (col.r == _Color1.r && col.g == _Color1.g && col.b == _Color1.b)
				{
					col.a = _Float1;
				}
				else if(col.r == _Color2.r && col.g == _Color2.g && col.b == _Color2.b)
				{
					col.a = _Float2;
				}
				else if (col.r == _Color3.r && col.g == _Color3.g && col.b == _Color3.b)
				{
					col.a = _Float3;
				}
				else if (col.r == _Color4.r && col.g == _Color4.g && col.b == _Color4.b)
				{
					col.a = _Float4;
				}
				else if (col.r == _Color5.r && col.g == _Color5.g && col.b == _Color5.b)
				{
					col.a = _Float5;
				}
				else if (col.r == _Color6.r && col.g == _Color6.g && col.b == _Color6.b)
				{
					col.a = _Float6;
				}
				return col;
			}
			ENDCG
		}
	}
}
