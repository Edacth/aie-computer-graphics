Shader "Custom/Screen Space" {
    Properties {
        _MainTex ("Texture", 2D) = "white" {}
        _Detail ("Detail", 2D) = "grey" {}
    }
    SubShader {
      Tags { "RenderType" = "Opaque" }
      CGPROGRAM
      #pragma surface surf SimpleLambert
      struct Input {
          float2 uv_MainTex;
          float4 screenPos;
      };
      sampler2D _MainTex;
      sampler2D _Detail;
      void surf (Input IN, inout SurfaceOutput o) {
          o.Albedo = tex2D (_MainTex, IN.uv_MainTex).rgb;
          float2 screenUV = IN.screenPos.xy / IN.screenPos.w;
          screenUV *= float2(8, 6);
          o.Albedo *= tex2D (_Detail, screenUV).rgb * 2;
      }

      half4 LightingSimpleLambert(SurfaceOutput s, fixed3 lightDir, fixed atten)
      {
          //half NdotL = dot (s.Normal, lightDir);
          half4 c;
          c.rgb = s.Albedo * _LightColor0.rgb * (0.4);
          c.a = s.Alpha;
          return c;
      }
      ENDCG
    }
    Fallback "Diffuse"
  }