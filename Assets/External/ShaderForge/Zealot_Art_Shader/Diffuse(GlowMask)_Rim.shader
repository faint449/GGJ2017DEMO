// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'

// Shader created with Shader Forge v1.26 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.26;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:1,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False;n:type:ShaderForge.SFN_Final,id:4013,x:32719,y:32712,varname:node_4013,prsc:2|diff-6345-RGB,emission-3919-OUT;n:type:ShaderForge.SFN_Tex2d,id:6345,x:31794,y:32722,ptovrint:False,ptlb:DiffuseTex(GlowMask),ptin:_DiffuseTexGlowMask,varname:node_5820,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Time,id:9401,x:31396,y:33118,varname:node_9401,prsc:2;n:type:ShaderForge.SFN_Slider,id:4438,x:31239,y:33276,ptovrint:False,ptlb:GlowFrequency,ptin:_GlowFrequency,varname:node_7026,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.5,max:5;n:type:ShaderForge.SFN_Sin,id:5262,x:31787,y:33197,varname:node_5262,prsc:2|IN-8492-OUT;n:type:ShaderForge.SFN_Multiply,id:8492,x:31617,y:33197,varname:node_8492,prsc:2|A-9401-T,B-4438-OUT;n:type:ShaderForge.SFN_Multiply,id:5083,x:32131,y:32858,varname:node_5083,prsc:2|A-6345-RGB,B-6345-A,C-4256-OUT;n:type:ShaderForge.SFN_ConstantLerp,id:4256,x:31969,y:33197,varname:node_4256,prsc:2,a:1.7,b:3|IN-5262-OUT;n:type:ShaderForge.SFN_Add,id:3919,x:32472,y:33241,varname:node_3919,prsc:2|A-5083-OUT,B-2956-OUT;n:type:ShaderForge.SFN_Fresnel,id:178,x:32069,y:33398,varname:node_178,prsc:2|EXP-2898-OUT;n:type:ShaderForge.SFN_ToggleProperty,id:9515,x:32069,y:33741,ptovrint:False,ptlb:RimOn,ptin:_RimOn,varname:_RimOn,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,on:True;n:type:ShaderForge.SFN_Multiply,id:2956,x:32274,y:33478,varname:node_2956,prsc:2|A-178-OUT,B-8436-OUT,C-9515-OUT;n:type:ShaderForge.SFN_Vector1,id:2898,x:31876,y:33418,varname:node_2898,prsc:2,v1:3;n:type:ShaderForge.SFN_Color,id:2749,x:31860,y:33543,ptovrint:False,ptlb:RimColor,ptin:_RimColor,varname:_RimColor_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_Vector1,id:8744,x:31860,y:33689,varname:node_8744,prsc:2,v1:2;n:type:ShaderForge.SFN_Multiply,id:8436,x:32069,y:33562,varname:node_8436,prsc:2|A-2749-RGB,B-8744-OUT;proporder:9515-2749-6345-4438;pass:END;sub:END;*/

Shader "Zealot_Art/Diffuse(GlowMask)_Rim" {
    Properties {
        [MaterialToggle] _RimOn ("RimOn", Float ) = 1
        _RimColor ("RimColor", Color) = (1,1,1,1)
        _DiffuseTexGlowMask ("DiffuseTex(GlowMask)", 2D) = "white" {}
        _GlowFrequency ("GlowFrequency", Range(0, 5)) = 0.5
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
            uniform sampler2D _DiffuseTexGlowMask; uniform float4 _DiffuseTexGlowMask_ST;
            uniform float _GlowFrequency;
            uniform fixed _RimOn;
            uniform float4 _RimColor;
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
                o.pos = UnityObjectToClipPos(v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
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
                float4 _DiffuseTexGlowMask_var = tex2D(_DiffuseTexGlowMask,TRANSFORM_TEX(i.uv0, _DiffuseTexGlowMask));
                float3 diffuseColor = _DiffuseTexGlowMask_var.rgb;
                float3 diffuse = (directDiffuse + indirectDiffuse) * diffuseColor;
////// Emissive:
                float4 node_9401 = _Time + _TimeEditor;
                float3 emissive = ((_DiffuseTexGlowMask_var.rgb*_DiffuseTexGlowMask_var.a*lerp(1.7,3,sin((node_9401.g*_GlowFrequency))))+(pow(1.0-max(0,dot(normalDirection, viewDirection)),3.0)*(_RimColor.rgb*2.0)*_RimOn));
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
            uniform sampler2D _DiffuseTexGlowMask; uniform float4 _DiffuseTexGlowMask_ST;
            uniform float _GlowFrequency;
            uniform fixed _RimOn;
            uniform float4 _RimColor;
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
                o.pos = UnityObjectToClipPos(v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
                float3 lightColor = _LightColor0.rgb;
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
/////// Diffuse:
                float NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 directDiffuse = max( 0.0, NdotL) * attenColor;
                float4 _DiffuseTexGlowMask_var = tex2D(_DiffuseTexGlowMask,TRANSFORM_TEX(i.uv0, _DiffuseTexGlowMask));
                float3 diffuseColor = _DiffuseTexGlowMask_var.rgb;
                float3 diffuse = directDiffuse * diffuseColor;
/// Final Color:
                float3 finalColor = diffuse;
                fixed4 finalRGBA = fixed4(finalColor * 1,0);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
