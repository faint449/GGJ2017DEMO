// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'

// Shader created with Shader Forge v1.26 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.26;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:1,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False;n:type:ShaderForge.SFN_Final,id:4013,x:33324,y:33625,varname:node_4013,prsc:2|emission-4309-OUT;n:type:ShaderForge.SFN_Tex2d,id:7499,x:32187,y:33609,ptovrint:False,ptlb:VRAnimatedTex,ptin:_VRAnimatedTex,varname:_VRMetalAnimatedTex,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False|UVIN-6102-OUT;n:type:ShaderForge.SFN_TexCoord,id:1428,x:31433,y:33781,varname:node_1428,prsc:2,uv:1;n:type:ShaderForge.SFN_Add,id:6102,x:31918,y:33603,varname:node_6102,prsc:2|A-2641-OUT,B-4787-OUT;n:type:ShaderForge.SFN_Panner,id:4022,x:31596,y:33781,varname:node_4022,prsc:2,spu:0.2,spv:0|UVIN-1428-UVOUT;n:type:ShaderForge.SFN_Multiply,id:2641,x:31830,y:33426,varname:node_2641,prsc:2|A-5695-RGB,B-7221-OUT,C-1696-OUT;n:type:ShaderForge.SFN_Slider,id:1696,x:31409,y:33583,ptovrint:False,ptlb:VRQuantity,ptin:_VRQuantity,varname:_VRQuantity,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.5,max:5;n:type:ShaderForge.SFN_Tex2d,id:5695,x:32184,y:33129,ptovrint:False,ptlb:MainTex,ptin:_MainTex,varname:_DiffuseTexVRMask,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Color,id:8070,x:32187,y:33840,ptovrint:False,ptlb:VRColor,ptin:_VRColor,varname:_VRColor,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:1,c3:1,c4:0.991;n:type:ShaderForge.SFN_ViewReflectionVector,id:7221,x:31566,y:33445,varname:node_7221,prsc:2;n:type:ShaderForge.SFN_Fresnel,id:5269,x:32560,y:34556,varname:node_5269,prsc:2|EXP-4575-OUT;n:type:ShaderForge.SFN_Vector1,id:4575,x:32355,y:34701,varname:node_4575,prsc:2,v1:2;n:type:ShaderForge.SFN_Color,id:8433,x:32544,y:34762,ptovrint:False,ptlb:RimColor,ptin:_RimColor,varname:_RimColor,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_Multiply,id:7136,x:32823,y:34630,varname:node_7136,prsc:2|A-5269-OUT,B-8433-RGB,C-5087-OUT;n:type:ShaderForge.SFN_Multiply,id:428,x:32769,y:33706,varname:node_428,prsc:2|A-7499-RGB,B-306-OUT,C-8070-RGB;n:type:ShaderForge.SFN_Add,id:4309,x:33124,y:33717,varname:node_4309,prsc:2|A-428-OUT,B-7136-OUT,C-5695-RGB,D-7793-OUT;n:type:ShaderForge.SFN_Slider,id:306,x:32333,y:34045,ptovrint:False,ptlb:VRTransparency,ptin:_VRTransparency,varname:node_306,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:2;n:type:ShaderForge.SFN_ToggleProperty,id:5087,x:32544,y:34949,ptovrint:False,ptlb:RimOn,ptin:_RimOn,varname:node_5087,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,on:False;n:type:ShaderForge.SFN_Multiply,id:7793,x:32789,y:33128,varname:node_7793,prsc:2|A-5695-RGB,B-9355-OUT;n:type:ShaderForge.SFN_Multiply,id:4787,x:31765,y:33806,varname:node_4787,prsc:2|A-4022-UVOUT,B-8283-OUT;n:type:ShaderForge.SFN_Slider,id:8283,x:31499,y:33977,ptovrint:False,ptlb:VRSpeed,ptin:_VRSpeed,varname:node_8283,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:-2,cur:0,max:2;n:type:ShaderForge.SFN_Vector1,id:9355,x:32575,y:33210,varname:node_9355,prsc:2,v1:-0.2;proporder:5087-8433-5695-7499-8070-306-1696-8283;pass:END;sub:END;*/

Shader "Zealot_Art/Special/Emission_VRAnimated_Rim" {
    Properties {
        [MaterialToggle] _RimOn ("RimOn", Float ) = 0
        _RimColor ("RimColor", Color) = (0.5,0.5,0.5,1)
        _MainTex ("MainTex", 2D) = "white" {}
        _VRAnimatedTex ("VRAnimatedTex", 2D) = "white" {}
        _VRColor ("VRColor", Color) = (1,1,1,0.991)
        _VRTransparency ("VRTransparency", Range(0, 2)) = 0
        _VRQuantity ("VRQuantity", Range(0, 5)) = 0.5
        _VRSpeed ("VRSpeed", Range(-2, 2)) = 0
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
            #pragma multi_compile_fwdbase_fullshadows
            #pragma multi_compile_fog
            #pragma exclude_renderers d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform float4 _TimeEditor;
            uniform sampler2D _VRAnimatedTex; uniform float4 _VRAnimatedTex_ST;
            uniform float _VRQuantity;
            uniform sampler2D _MainTex; uniform float4 _MainTex_ST;
            uniform float4 _VRColor;
            uniform float4 _RimColor;
            uniform float _VRTransparency;
            uniform fixed _RimOn;
            uniform float _VRSpeed;
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
                UNITY_FOG_COORDS(4)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.uv1 = v.texcoord1;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = UnityObjectToClipPos(v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                float3 viewReflectDirection = reflect( -viewDirection, normalDirection );
////// Lighting:
////// Emissive:
                float4 _MainTex_var = tex2D(_MainTex,TRANSFORM_TEX(i.uv0, _MainTex));
                float4 node_8249 = _Time + _TimeEditor;
                float3 node_6102 = ((_MainTex_var.rgb*viewReflectDirection*_VRQuantity)+float3(((i.uv1+node_8249.g*float2(0.2,0))*_VRSpeed),0.0));
                float4 _VRAnimatedTex_var = tex2D(_VRAnimatedTex,TRANSFORM_TEX(node_6102, _VRAnimatedTex));
                float3 emissive = ((_VRAnimatedTex_var.rgb*_VRTransparency*_VRColor.rgb)+(pow(1.0-max(0,dot(normalDirection, viewDirection)),2.0)*_RimColor.rgb*_RimOn)+_MainTex_var.rgb+(_MainTex_var.rgb*(-0.2)));
                float3 finalColor = emissive;
                fixed4 finalRGBA = fixed4(finalColor,1);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
