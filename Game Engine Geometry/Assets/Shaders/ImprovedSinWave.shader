// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'

// Shader created with Shader Forge v1.42 
// Shader Forge (c) Freya Holmer - http://www.acegikmo.com/shaderforge/
// Enhanced by Antoine Guillon / Arkham Development - http://www.arkham-development.com/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.42;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:2,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:3138,x:32674,y:32720,varname:node_3138,prsc:2|emission-6200-RGB,voffset-9131-OUT;n:type:ShaderForge.SFN_Vector3,id:6008,x:33062,y:33024,varname:node_6008,prsc:2,v1:0.5,v2:0.5,v3:0;n:type:ShaderForge.SFN_Time,id:666,x:31594,y:32988,varname:node_666,prsc:2;n:type:ShaderForge.SFN_Vector1,id:2061,x:31959,y:32896,varname:node_2061,prsc:2,v1:0;n:type:ShaderForge.SFN_Sin,id:2356,x:31959,y:33022,varname:node_2356,prsc:2|IN-9949-OUT;n:type:ShaderForge.SFN_Append,id:508,x:32240,y:33010,varname:node_508,prsc:2|A-2061-OUT,B-2356-OUT,C-2660-OUT;n:type:ShaderForge.SFN_Vector1,id:2660,x:31959,y:33292,varname:node_2660,prsc:2,v1:0;n:type:ShaderForge.SFN_Add,id:9949,x:31796,y:33044,varname:node_9949,prsc:2|A-666-T,B-1015-OUT,C-4018-OUT;n:type:ShaderForge.SFN_FragmentPosition,id:1206,x:31400,y:33161,varname:node_1206,prsc:2;n:type:ShaderForge.SFN_ValueProperty,id:9233,x:32240,y:33202,ptovrint:False,ptlb:Height,ptin:_Height,varname:node_9233,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;n:type:ShaderForge.SFN_Multiply,id:9131,x:32458,y:33055,varname:node_9131,prsc:2|A-508-OUT,B-9233-OUT;n:type:ShaderForge.SFN_Tex2d,id:6200,x:32233,y:32712,ptovrint:False,ptlb:MainTexture,ptin:_MainTexture,varname:node_6200,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Multiply,id:1015,x:31594,y:33126,varname:node_1015,prsc:2|A-1206-X,B-993-OUT;n:type:ShaderForge.SFN_ValueProperty,id:993,x:31400,y:33305,ptovrint:False,ptlb:PhaseScale,ptin:_PhaseScale,varname:node_993,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0;n:type:ShaderForge.SFN_Multiply,id:4018,x:31594,y:33251,varname:node_4018,prsc:2|A-1206-Z,B-993-OUT;proporder:6200-9233-993;pass:END;sub:END;*/

Shader "Custom/ShaderForge0" {
    Properties {
        _MainTexture ("MainTexture", 2D) = "white" {}
        _Height ("Height", Float ) = 1
        _PhaseScale ("PhaseScale", Float ) = 0
    }
    SubShader {
        Tags {
            "RenderType"="Opaque"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            Cull Off
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #ifndef UNITY_PASS_FORWARDBASE
            #define UNITY_PASS_FORWARDBASE
            #endif //UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma only_renderers d3d9 d3d11 glcore gles gles3 metal d3d11_9x xboxone ps4 psp2 n3ds wiiu switch vulkan 
            #pragma target 3.0
            uniform float _Height;
            uniform sampler2D _MainTexture; uniform float4 _MainTexture_ST;
            uniform float _PhaseScale;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                float4 node_666 = _Time;
                v.vertex.xyz += (float3(0.0,sin((node_666.g+(mul(unity_ObjectToWorld, v.vertex).r*_PhaseScale)+(mul(unity_ObjectToWorld, v.vertex).b*_PhaseScale))),0.0)*_Height);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = UnityObjectToClipPos( v.vertex );
                return o;
            }
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
////// Lighting:
////// Emissive:
                float4 _MainTexture_var = tex2D(_MainTexture,TRANSFORM_TEX(i.uv0, _MainTexture));
                float3 emissive = _MainTexture_var.rgb;
                float3 finalColor = emissive;
                return fixed4(finalColor,1);
            }
            ENDCG
        }
        Pass {
            Name "ShadowCaster"
            Tags {
                "LightMode"="ShadowCaster"
            }
            Offset 1, 1
            Cull Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #ifndef UNITY_PASS_SHADOWCASTER
            #define UNITY_PASS_SHADOWCASTER
            #endif //UNITY_PASS_SHADOWCASTER
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma only_renderers d3d9 d3d11 glcore gles gles3 metal d3d11_9x xboxone ps4 psp2 n3ds wiiu switch vulkan 
            #pragma target 3.0
            uniform float _Height;
            uniform float _PhaseScale;
            struct VertexInput {
                float4 vertex : POSITION;
            };
            struct VertexOutput {
                V2F_SHADOW_CASTER;
                float4 posWorld : TEXCOORD1;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                float4 node_666 = _Time;
                v.vertex.xyz += (float3(0.0,sin((node_666.g+(mul(unity_ObjectToWorld, v.vertex).r*_PhaseScale)+(mul(unity_ObjectToWorld, v.vertex).b*_PhaseScale))),0.0)*_Height);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = UnityObjectToClipPos( v.vertex );
                TRANSFER_SHADOW_CASTER(o)
                return o;
            }
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
                SHADOW_CASTER_FRAGMENT(i)
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
