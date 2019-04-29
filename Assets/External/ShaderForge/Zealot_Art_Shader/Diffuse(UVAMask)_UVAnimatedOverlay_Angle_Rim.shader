// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'

// Shader created with Shader Forge v1.26 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.26;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:1,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:True,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.4901961,fgcg:0.4901961,fgcb:0.4901961,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False;n:type:ShaderForge.SFN_Final,id:4013,x:33127,y:32540,varname:node_4013,prsc:2|diff-3686-OUT,emission-3154-OUT;n:type:ShaderForge.SFN_Tex2d,id:1104,x:32035,y:32467,ptovrint:True,ptlb:Diffuse(UVAMask),ptin:_MainTex,varname:_MainTex,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:3663,x:31709,y:33044,ptovrint:False,ptlb:UVAnimatedTex,ptin:_UVAnimatedTex,varname:_UVAnimatedTex,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False|UVIN-5393-UVOUT;n:type:ShaderForge.SFN_Multiply,id:4695,x:32391,y:32938,varname:node_4695,prsc:2|A-1104-A,B-3663-RGB;n:type:ShaderForge.SFN_Panner,id:5393,x:31327,y:32944,varname:node_5393,prsc:2,spu:0,spv:1|UVIN-6856-UVOUT,DIST-2316-OUT;n:type:ShaderForge.SFN_TexCoord,id:3706,x:30938,y:32721,varname:node_3706,prsc:2,uv:0;n:type:ShaderForge.SFN_Time,id:6825,x:30939,y:33122,varname:node_6825,prsc:2;n:type:ShaderForge.SFN_Slider,id:2694,x:30774,y:33277,ptovrint:False,ptlb:UVSpeed,ptin:_UVSpeed,varname:_UVSpeed,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:-3,cur:1,max:3;n:type:ShaderForge.SFN_Multiply,id:2316,x:31179,y:33163,varname:node_2316,prsc:2|A-6825-T,B-2694-OUT;n:type:ShaderForge.SFN_Rotator,id:6856,x:31099,y:32871,varname:node_6856,prsc:2|UVIN-3706-UVOUT,ANG-6975-OUT;n:type:ShaderForge.SFN_Slider,id:807,x:30593,y:33046,ptovrint:False,ptlb:Angle,ptin:_Angle,varname:_Angle,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:2;n:type:ShaderForge.SFN_Pi,id:3072,x:30783,y:32906,varname:node_3072,prsc:2;n:type:ShaderForge.SFN_Multiply,id:6975,x:30939,y:32967,varname:node_6975,prsc:2|A-3072-OUT,B-807-OUT;n:type:ShaderForge.SFN_Fresnel,id:7368,x:32176,y:33377,varname:node_7368,prsc:2|EXP-2610-OUT;n:type:ShaderForge.SFN_ToggleProperty,id:5003,x:32176,y:33720,ptovrint:False,ptlb:RimOn,ptin:_RimOn,varname:_RimOn,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,on:True;n:type:ShaderForge.SFN_Multiply,id:216,x:32381,y:33457,varname:node_216,prsc:2|A-7368-OUT,B-4245-OUT,C-5003-OUT;n:type:ShaderForge.SFN_Vector1,id:2610,x:31983,y:33397,varname:node_2610,prsc:2,v1:3;n:type:ShaderForge.SFN_Color,id:8472,x:31967,y:33522,ptovrint:False,ptlb:RimColor,ptin:_RimColor,varname:_RimColor,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_Vector1,id:141,x:31967,y:33668,varname:node_141,prsc:2,v1:2;n:type:ShaderForge.SFN_Multiply,id:4245,x:32176,y:33541,varname:node_4245,prsc:2|A-8472-RGB,B-141-OUT;n:type:ShaderForge.SFN_Color,id:884,x:32574,y:32564,ptovrint:False,ptlb:FlashColor,ptin:_FlashColor,varname:_FlashColor,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_ValueProperty,id:9646,x:32585,y:32780,ptovrint:False,ptlb:FlashIntensity,ptin:_FlashIntensity,varname:_FlashIntensity,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0;n:type:ShaderForge.SFN_Lerp,id:3686,x:32811,y:32574,varname:node_3686,prsc:2|A-1104-RGB,B-884-RGB,T-9646-OUT;n:type:ShaderForge.SFN_Add,id:3154,x:32600,y:33139,varname:node_3154,prsc:2|A-4695-OUT,B-216-OUT;proporder:5003-8472-1104-3663-2694-807-884-9646;pass:END;sub:END;*/

Shader "Zealot_Art/Diffuse(UVAMask)_UVAnimatedOverlay_Angle_Rim" {
    Properties {
        [MaterialToggle] _RimOn ("RimOn", Float ) = 1
        _RimColor ("RimColor", Color) = (1,1,1,1)
        _MainTex ("Diffuse(UVAMask)", 2D) = "white" {}
        _UVAnimatedTex ("UVAnimatedTex", 2D) = "white" {}
        _UVSpeed ("UVSpeed", Range(-3, 3)) = 1
        _Angle ("Angle", Range(0, 2)) = 0
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
            #define SHOULD_SAMPLE_SH ( defined (LIGHTMAP_OFF) && defined(DYNAMICLIGHTMAP_OFF) )
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #include "Lighting.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma multi_compile LIGHTMAP_OFF LIGHTMAP_ON
            #pragma multi_compile DIRLIGHTMAP_OFF DIRLIGHTMAP_COMBINED DIRLIGHTMAP_SEPARATE
            #pragma multi_compile DYNAMICLIGHTMAP_OFF DYNAMICLIGHTMAP_ON
            #pragma multi_compile_fog
            #pragma exclude_renderers d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform float4 _TimeEditor;
            uniform sampler2D _MainTex; uniform float4 _MainTex_ST;
            uniform sampler2D _UVAnimatedTex; uniform float4 _UVAnimatedTex_ST;
            uniform float _UVSpeed;
            uniform float _Angle;
            uniform fixed _RimOn;
            uniform float4 _RimColor;
            uniform float4 _FlashColor;
            uniform float _FlashIntensity;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
                float2 texcoord1 : TEXCOORD1;
                float2 texcoord2 : TEXCOORD2;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float2 uv1 : TEXCOORD1;
                float2 uv2 : TEXCOORD2;
                float4 posWorld : TEXCOORD3;
                float3 normalDir : TEXCOORD4;
                float3 tangentDir : TEXCOORD5;
                float3 bitangentDir : TEXCOORD6;
                LIGHTING_COORDS(7,8)
                UNITY_FOG_COORDS(9)
                #if defined(LIGHTMAP_ON) || defined(UNITY_SHOULD_SAMPLE_SH)
                    float4 ambientOrLightmapUV : TEXCOORD10;
                #endif
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.uv1 = v.texcoord1;
                o.uv2 = v.texcoord2;
                #ifdef LIGHTMAP_ON
                    o.ambientOrLightmapUV.xy = v.texcoord1.xy * unity_LightmapST.xy + unity_LightmapST.zw;
                    o.ambientOrLightmapUV.zw = 0;
                #elif UNITY_SHOULD_SAMPLE_SH
                #endif
                #ifdef DYNAMICLIGHTMAP_ON
                    o.ambientOrLightmapUV.zw = v.texcoord2.xy * unity_DynamicLightmapST.xy + unity_DynamicLightmapST.zw;
                #endif
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.tangentDir = normalize( mul( unity_ObjectToWorld, float4( v.tangent.xyz, 0.0 ) ).xyz );
                o.bitangentDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos(v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                float3 viewReflectDirection = reflect( -viewDirection, normalDirection );
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
                float3 lightColor = _LightColor0.rgb;
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
/////// GI Data:
                UnityLight light;
                #ifdef LIGHTMAP_OFF
                    light.color = lightColor;
                    light.dir = lightDirection;
                    light.ndotl = LambertTerm (normalDirection, light.dir);
                #else
                    light.color = half3(0.f, 0.f, 0.f);
                    light.ndotl = 0.0f;
                    light.dir = half3(0.f, 0.f, 0.f);
                #endif
                UnityGIInput d;
                d.light = light;
                d.worldPos = i.posWorld.xyz;
                d.worldViewDir = viewDirection;
                d.atten = attenuation;
                #if defined(LIGHTMAP_ON) || defined(DYNAMICLIGHTMAP_ON)
                    d.ambient = 0;
                    d.lightmapUV = i.ambientOrLightmapUV;
                #else
                    d.ambient = i.ambientOrLightmapUV;
                #endif
                Unity_GlossyEnvironmentData ugls_en_data;
                ugls_en_data.roughness = 1.0 - 0;
                ugls_en_data.reflUVW = viewReflectDirection;
                UnityGI gi = UnityGlobalIllumination(d, 1, normalDirection, ugls_en_data );
                lightDirection = gi.light.dir;
                lightColor = gi.light.color;
/////// Diffuse:
                float NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 directDiffuse = max( 0.0, NdotL) * attenColor;
                float3 indirectDiffuse = float3(0,0,0);
                indirectDiffuse += gi.indirect.diffuse;
                float4 _MainTex_var = tex2D(_MainTex,TRANSFORM_TEX(i.uv0, _MainTex));
                float3 diffuseColor = lerp(_MainTex_var.rgb,_FlashColor.rgb,_FlashIntensity);
                float3 diffuse = (directDiffuse + indirectDiffuse) * diffuseColor;
////// Emissive:
                float4 node_6825 = _Time + _TimeEditor;
                float node_6856_ang = (3.141592654*_Angle);
                float node_6856_spd = 1.0;
                float node_6856_cos = cos(node_6856_spd*node_6856_ang);
                float node_6856_sin = sin(node_6856_spd*node_6856_ang);
                float2 node_6856_piv = float2(0.5,0.5);
                float2 node_6856 = (mul(i.uv0-node_6856_piv,float2x2( node_6856_cos, -node_6856_sin, node_6856_sin, node_6856_cos))+node_6856_piv);
                float2 node_5393 = (node_6856+(node_6825.g*_UVSpeed)*float2(0,1));
                float4 _UVAnimatedTex_var = tex2D(_UVAnimatedTex,TRANSFORM_TEX(node_5393, _UVAnimatedTex));
                float3 emissive = ((_MainTex_var.a*_UVAnimatedTex_var.rgb)+(pow(1.0-max(0,dot(normalDirection, viewDirection)),3.0)*(_RimColor.rgb*2.0)*_RimOn));
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
            #define SHOULD_SAMPLE_SH ( defined (LIGHTMAP_OFF) && defined(DYNAMICLIGHTMAP_OFF) )
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #include "Lighting.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #pragma multi_compile_fwdadd_fullshadows
            #pragma multi_compile LIGHTMAP_OFF LIGHTMAP_ON
            #pragma multi_compile DIRLIGHTMAP_OFF DIRLIGHTMAP_COMBINED DIRLIGHTMAP_SEPARATE
            #pragma multi_compile DYNAMICLIGHTMAP_OFF DYNAMICLIGHTMAP_ON
            #pragma multi_compile_fog
            #pragma exclude_renderers d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform float4 _TimeEditor;
            uniform sampler2D _MainTex; uniform float4 _MainTex_ST;
            uniform sampler2D _UVAnimatedTex; uniform float4 _UVAnimatedTex_ST;
            uniform float _UVSpeed;
            uniform float _Angle;
            uniform fixed _RimOn;
            uniform float4 _RimColor;
            uniform float4 _FlashColor;
            uniform float _FlashIntensity;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
                float2 texcoord1 : TEXCOORD1;
                float2 texcoord2 : TEXCOORD2;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float2 uv1 : TEXCOORD1;
                float2 uv2 : TEXCOORD2;
                float4 posWorld : TEXCOORD3;
                float3 normalDir : TEXCOORD4;
                float3 tangentDir : TEXCOORD5;
                float3 bitangentDir : TEXCOORD6;
                LIGHTING_COORDS(7,8)
                UNITY_FOG_COORDS(9)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.uv1 = v.texcoord1;
                o.uv2 = v.texcoord2;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.tangentDir = normalize( mul( unity_ObjectToWorld, float4( v.tangent.xyz, 0.0 ) ).xyz );
                o.bitangentDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos(v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
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
                float4 _MainTex_var = tex2D(_MainTex,TRANSFORM_TEX(i.uv0, _MainTex));
                float3 diffuseColor = lerp(_MainTex_var.rgb,_FlashColor.rgb,_FlashIntensity);
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
            Name "Meta"
            Tags {
                "LightMode"="Meta"
            }
            Cull Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_META 1
            #define SHOULD_SAMPLE_SH ( defined (LIGHTMAP_OFF) && defined(DYNAMICLIGHTMAP_OFF) )
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #include "UnityMetaPass.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma multi_compile LIGHTMAP_OFF LIGHTMAP_ON
            #pragma multi_compile DIRLIGHTMAP_OFF DIRLIGHTMAP_COMBINED DIRLIGHTMAP_SEPARATE
            #pragma multi_compile DYNAMICLIGHTMAP_OFF DYNAMICLIGHTMAP_ON
            #pragma multi_compile_fog
            #pragma exclude_renderers d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform float4 _TimeEditor;
            uniform sampler2D _MainTex; uniform float4 _MainTex_ST;
            uniform sampler2D _UVAnimatedTex; uniform float4 _UVAnimatedTex_ST;
            uniform float _UVSpeed;
            uniform float _Angle;
            uniform fixed _RimOn;
            uniform float4 _RimColor;
            uniform float4 _FlashColor;
            uniform float _FlashIntensity;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord0 : TEXCOORD0;
                float2 texcoord1 : TEXCOORD1;
                float2 texcoord2 : TEXCOORD2;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float2 uv1 : TEXCOORD1;
                float2 uv2 : TEXCOORD2;
                float4 posWorld : TEXCOORD3;
                float3 normalDir : TEXCOORD4;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.uv1 = v.texcoord1;
                o.uv2 = v.texcoord2;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = UnityMetaVertexPosition(v.vertex, v.texcoord1.xy, v.texcoord2.xy, unity_LightmapST, unity_DynamicLightmapST );
                return o;
            }
            float4 frag(VertexOutput i) : SV_Target {
                i.normalDir = normalize(i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                UnityMetaInput o;
                UNITY_INITIALIZE_OUTPUT( UnityMetaInput, o );
                
                float4 _MainTex_var = tex2D(_MainTex,TRANSFORM_TEX(i.uv0, _MainTex));
                float4 node_6825 = _Time + _TimeEditor;
                float node_6856_ang = (3.141592654*_Angle);
                float node_6856_spd = 1.0;
                float node_6856_cos = cos(node_6856_spd*node_6856_ang);
                float node_6856_sin = sin(node_6856_spd*node_6856_ang);
                float2 node_6856_piv = float2(0.5,0.5);
                float2 node_6856 = (mul(i.uv0-node_6856_piv,float2x2( node_6856_cos, -node_6856_sin, node_6856_sin, node_6856_cos))+node_6856_piv);
                float2 node_5393 = (node_6856+(node_6825.g*_UVSpeed)*float2(0,1));
                float4 _UVAnimatedTex_var = tex2D(_UVAnimatedTex,TRANSFORM_TEX(node_5393, _UVAnimatedTex));
                o.Emission = ((_MainTex_var.a*_UVAnimatedTex_var.rgb)+(pow(1.0-max(0,dot(normalDirection, viewDirection)),3.0)*(_RimColor.rgb*2.0)*_RimOn));
                
                float3 diffColor = lerp(_MainTex_var.rgb,_FlashColor.rgb,_FlashIntensity);
                o.Albedo = diffColor;
                
                return UnityMetaFragment( o );
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
