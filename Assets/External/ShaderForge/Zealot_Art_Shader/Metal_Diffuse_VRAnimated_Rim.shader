// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'

// Shader created with Shader Forge v1.26 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.26;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:1,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False;n:type:ShaderForge.SFN_Final,id:4013,x:33335,y:33224,varname:node_4013,prsc:2|diff-8423-OUT,emission-3692-OUT;n:type:ShaderForge.SFN_Tex2d,id:7499,x:31646,y:33714,ptovrint:False,ptlb:VRAnimatedTex,ptin:_VRAnimatedTex,varname:_VRMetalAnimatedTex,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False|UVIN-6102-OUT;n:type:ShaderForge.SFN_TexCoord,id:1428,x:30967,y:33840,varname:node_1428,prsc:2,uv:1;n:type:ShaderForge.SFN_Add,id:6102,x:31462,y:33714,varname:node_6102,prsc:2|A-2641-OUT,B-8781-OUT;n:type:ShaderForge.SFN_Panner,id:4022,x:31130,y:33840,varname:node_4022,prsc:2,spu:0.1,spv:0|UVIN-1428-UVOUT;n:type:ShaderForge.SFN_Multiply,id:2641,x:31300,y:33531,varname:node_2641,prsc:2|A-5695-RGB,B-7221-OUT,C-1696-OUT;n:type:ShaderForge.SFN_Slider,id:1696,x:30879,y:33688,ptovrint:False,ptlb:VRQuantity,ptin:_VRQuantity,varname:_VRQuantity,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.5,max:5;n:type:ShaderForge.SFN_Multiply,id:8608,x:32037,y:33751,varname:node_8608,prsc:2|A-7499-RGB,B-8376-OUT;n:type:ShaderForge.SFN_Tex2d,id:5695,x:32315,y:33347,ptovrint:False,ptlb:MainTex,ptin:_MainTex,varname:_DiffuseTexVRMask,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Color,id:8070,x:31646,y:33959,ptovrint:False,ptlb:VRColor,ptin:_VRColor,varname:_VRColor,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:1,c3:1,c4:0.991;n:type:ShaderForge.SFN_ViewReflectionVector,id:7221,x:31036,y:33550,varname:node_7221,prsc:2;n:type:ShaderForge.SFN_Fresnel,id:5269,x:32025,y:34439,varname:node_5269,prsc:2|EXP-583-OUT;n:type:ShaderForge.SFN_Color,id:8433,x:31816,y:34597,ptovrint:False,ptlb:RimColor,ptin:_RimColor,varname:_RimColor,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_Multiply,id:8376,x:31857,y:33959,varname:node_8376,prsc:2|A-8070-RGB,B-583-OUT;n:type:ShaderForge.SFN_Multiply,id:5249,x:32262,y:34478,varname:node_5249,prsc:2|A-5269-OUT,B-8433-RGB,C-9034-OUT;n:type:ShaderForge.SFN_Vector1,id:583,x:31664,y:34506,varname:node_583,prsc:2,v1:3;n:type:ShaderForge.SFN_ToggleProperty,id:9034,x:31816,y:34763,ptovrint:False,ptlb:RimOn,ptin:_RimOn,varname:node_9034,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,on:True;n:type:ShaderForge.SFN_Multiply,id:8781,x:31300,y:33939,varname:node_8781,prsc:2|A-4022-UVOUT,B-4189-OUT;n:type:ShaderForge.SFN_ToggleProperty,id:4189,x:31130,y:34041,ptovrint:False,ptlb:VRAnimatedOn,ptin:_VRAnimatedOn,varname:node_4189,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,on:True;n:type:ShaderForge.SFN_Color,id:6221,x:32501,y:33696,ptovrint:False,ptlb:FlashColor,ptin:_FlashColor,varname:node_6221,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_ValueProperty,id:5826,x:32501,y:33878,ptovrint:False,ptlb:FlashIntensity,ptin:_FlashIntensity,varname:node_5826,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0;n:type:ShaderForge.SFN_Add,id:3692,x:32802,y:34197,varname:node_3692,prsc:2|A-8608-OUT,B-5249-OUT;n:type:ShaderForge.SFN_Multiply,id:8423,x:32759,y:33578,varname:node_8423,prsc:2|A-6221-RGB,B-5826-OUT;proporder:9034-8433-5695-7499-4189-8070-1696-6221-5826;pass:END;sub:END;*/

Shader "Zealot_Art/Special/Metal_Diffuse_VRAnimated_Rim" {
    Properties {
        [MaterialToggle] _RimOn ("RimOn", Float ) = 1
        _RimColor ("RimColor", Color) = (0.5,0.5,0.5,1)
        _MainTex ("MainTex", 2D) = "white" {}
        _VRAnimatedTex ("VRAnimatedTex", 2D) = "white" {}
        [MaterialToggle] _VRAnimatedOn ("VRAnimatedOn", Float ) = 1
        _VRColor ("VRColor", Color) = (1,1,1,0.991)
        _VRQuantity ("VRQuantity", Range(0, 5)) = 0.5
        _FlashColor ("FlashColor", Color) = (1,1,1,1)
        _FlashIntensity ("FlashIntensity", Float ) = 0
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
            uniform sampler2D _VRAnimatedTex; uniform float4 _VRAnimatedTex_ST;
            uniform float _VRQuantity;
            uniform sampler2D _MainTex; uniform float4 _MainTex_ST;
            uniform float4 _VRColor;
            uniform float4 _RimColor;
            uniform fixed _RimOn;
            uniform fixed _VRAnimatedOn;
            uniform float4 _FlashColor;
            uniform float _FlashIntensity;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord0 : TEXCOORD0;
                float2 texcoord1 : TEXCOORD1;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float2 uv1 : TEXCOORD1;
                float4 posWorld : TEXCOORD2;
                float3 normalDir : TEXCOORD3;
                LIGHTING_COORDS(4,5)
                UNITY_FOG_COORDS(6)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.uv1 = v.texcoord1;
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
                float3 viewReflectDirection = reflect( -viewDirection, normalDirection );
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
                float3 diffuseColor = (_FlashColor.rgb*_FlashIntensity);
                float3 diffuse = (directDiffuse + indirectDiffuse) * diffuseColor;
////// Emissive:
                float4 _MainTex_var = tex2D(_MainTex,TRANSFORM_TEX(i.uv0, _MainTex));
                float4 node_3826 = _Time + _TimeEditor;
                float3 node_6102 = ((_MainTex_var.rgb*viewReflectDirection*_VRQuantity)+float3(((i.uv1+node_3826.g*float2(0.1,0))*_VRAnimatedOn),0.0));
                float4 _VRAnimatedTex_var = tex2D(_VRAnimatedTex,TRANSFORM_TEX(node_6102, _VRAnimatedTex));
                float node_583 = 3.0;
                float3 emissive = ((_VRAnimatedTex_var.rgb*(_VRColor.rgb*node_583))+(pow(1.0-max(0,dot(normalDirection, viewDirection)),node_583)*_RimColor.rgb*_RimOn));
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
            uniform sampler2D _VRAnimatedTex; uniform float4 _VRAnimatedTex_ST;
            uniform float _VRQuantity;
            uniform sampler2D _MainTex; uniform float4 _MainTex_ST;
            uniform float4 _VRColor;
            uniform float4 _RimColor;
            uniform fixed _RimOn;
            uniform fixed _VRAnimatedOn;
            uniform float4 _FlashColor;
            uniform float _FlashIntensity;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord0 : TEXCOORD0;
                float2 texcoord1 : TEXCOORD1;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float2 uv1 : TEXCOORD1;
                float4 posWorld : TEXCOORD2;
                float3 normalDir : TEXCOORD3;
                LIGHTING_COORDS(4,5)
                UNITY_FOG_COORDS(6)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.uv1 = v.texcoord1;
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
                float3 viewReflectDirection = reflect( -viewDirection, normalDirection );
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
                float3 lightColor = _LightColor0.rgb;
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
/////// Diffuse:
                float NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 directDiffuse = max( 0.0, NdotL) * attenColor;
                float3 diffuseColor = (_FlashColor.rgb*_FlashIntensity);
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
