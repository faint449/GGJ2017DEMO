// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'

// Shader created with Shader Forge v1.26 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.26;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:1,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:False,qofs:0,qpre:2,rntp:3,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False;n:type:ShaderForge.SFN_Final,id:4013,x:33294,y:32549,varname:node_4013,prsc:2|diff-3493-OUT,emission-594-OUT,clip-1104-A;n:type:ShaderForge.SFN_Tex2d,id:1104,x:32112,y:32639,ptovrint:False,ptlb:MainTex,ptin:_MainTex,varname:node_1104,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Time,id:6329,x:31524,y:33246,varname:node_6329,prsc:2;n:type:ShaderForge.SFN_Slider,id:2149,x:31367,y:33404,ptovrint:False,ptlb:GlowFrequency,ptin:_GlowFrequency,varname:node_7026,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.5,max:5;n:type:ShaderForge.SFN_Sin,id:2647,x:31915,y:33325,varname:node_2647,prsc:2|IN-6815-OUT;n:type:ShaderForge.SFN_Multiply,id:6815,x:31745,y:33325,varname:node_6815,prsc:2|A-6329-T,B-2149-OUT;n:type:ShaderForge.SFN_Multiply,id:7898,x:32459,y:32977,varname:node_7898,prsc:2|A-1104-RGB,B-4338-RGB,C-3331-OUT;n:type:ShaderForge.SFN_Tex2d,id:4338,x:32121,y:32935,ptovrint:False,ptlb:GlowMaskTex,ptin:_GlowMaskTex,varname:node_640,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_OneMinus,id:8813,x:32348,y:32816,varname:node_8813,prsc:2|IN-4338-RGB;n:type:ShaderForge.SFN_Multiply,id:5516,x:32505,y:32648,varname:node_5516,prsc:2|A-1104-RGB,B-8813-OUT;n:type:ShaderForge.SFN_ConstantLerp,id:3331,x:32105,y:33325,varname:node_3331,prsc:2,a:1.7,b:3|IN-2647-OUT;n:type:ShaderForge.SFN_Fresnel,id:5164,x:32687,y:33267,varname:node_5164,prsc:2|EXP-2448-OUT;n:type:ShaderForge.SFN_ToggleProperty,id:5218,x:32687,y:33610,ptovrint:False,ptlb:RimOn,ptin:_RimOn,varname:_RimOn,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,on:True;n:type:ShaderForge.SFN_Multiply,id:7014,x:32892,y:33347,varname:node_7014,prsc:2|A-5164-OUT,B-1558-OUT,C-5218-OUT;n:type:ShaderForge.SFN_Vector1,id:2448,x:32494,y:33285,varname:node_2448,prsc:2,v1:3;n:type:ShaderForge.SFN_Color,id:7392,x:32480,y:33415,ptovrint:False,ptlb:RimColor,ptin:_RimColor,varname:_RimColor_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_Add,id:594,x:32996,y:32975,varname:node_594,prsc:2|A-7898-OUT,B-7014-OUT;n:type:ShaderForge.SFN_Vector1,id:725,x:32480,y:33590,varname:node_725,prsc:2,v1:2;n:type:ShaderForge.SFN_Multiply,id:1558,x:32687,y:33415,varname:node_1558,prsc:2|A-7392-RGB,B-725-OUT;n:type:ShaderForge.SFN_Color,id:5329,x:32773,y:32662,ptovrint:False,ptlb:FlashColor,ptin:_FlashColor,varname:node_5329,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_ValueProperty,id:7096,x:32773,y:32846,ptovrint:False,ptlb:FlashIntensity,ptin:_FlashIntensity,varname:node_7096,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0;n:type:ShaderForge.SFN_Lerp,id:3493,x:33001,y:32545,varname:node_3493,prsc:2|A-5516-OUT,B-5329-RGB,T-7096-OUT;proporder:5218-7392-1104-4338-2149-5329-7096;pass:END;sub:END;*/

Shader "Zealot_Art/Diffuse(AlphaTesting)_GlowMask_Rim" {
    Properties {
        [MaterialToggle] _RimOn ("RimOn", Float ) = 1
        _RimColor ("RimColor", Color) = (1,1,1,1)
        _MainTex ("MainTex", 2D) = "white" {}
        _GlowMaskTex ("GlowMaskTex", 2D) = "white" {}
        _GlowFrequency ("GlowFrequency", Range(0, 5)) = 0.5
        _FlashColor ("FlashColor", Color) = (1,1,1,1)
        _FlashIntensity ("FlashIntensity", Float ) = 0
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
    }
    SubShader {
        Tags {
            "Queue"="AlphaTest"
            "RenderType"="TransparentCutout"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma multi_compile_fog
            #pragma exclude_renderers d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform float4 _LightColor0;
            uniform float4 _TimeEditor;
            uniform sampler2D _MainTex; uniform float4 _MainTex_ST;
            uniform float _GlowFrequency;
            uniform sampler2D _GlowMaskTex; uniform float4 _GlowMaskTex_ST;
            uniform fixed _RimOn;
            uniform float4 _RimColor;
            uniform float4 _FlashColor;
            uniform float _FlashIntensity;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                LIGHTING_COORDS(3,4)
                UNITY_FOG_COORDS(5)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                float4 _MainTex_var = tex2D(_MainTex,TRANSFORM_TEX(i.uv0, _MainTex));
                clip(_MainTex_var.a - 0.5);
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
                float3 lightColor = _LightColor0.rgb;
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
/////// Diffuse:
                float NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 directDiffuse = max( 0.0, NdotL) * attenColor;
                float3 indirectDiffuse = float3(0,0,0);
                indirectDiffuse += UNITY_LIGHTMODEL_AMBIENT.rgb; // Ambient Light
                float4 _GlowMaskTex_var = tex2D(_GlowMaskTex,TRANSFORM_TEX(i.uv0, _GlowMaskTex));
                float3 diffuseColor = lerp((_MainTex_var.rgb*(1.0 - _GlowMaskTex_var.rgb)),_FlashColor.rgb,_FlashIntensity);
                float3 diffuse = (directDiffuse + indirectDiffuse) * diffuseColor;
////// Emissive:
                float4 node_6329 = _Time + _TimeEditor;
                float3 emissive = ((_MainTex_var.rgb*_GlowMaskTex_var.rgb*lerp(1.7,3,sin((node_6329.g*_GlowFrequency))))+(pow(1.0-max(0,dot(normalDirection, viewDirection)),3.0)*(_RimColor.rgb*2.0)*_RimOn));
/// Final Color:
                float3 finalColor = diffuse + emissive;
                fixed4 finalRGBA = fixed4(finalColor,1);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
        Pass {
            Name "FORWARD_DELTA"
            Tags {
                "LightMode"="ForwardAdd"
            }
            Blend One One
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDADD
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #pragma multi_compile_fwdadd_fullshadows
            #pragma multi_compile_fog
            #pragma exclude_renderers d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform float4 _LightColor0;
            uniform float4 _TimeEditor;
            uniform sampler2D _MainTex; uniform float4 _MainTex_ST;
            uniform float _GlowFrequency;
            uniform sampler2D _GlowMaskTex; uniform float4 _GlowMaskTex_ST;
            uniform fixed _RimOn;
            uniform float4 _RimColor;
            uniform float4 _FlashColor;
            uniform float _FlashIntensity;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                LIGHTING_COORDS(3,4)
                UNITY_FOG_COORDS(5)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                float4 _MainTex_var = tex2D(_MainTex,TRANSFORM_TEX(i.uv0, _MainTex));
                clip(_MainTex_var.a - 0.5);
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
                float3 lightColor = _LightColor0.rgb;
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
/////// Diffuse:
                float NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 directDiffuse = max( 0.0, NdotL) * attenColor;
                float4 _GlowMaskTex_var = tex2D(_GlowMaskTex,TRANSFORM_TEX(i.uv0, _GlowMaskTex));
                float3 diffuseColor = lerp((_MainTex_var.rgb*(1.0 - _GlowMaskTex_var.rgb)),_FlashColor.rgb,_FlashIntensity);
                float3 diffuse = directDiffuse * diffuseColor;
/// Final Color:
                float3 finalColor = diffuse;
                fixed4 finalRGBA = fixed4(finalColor * 1,0);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
        Pass {
            Name "ShadowCaster"
            Tags {
                "LightMode"="ShadowCaster"
            }
            Offset 1, 1
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_SHADOWCASTER
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma multi_compile_fog
            #pragma exclude_renderers d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform sampler2D _MainTex; uniform float4 _MainTex_ST;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                V2F_SHADOW_CASTER;
                float2 uv0 : TEXCOORD1;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex );
                TRANSFER_SHADOW_CASTER(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                float4 _MainTex_var = tex2D(_MainTex,TRANSFORM_TEX(i.uv0, _MainTex));
                clip(_MainTex_var.a - 0.5);
                SHADOW_CASTER_FRAGMENT(i)
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
