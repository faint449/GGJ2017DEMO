// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'

// Shader created with Shader Forge v1.26 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.26;sub:START;pass:START;ps:flbk:Mobile/Diffuse,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:1,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:False,qofs:0,qpre:2,rntp:3,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False;n:type:ShaderForge.SFN_Final,id:4013,x:32719,y:32712,varname:node_4013,prsc:2|diff-1255-OUT,emission-2999-OUT,clip-1104-A;n:type:ShaderForge.SFN_Tex2d,id:1104,x:32088,y:32669,ptovrint:False,ptlb:DiffuseTex(AlphaTesting),ptin:_DiffuseTexAlphaTesting,varname:node_1104,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Multiply,id:1128,x:32309,y:33055,varname:node_1128,prsc:2|A-1053-RGB,B-504-R;n:type:ShaderForge.SFN_Panner,id:9699,x:31391,y:33008,varname:node_9699,prsc:2,spu:0,spv:1|UVIN-7307-UVOUT,DIST-3502-OUT;n:type:ShaderForge.SFN_Time,id:648,x:31003,y:33186,varname:node_648,prsc:2;n:type:ShaderForge.SFN_Slider,id:5984,x:30838,y:33341,ptovrint:False,ptlb:UVSpeed,ptin:_UVSpeed,varname:node_9088,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:-3,cur:1,max:3;n:type:ShaderForge.SFN_Multiply,id:3502,x:31243,y:33227,varname:node_3502,prsc:2|A-648-T,B-5984-OUT;n:type:ShaderForge.SFN_TexCoord,id:3348,x:31002,y:32785,varname:node_3348,prsc:2,uv:0;n:type:ShaderForge.SFN_OneMinus,id:7058,x:32088,y:32839,varname:node_7058,prsc:2|IN-504-R;n:type:ShaderForge.SFN_Multiply,id:1255,x:32384,y:32721,varname:node_1255,prsc:2|A-1104-RGB,B-7058-OUT;n:type:ShaderForge.SFN_Rotator,id:7307,x:31216,y:32860,varname:node_7307,prsc:2|UVIN-3348-UVOUT,ANG-6450-OUT;n:type:ShaderForge.SFN_Slider,id:9856,x:30692,y:33022,ptovrint:False,ptlb:Angle,ptin:_Angle,varname:_Angle_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:2;n:type:ShaderForge.SFN_Pi,id:2976,x:30882,y:32901,varname:node_2976,prsc:2;n:type:ShaderForge.SFN_Multiply,id:6450,x:31002,y:32960,varname:node_6450,prsc:2|A-2976-OUT,B-9856-OUT;n:type:ShaderForge.SFN_Tex2d,id:1053,x:31755,y:33156,ptovrint:False,ptlb:UVAnimatedTex,ptin:_UVAnimatedTex,varname:node_1053,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False|UVIN-9699-UVOUT;n:type:ShaderForge.SFN_Tex2d,id:504,x:31755,y:33379,ptovrint:False,ptlb:UVAnimatedMask,ptin:_UVAnimatedMask,varname:node_504,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Fresnel,id:5073,x:31949,y:33574,varname:node_5073,prsc:2|EXP-8558-OUT;n:type:ShaderForge.SFN_ToggleProperty,id:6366,x:31949,y:33917,ptovrint:False,ptlb:RimOn,ptin:_RimOn,varname:_RimOn,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,on:True;n:type:ShaderForge.SFN_Multiply,id:3219,x:32154,y:33654,varname:node_3219,prsc:2|A-5073-OUT,B-1504-OUT,C-6366-OUT;n:type:ShaderForge.SFN_Vector1,id:8558,x:31756,y:33594,varname:node_8558,prsc:2,v1:3;n:type:ShaderForge.SFN_Color,id:9592,x:31740,y:33719,ptovrint:False,ptlb:RimColor,ptin:_RimColor,varname:_RimColor,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_Vector1,id:7906,x:31740,y:33865,varname:node_7906,prsc:2,v1:2;n:type:ShaderForge.SFN_Multiply,id:1504,x:31949,y:33738,varname:node_1504,prsc:2|A-9592-RGB,B-7906-OUT;n:type:ShaderForge.SFN_Add,id:2999,x:32423,y:33350,varname:node_2999,prsc:2|A-1128-OUT,B-3219-OUT;proporder:6366-9592-1104-1053-504-5984-9856;pass:END;sub:END;*/

Shader "Zealot_Art/Diffuse(AlphaTesting)_UVAnimated_UVAnimatedMask_Angle_Rim" {
    Properties {
        [MaterialToggle] _RimOn ("RimOn", Float ) = 1
        _RimColor ("RimColor", Color) = (1,1,1,1)
        _DiffuseTexAlphaTesting ("DiffuseTex(AlphaTesting)", 2D) = "white" {}
        _UVAnimatedTex ("UVAnimatedTex", 2D) = "white" {}
        _UVAnimatedMask ("UVAnimatedMask", 2D) = "white" {}
        _UVSpeed ("UVSpeed", Range(-3, 3)) = 1
        _Angle ("Angle", Range(0, 2)) = 0
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
            uniform sampler2D _DiffuseTexAlphaTesting; uniform float4 _DiffuseTexAlphaTesting_ST;
            uniform float _UVSpeed;
            uniform float _Angle;
            uniform sampler2D _UVAnimatedTex; uniform float4 _UVAnimatedTex_ST;
            uniform sampler2D _UVAnimatedMask; uniform float4 _UVAnimatedMask_ST;
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
                float4 _DiffuseTexAlphaTesting_var = tex2D(_DiffuseTexAlphaTesting,TRANSFORM_TEX(i.uv0, _DiffuseTexAlphaTesting));
                clip(_DiffuseTexAlphaTesting_var.a - 0.5);
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
                float4 _UVAnimatedMask_var = tex2D(_UVAnimatedMask,TRANSFORM_TEX(i.uv0, _UVAnimatedMask));
                float3 diffuseColor = (_DiffuseTexAlphaTesting_var.rgb*(1.0 - _UVAnimatedMask_var.r));
                float3 diffuse = (directDiffuse + indirectDiffuse) * diffuseColor;
////// Emissive:
                float4 node_648 = _Time + _TimeEditor;
                float node_7307_ang = (3.141592654*_Angle);
                float node_7307_spd = 1.0;
                float node_7307_cos = cos(node_7307_spd*node_7307_ang);
                float node_7307_sin = sin(node_7307_spd*node_7307_ang);
                float2 node_7307_piv = float2(0.5,0.5);
                float2 node_7307 = (mul(i.uv0-node_7307_piv,float2x2( node_7307_cos, -node_7307_sin, node_7307_sin, node_7307_cos))+node_7307_piv);
                float2 node_9699 = (node_7307+(node_648.g*_UVSpeed)*float2(0,1));
                float4 _UVAnimatedTex_var = tex2D(_UVAnimatedTex,TRANSFORM_TEX(node_9699, _UVAnimatedTex));
                float3 emissive = ((_UVAnimatedTex_var.rgb*_UVAnimatedMask_var.r)+(pow(1.0-max(0,dot(normalDirection, viewDirection)),3.0)*(_RimColor.rgb*2.0)*_RimOn));
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
            uniform sampler2D _DiffuseTexAlphaTesting; uniform float4 _DiffuseTexAlphaTesting_ST;
            uniform float _UVSpeed;
            uniform float _Angle;
            uniform sampler2D _UVAnimatedTex; uniform float4 _UVAnimatedTex_ST;
            uniform sampler2D _UVAnimatedMask; uniform float4 _UVAnimatedMask_ST;
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
                float4 _DiffuseTexAlphaTesting_var = tex2D(_DiffuseTexAlphaTesting,TRANSFORM_TEX(i.uv0, _DiffuseTexAlphaTesting));
                clip(_DiffuseTexAlphaTesting_var.a - 0.5);
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
                float3 lightColor = _LightColor0.rgb;
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
/////// Diffuse:
                float NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 directDiffuse = max( 0.0, NdotL) * attenColor;
                float4 _UVAnimatedMask_var = tex2D(_UVAnimatedMask,TRANSFORM_TEX(i.uv0, _UVAnimatedMask));
                float3 diffuseColor = (_DiffuseTexAlphaTesting_var.rgb*(1.0 - _UVAnimatedMask_var.r));
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
            uniform sampler2D _DiffuseTexAlphaTesting; uniform float4 _DiffuseTexAlphaTesting_ST;
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
                o.pos = UnityObjectToClipPos(v.vertex );
                TRANSFER_SHADOW_CASTER(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                float4 _DiffuseTexAlphaTesting_var = tex2D(_DiffuseTexAlphaTesting,TRANSFORM_TEX(i.uv0, _DiffuseTexAlphaTesting));
                clip(_DiffuseTexAlphaTesting_var.a - 0.5);
                SHADOW_CASTER_FRAGMENT(i)
            }
            ENDCG
        }
    }
    FallBack "Mobile/Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
