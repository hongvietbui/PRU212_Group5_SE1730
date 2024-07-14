Shader "Unlit/OutlineTransparentShader"
{
    Properties
    {
        _MainTex ("Base (RGB)", 2D) = "white" {}
        _Color ("Main Color", Color) = (1,1,1,1)
        _OutlineColor ("Outline Color", Color) = (1,1,0,1)
        _OutlineThickness ("Outline Thickness", Range (0.0, 0.03)) = 0.005
    }
    SubShader
    {
        Tags { "Queue" = "Transparent" }
        Pass
        {
            Name "BASE"
            Blend SrcAlpha OneMinusSrcAlpha
            ZWrite Off
            Cull Back
            Lighting Off

            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
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
            float4 _Color;

            v2f vert (appdata_t v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            half4 frag (v2f i) : SV_Target
            {
                half4 texcol = tex2D(_MainTex, i.uv);
                return texcol * _Color;
            }
            ENDCG
        }

        // Outline pass
        Pass
        {
            Name "OUTLINE"
            Blend SrcAlpha OneMinusSrcAlpha
            ZWrite On
            Cull Front
            Lighting Off

            CGPROGRAM
            #pragma vertex vertOutline
            #pragma fragment fragOutline
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

            v2f vertOutline (appdata v)
            {
                // Apply outline offset
                v2f o;
                float3 norm = mul((float3x3)UNITY_MATRIX_IT_MV, v.normal);
                float3 offset = norm * _OutlineThickness;
                v.vertex.xyz += offset;
                o.pos = UnityObjectToClipPos(v.vertex);
                o.color = _OutlineColor;
                return o;
            }

            fixed4 fragOutline (v2f i) : SV_Target
            {
                return i.color;
            }
            ENDCG
        }
    }
    FallBack "Unlit/Texture"
}
