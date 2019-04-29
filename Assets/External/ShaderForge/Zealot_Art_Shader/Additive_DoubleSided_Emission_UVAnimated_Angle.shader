// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Shader created with Shader Forge v1.26 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.26;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:2,bsrc:0,bdst:0,dpts:2,wrdp:False,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:True,fgod:False,fgor:False,fgmd:0,fgcr:0,fgcg:0,fgcb:0,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False;n:type:ShaderForge.SFN_Final,id:3138,x:33322,y:32768,varname:node_3138,prsc:2|emission-7899-OUT;n:type:ShaderForge.SFN_Tex2d,id:1332,x:32289,y:32515,ptovrint:False,ptlb:EmissionTex,ptin:_EmissionTex,varname:node_8129,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Color,id:8242,x:32289,y:32743,ptovrint:False,ptlb:EmissionColor,ptin:_EmissionColor,varname:node_2792,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_Multiply,id:1656,x:32937,y:32642,varname:node_1656,prsc:2|A-1332-RGB,B-6263-OUT;n:type:ShaderForge.SFN_Panner,id:3408,x:32053,y:32674,varname:node_3408,prsc:2,spu:0,spv:-0.2|UVIN-3234-UVOUT,DIST-8773-OUT;n:type:ShaderForge.SFN_TexCoord,id:9063,x:31283,y:32666,varname:node_9063,prsc:2,uv:0;n:type:ShaderForge.SFN_Time,id:5723,x:31726,y:32699,varname:node_5723,prsc:2;n:type:ShaderForge.SFN_Slider,id:4069,x:31561,y:32854,ptovrint:False,ptlb:UVSpeed,ptin:_UVSpeed,varname:node_9088,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:-10,cur:1,max:10;n:type:ShaderForge.SFN_Multiply,id:8773,x:31896,y:32749,varname:node_8773,prsc:2|A-5723-T,B-4069-OUT;n:type:ShaderForge.SFN_Rotator,id:3234,x:31726,y:32563,varname:node_3234,prsc:2|UVIN-9063-UVOUT,ANG-9048-OUT;n:type:ShaderForge.SFN_Slider,id:6930,x:31175,y:32477,ptovrint:False,ptlb:Angle,ptin:_Angle,varname:_Angle_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:2;n:type:ShaderForge.SFN_Pi,id:8311,x:31365,y:32356,varname:node_8311,prsc:2;n:type:ShaderForge.SFN_Multiply,id:9048,x:31485,y:32415,varname:node_9048,prsc:2|A-8311-OUT,B-6930-OUT;n:type:ShaderForge.SFN_Tex2d,id:6712,x:32198,y:33421,ptovrint:False,ptlb:UVAnimatedTex,ptin:_UVAnimatedTex,varname:node_6712,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False|UVIN-3408-UVOUT;n:type:ShaderForge.SFN_Multiply,id:7899,x:33075,y:33380,varname:node_7899,prsc:2|A-1656-OUT,B-6712-RGB;n:type:ShaderForge.SFN_Color,id:5753,x:32289,y:32937,ptovrint:False,ptlb:FlashColor,ptin:_FlashColor,varname:node_5753,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_ValueProperty,id:1256,x:32466,y:33271,ptovrint:False,ptlb:FlashIntensity,ptin:_FlashIntensity,varname:node_1256,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0;n:type:ShaderForge.SFN_Multiply,id:6263,x:32738,y:32700,varname:node_6263,prsc:2|A-8242-RGB,B-3370-OUT;n:type:ShaderForge.SFN_Multiply,id:3370,x:32842,y:32925,varname:node_3370,prsc:2|A-5753-RGB,B-3009-OUT;n:type:ShaderForge.SFN_Add,id:3009,x:32665,y:32963,varname:node_3009,prsc:2|A-838-OUT,B-5065-OUT;n:type:ShaderForge.SFN_Vector1,id:838,x:32289,y:33188,varname:node_838,prsc:2,v1:1;n:type:ShaderForge.SFN_Multiply,id:5065,x:32652,y:33127,varname:node_5065,prsc:2|A-7522-OUT,B-1256-OUT;n:type:ShaderForge.SFN_Vector1,id:527,x:32289,y:33112,varname:node_527,prsc:2,v1:10;n:type:ShaderForge.SFN_Subtract,id:7522,x:32466,y:33100,varname:node_7522,prsc:2|A-527-OUT,B-838-OUT;proporder:1332-8242-6712-4069-6930-5753-1256;pass:END;sub:END;*/

Shader "Zealot_Art/Additive_DoubleSided_Emission_UVanimated_Angle" {
    Properties {
        _EmissionTex ("EmissionTex", 2D) = "white" {}
        _EmissionColor ("EmissionColor", Color) = (0.5,0.5,0.5,1)
        _UVAnimatedTex ("UVAnimatedTex", 2D) = "white" {}
        _UVSpeed ("UVSpeed", Range(-10, 10)) = 1
        _Angle ("Angle", Range(0, 2)) = 0
        _FlashColor ("FlashColor", Color) = (1,1,1,1)
        _FlashIntensity ("FlashIntensity", Float ) = 0
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
            #pragma multi_compile_fwdbase
            #pragma multi_compile_fog
            #pragma exclude_renderers d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform float4 _TimeEditor;
            uniform sampler2D _EmissionTex; uniform float4 _EmissionTex_ST;
            uniform float4 _EmissionColor;
            uniform float _UVSpeed;
            uniform float _Angle;
            uniform sampler2D _UVAnimatedTex; uniform float4 _UVAnimatedTex_ST;
            uniform float4 _FlashColor;
            uniform float _FlashIntensity;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                UNITY_FOG_COORDS(1)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.pos = UnityObjectToClipPos(v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                return o;
            }
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
////// Lighting:
////// Emissive:
                float4 _EmissionTex_var = tex2D(_EmissionTex,TRANSFORM_TEX(i.uv0, _EmissionTex));
                float node_838 = 1.0;
                float4 node_5723 = _Time + _TimeEditor;
                float node_3234_ang = (3.141592654*_Angle);
                float node_3234_spd = 1.0;
                float node_3234_cos = cos(node_3234_spd*node_3234_ang);
                float node_3234_sin = sin(node_3234_spd*node_3234_ang);
                float2 node_3234_piv = float2(0.5,0.5);
                float2 node_3234 = (mul(i.uv0-node_3234_piv,float2x2( node_3234_cos, -node_3234_sin, node_3234_sin, node_3234_cos))+node_3234_piv);
                float2 node_3408 = (node_3234+(node_5723.g*_UVSpeed)*float2(0,-0.2));
                float4 _UVAnimatedTex_var = tex2D(_UVAnimatedTex,TRANSFORM_TEX(node_3408, _UVAnimatedTex));
                float3 emissive = ((_EmissionTex_var.rgb*(_EmissionColor.rgb*(_FlashColor.rgb*(node_838+((10.0-node_838)*_FlashIntensity)))))*_UVAnimatedTex_var.rgb);
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
