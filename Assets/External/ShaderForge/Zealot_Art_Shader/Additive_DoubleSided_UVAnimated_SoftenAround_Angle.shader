// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'

// Shader created with Shader Forge v1.26 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.26;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:3,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:2,bsrc:0,bdst:0,dpts:2,wrdp:False,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:True,fgod:False,fgor:False,fgmd:0,fgcr:0,fgcg:0,fgcb:0,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False;n:type:ShaderForge.SFN_Final,id:4013,x:32823,y:32774,varname:node_4013,prsc:2|emission-1655-OUT;n:type:ShaderForge.SFN_Panner,id:3188,x:31989,y:32610,varname:node_3188,prsc:2,spu:0,spv:-0.2|UVIN-4893-UVOUT,DIST-1339-OUT;n:type:ShaderForge.SFN_TexCoord,id:6687,x:31219,y:32602,varname:node_6687,prsc:2,uv:0;n:type:ShaderForge.SFN_Time,id:8454,x:31662,y:32635,varname:node_8454,prsc:2;n:type:ShaderForge.SFN_Slider,id:5129,x:31497,y:32790,ptovrint:False,ptlb:UVSpeed,ptin:_UVSpeed,varname:node_9088,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:-10,cur:1,max:10;n:type:ShaderForge.SFN_Multiply,id:1339,x:31832,y:32685,varname:node_1339,prsc:2|A-8454-T,B-5129-OUT;n:type:ShaderForge.SFN_Distance,id:4908,x:31722,y:33213,varname:node_4908,prsc:2|A-6687-UVOUT,B-7129-OUT;n:type:ShaderForge.SFN_Vector2,id:7129,x:31524,y:33256,varname:node_7129,prsc:2,v1:0.5,v2:0.5;n:type:ShaderForge.SFN_Color,id:8182,x:32033,y:32790,ptovrint:False,ptlb:EmissionColor,ptin:_EmissionColor,varname:node_8182,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.4852941,c2:0.4049696,c3:0,c4:1;n:type:ShaderForge.SFN_Multiply,id:1655,x:32575,y:32871,varname:node_1655,prsc:2|A-3760-RGB,B-7544-OUT,C-4792-OUT;n:type:ShaderForge.SFN_Tex2d,id:3760,x:32207,y:32610,ptovrint:False,ptlb:UVAnimatedTex,ptin:_UVAnimatedTex,varname:node_3760,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False|UVIN-3188-UVOUT;n:type:ShaderForge.SFN_ConstantLerp,id:4792,x:31920,y:33213,varname:node_4792,prsc:2,a:1,b:-1|IN-4908-OUT;n:type:ShaderForge.SFN_Multiply,id:7544,x:32207,y:32822,varname:node_7544,prsc:2|A-8182-RGB,B-3146-OUT;n:type:ShaderForge.SFN_Vector1,id:3146,x:32033,y:32938,varname:node_3146,prsc:2,v1:5;n:type:ShaderForge.SFN_Rotator,id:4893,x:31662,y:32457,varname:node_4893,prsc:2|UVIN-6687-UVOUT,ANG-2352-OUT;n:type:ShaderForge.SFN_Slider,id:2352,x:31247,y:32498,ptovrint:False,ptlb:Angle,ptin:_Angle,varname:node_2352,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:7;proporder:3760-8182-5129-2352;pass:END;sub:END;*/

Shader "Zealot_Art/Additive_DoubleSided_UVAnimated_SoftenAround_Angle" {
    Properties {
        _UVAnimatedTex ("UVAnimatedTex", 2D) = "white" {}
        _EmissionColor ("EmissionColor", Color) = (0.4852941,0.4049696,0,1)
        _UVSpeed ("UVSpeed", Range(-10, 10)) = 1
        _Angle ("Angle", Range(0, 7)) = 0
    }
    SubShader {
        Tags {
            "IgnoreProjector"="True"
            "Queue"="Transparent"
            "RenderType"="Transparent"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            Blend One One
            Cull Off
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #pragma multi_compile_fwdbase
            #pragma multi_compile_fog
            #pragma exclude_renderers d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform float4 _TimeEditor;
            uniform float _UVSpeed;
            uniform float4 _EmissionColor;
            uniform sampler2D _UVAnimatedTex; uniform float4 _UVAnimatedTex_ST;
            uniform float _Angle;
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
                UNITY_FOG_COORDS(3)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = UnityObjectToClipPos(v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                return o;
            }
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
                i.normalDir = normalize(i.normalDir);
                i.normalDir *= faceSign;
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                float3 viewReflectDirection = reflect( -viewDirection, normalDirection );
////// Lighting:
////// Emissive:
                float4 node_8454 = _Time + _TimeEditor;
                float node_4893_ang = _Angle;
                float node_4893_spd = 1.0;
                float node_4893_cos = cos(node_4893_spd*node_4893_ang);
                float node_4893_sin = sin(node_4893_spd*node_4893_ang);
                float2 node_4893_piv = float2(0.5,0.5);
                float2 node_4893 = (mul(i.uv0-node_4893_piv,float2x2( node_4893_cos, -node_4893_sin, node_4893_sin, node_4893_cos))+node_4893_piv);
                float2 node_3188 = (node_4893+(node_8454.g*_UVSpeed)*float2(0,-0.2));
                float4 _UVAnimatedTex_var = tex2D(_UVAnimatedTex,TRANSFORM_TEX(node_3188, _UVAnimatedTex));
                float3 emissive = (_UVAnimatedTex_var.rgb*(_EmissionColor.rgb*5.0)*lerp(1,-1,distance(i.uv0,float2(0.5,0.5))));
                float3 finalColor = emissive;
                fixed4 finalRGBA = fixed4(finalColor,1);
                UNITY_APPLY_FOG_COLOR(i.fogCoord, finalRGBA, fixed4(0,0,0,1));
                return finalRGBA;
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
