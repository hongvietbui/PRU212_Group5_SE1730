Shader "Custom/OutlineShader"
{
    Properties
    {
        _MainTex ("Base (RGB)", 2D) = "white" {}
        _OutlineColor ("Outline Color", Color) = (1, 0.3, 0, 1) // Adjust to desired color
        _OutlineThickness ("Outline Thickness", Range(0.0, 0.1)) = 0.03 // Adjust to desired thickness
    }
    SubShader
    {
        Tags { "Queue" = "Overlay" }
        Pass
        {
            Name "OUTLINE"
            Tags { "LightMode" = "Always" }
            Cull Front
            ZWrite On
            ColorMask RGB

            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
            };

            struct v2f
            {
                float4 pos : SV_POSITION;
                float4 color : COLOR;
            };

            fixed4 _OutlineColor;
            float _OutlineThickness;

            v2f vert (appdata v)
            {
                v2f o;
                float3 norm = mul((float3x3)UNITY_MATRIX_IT_MV, v.normal);
                float3 offset = norm * _OutlineThickness;
                v.vertex.xyz += offset;
                o.pos = UnityObjectToClipPos(v.vertex);
                o.color = _OutlineColor;
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                return i.color;
            }
            ENDCG
        }

        Pass
        {
            Name "BASE"
            Tags { "LightMode" = "Always" }
            Cull Back
            ZWrite On
            ColorMask RGB

            CGPROGRAM
            #pragma vertex vertBase
            #pragma fragment fragBase
            #include "UnityCG.cginc"

            struct appdata_t
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
            fixed4 _Color;

            v2f vertBase (appdata_t v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            fixed4 fragBase (v2f i) : SV_Target
            {
                fixed4 texcol = tex2D(_MainTex, i.uv);
                return texcol * _Color;
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
}
