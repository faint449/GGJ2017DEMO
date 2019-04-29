// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'

// Shader created with Shader Forge v1.26 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.26;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:1,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False;n:type:ShaderForge.SFN_Final,id:4013,x:33324,y:33625,varname:node_4013,prsc:2|emission-4309-OUT;n:type:ShaderForge.SFN_Tex2d,id:7499,x:32016,y:33799,ptovrint:False,ptlb:SPFlowTex,ptin:_SPFlowTex,varname:_SPFlowTex,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False|UVIN-6102-OUT;n:type:ShaderForge.SFN_Add,id:6102,x:31782,y:33766,varname:node_6102,prsc:2|A-2641-OUT,B-4022-UVOUT;n:type:ShaderForge.SFN_Panner,id:4022,x:31541,y:33834,varname:node_4022,prsc:2,spu:1,spv:0|UVIN-4874-UVOUT,DIST-8331-OUT;n:type:ShaderForge.SFN_Multiply,id:2641,x:31547,y:33545,varname:node_2641,prsc:2|A-5695-RGB,B-1696-OUT;n:type:ShaderForge.SFN_Slider,id:1696,x:31179,y:33566,ptovrint:False,ptlb:SPQuantity,ptin:_SPQuantity,varname:_SPQuantity,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.5,max:5;n:type:ShaderForge.SFN_Tex2d,id:5695,x:31780,y:33351,ptovrint:True,ptlb:EmissionTex,ptin:_MainTex,varname:_MainTex,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Color,id:8070,x:32333,y:33876,ptovrint:False,ptlb:SPColor,ptin:_SPColor,varname:_SPColor,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:1,c3:1,c4:0.991;n:type:ShaderForge.SFN_Fresnel,id:5269,x:32560,y:34556,varname:node_5269,prsc:2|EXP-4575-OUT;n:type:ShaderForge.SFN_Vector1,id:4575,x:32355,y:34701,varname:node_4575,prsc:2,v1:2;n:type:ShaderForge.SFN_Color,id:8433,x:32544,y:34762,ptovrint:False,ptlb:RimColor,ptin:_RimColor,varname:_RimColor,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_Multiply,id:7136,x:32823,y:34630,varname:node_7136,prsc:2|A-5269-OUT,B-8433-RGB,C-5087-OUT,D-9703-OUT;n:type:ShaderForge.SFN_Multiply,id:428,x:32769,y:33706,varname:node_428,prsc:2|A-7499-RGB,B-306-OUT,C-8070-RGB;n:type:ShaderForge.SFN_Add,id:4309,x:32809,y:33470,varname:node_4309,prsc:2|A-428-OUT,B-7136-OUT,C-5695-RGB;n:type:ShaderForge.SFN_Slider,id:306,x:32333,y:34087,ptovrint:False,ptlb:SPTransparency,ptin:_SPTransparency,varname:_SPTransparency,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:2;n:type:ShaderForge.SFN_ToggleProperty,id:5087,x:32544,y:34949,ptovrint:False,ptlb:RimOn,ptin:_RimOn,varname:_RimOn,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,on:False;n:type:ShaderForge.SFN_Slider,id:8283,x:30957,y:34103,ptovrint:False,ptlb:SPSpeed,ptin:_SPSpeed,varname:_SPSpeed,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:-2,cur:0,max:10;n:type:ShaderForge.SFN_ScreenPos,id:4874,x:31344,y:33834,varname:node_4874,prsc:2,sctp:1;n:type:ShaderForge.SFN_Time,id:9512,x:31114,y:33964,varname:node_9512,prsc:2;n:type:ShaderForge.SFN_Multiply,id:8331,x:31344,y:33997,varname:node_8331,prsc:2|A-9512-T,B-8283-OUT;n:type:ShaderForge.SFN_Vector1,id:9703,x:32740,y:34912,varname:node_9703,prsc:2,v1:3;proporder:5087-8433-5695-7499-8070-306-1696-8283;pass:END;sub:END;*/

Shader "Zealot_Art/Special/Emission_SPFlow_Rim" {
    Properties {
        [MaterialToggle] _RimOn ("RimOn", Float ) = 0
        _RimColor ("RimColor", Color) = (0.5,0.5,0.5,1)
        _MainTex ("EmissionTex", 2D) = "white" {}
        _SPFlowTex ("SPFlowTex", 2D) = "white" {}
        _SPColor ("SPColor", Color) = (1,1,1,0.991)
        _SPTransparency ("SPTransparency", Range(0, 2)) = 0
        _SPQuantity ("SPQuantity", Range(0, 5)) = 0.5
        _SPSpeed ("SPSpeed", Range(-2, 10)) = 0
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
            uniform sampler2D _SPFlowTex; uniform float4 _SPFlowTex_ST;
            uniform float _SPQuantity;
            uniform sampler2D _MainTex; uniform float4 _MainTex_ST;
            uniform float4 _SPColor;
            uniform float4 _RimColor;
            uniform float _SPTransparency;
            uniform fixed _RimOn;
            uniform float _SPSpeed;
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
                float4 screenPos : TEXCOORD3;
                UNITY_FOG_COORDS(4)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = UnityObjectToClipPos(v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                o.screenPos = o.pos;
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                i.screenPos = float4( i.screenPos.xy / i.screenPos.w, 0, 0 );
                i.screenPos.y *= _ProjectionParams.x;
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
////// Lighting:
////// Emissive:
                float4 _MainTex_var = tex2D(_MainTex,TRANSFORM_TEX(i.uv0, _MainTex));
                float4 node_9512 = _Time + _TimeEditor;
                float3 node_6102 = ((_MainTex_var.rgb*_SPQuantity)+float3((float2(i.screenPos.x*(_ScreenParams.r/_ScreenParams.g), i.screenPos.y).rg+(node_9512.g*_SPSpeed)*float2(1,0)),0.0));
                float4 _SPFlowTex_var = tex2D(_SPFlowTex,TRANSFORM_TEX(node_6102, _SPFlowTex));
                float3 emissive = ((_SPFlowTex_var.rgb*_SPTransparency*_SPColor.rgb)+(pow(1.0-max(0,dot(normalDirection, viewDirection)),2.0)*_RimColor.rgb*_RimOn*3.0)+_MainTex_var.rgb);
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
