Shader "Unlit/Dissolve"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _DissolveMap ("Texture", 2D) = "white" {}
        _Decay ("Decay", Range(0, 1)) = 0
        _DecayColor ("Decay Color", Color) = (1, 1, 1, 1)
    }
    SubShader
    {
        Tags {"Queue" = "Transparent" "RenderType"="Transparent" }
        LOD 100

        Pass
        {
            Blend SrcAlpha OneMinusSrcAlpha
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            // make fog work
            #pragma multi_compile_fog

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                UNITY_FOG_COORDS(1)
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            sampler2D _DissolveMap;
            float4 _MainTex_ST;
            float _Decay;
            fixed4 _DecayColor;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                UNITY_TRANSFER_FOG(o,o.vertex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                // sample the texture
                fixed4 mainCol = tex2D(_MainTex, i.uv);
                fixed4 mapCol = tex2D(_DissolveMap, i.uv);
                float sampleBrightness = 0.299 * mapCol.x + 0.587 * mapCol.y + 0.114 * mapCol.z;
                fixed4 col;
                if (sampleBrightness < _Decay)
                {
                    col = mainCol;
                }
                else
                {
                    col = _DecayColor;
                }
                
                UNITY_APPLY_FOG(i.fogCoord, col);
                return col;
            }
            ENDCG
        }
    }
}
