// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'

// Shader created with Shader Forge v1.27 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.27;sub:START;pass:START;ps:flbk:Mobile/Diffuse,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:1,spmd:1,trmd:0,grmd:0,uamb:False,mssp:False,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:3,bdst:7,dpts:2,wrdp:False,dith:0,rfrpo:False,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False;n:type:ShaderForge.SFN_Final,id:4013,x:32361,y:32649,varname:node_4013,prsc:2|diff-7125-OUT,spec-7125-OUT,normal-9033-RGB,emission-8753-RGB,alpha-8753-A;n:type:ShaderForge.SFN_Panner,id:1219,x:31841,y:32619,varname:node_1219,prsc:2,spu:0,spv:-0.2|UVIN-3853-UVOUT,DIST-5214-OUT;n:type:ShaderForge.SFN_TexCoord,id:1839,x:31180,y:32405,varname:node_1839,prsc:2,uv:0;n:type:ShaderForge.SFN_Time,id:7058,x:31514,y:32644,varname:node_7058,prsc:2;n:type:ShaderForge.SFN_Slider,id:9032,x:31357,y:32842,ptovrint:False,ptlb:FlowSpeed,ptin:_FlowSpeed,varname:_FlowSpeed,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:-10,cur:1,max:10;n:type:ShaderForge.SFN_Multiply,id:5214,x:31684,y:32694,varname:node_5214,prsc:2|A-7058-T,B-9032-OUT;n:type:ShaderForge.SFN_Tex2d,id:8753,x:32059,y:32619,ptovrint:True,ptlb:EmissionTex(AlphaBlendMask)_Flow,ptin:_MainTex,varname:_MainTex,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False|UVIN-1219-UVOUT;n:type:ShaderForge.SFN_Rotator,id:3853,x:31514,y:32508,varname:node_3853,prsc:2|UVIN-1839-UVOUT,ANG-5238-OUT;n:type:ShaderForge.SFN_Slider,id:5526,x:30834,y:32652,ptovrint:False,ptlb:FlowAngle,ptin:_FlowAngle,varname:_FlowAngle,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:2;n:type:ShaderForge.SFN_Pi,id:7684,x:31024,y:32512,varname:node_7684,prsc:2;n:type:ShaderForge.SFN_Multiply,id:5238,x:31180,y:32573,varname:node_5238,prsc:2|A-7684-OUT,B-5526-OUT;n:type:ShaderForge.SFN_Slider,id:7125,x:31841,y:32867,ptovrint:False,ptlb:node_7125,ptin:_node_7125,varname:_node_7125,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.2386495,max:1;n:type:ShaderForge.SFN_Tex2d,id:9033,x:32057,y:32912,ptovrint:False,ptlb:node_9033,ptin:_node_9033,varname:_node_9033,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;proporder:8753-9032-5526-7125-9033;pass:END;sub:END;*/

Shader "ZDGO/Scenes/Emission(AlphaBlendMask)_Flow_NoFog" {
    Properties {
        _MainTex ("EmissionTex(AlphaBlendMask)_Flow", 2D) = "white" {}
        _FlowSpeed ("FlowSpeed", Range(-10, 10)) = 1
        _FlowAngle ("FlowAngle", Range(0, 2)) = 0
        _node_7125 ("node_7125", Range(0, 1)) = 0.2386495
        _node_9033 ("node_9033", 2D) = "white" {}
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
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
            Blend SrcAlpha OneMinusSrcAlpha
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase
            #pragma exclude_renderers d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform float4 _LightColor0;
            uniform float4 _TimeEditor;
            uniform float _FlowSpeed;
            uniform sampler2D _MainTex; uniform float4 _MainTex_ST;
            uniform float _FlowAngle;
            uniform float _node_7125;
            uniform sampler2D _node_9033; uniform float4 _node_9033_ST;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                float3 tangentDir : TEXCOORD3;
                float3 bitangentDir : TEXCOORD4;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.tangentDir = normalize( mul( unity_ObjectToWorld, float4( v.tangent.xyz, 0.0 ) ).xyz );
                o.bitangentDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex );
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float4 _node_9033_var = tex2D(_node_9033,TRANSFORM_TEX(i.uv0, _node_9033));
                float3 normalLocal = _node_9033_var.rgb;
                float3 normalDirection = normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
                float3 lightColor = _LightColor0.rgb;
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                float attenuation = 1;
                float3 attenColor = attenuation * _LightColor0.xyz;
///////// Gloss:
                float gloss = 0.5;
                float specPow = exp2( gloss * 10.0+1.0);
////// Specular:
                float NdotL = max(0, dot( normalDirection, lightDirection ));
                float3 specularColor = float3(_node_7125,_node_7125,_node_7125);
                float3 directSpecular = attenColor * pow(max(0,dot(halfDirection,normalDirection)),specPow)*specularColor;
                float3 specular = directSpecular;
/////// Diffuse:
                NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 directDiffuse = max( 0.0, NdotL) * attenColor;
                float3 diffuseColor = float3(_node_7125,_node_7125,_node_7125);
                float3 diffuse = directDiffuse * diffuseColor;
////// Emissive:
                float4 node_7058 = _Time + _TimeEditor;
                float node_3853_ang = (3.141592654*_FlowAngle);
                float node_3853_spd = 1.0;
                float node_3853_cos = cos(node_3853_spd*node_3853_ang);
                float node_3853_sin = sin(node_3853_spd*node_3853_ang);
                float2 node_3853_piv = float2(0.5,0.5);
                float2 node_3853 = (mul(i.uv0-node_3853_piv,float2x2( node_3853_cos, -node_3853_sin, node_3853_sin, node_3853_cos))+node_3853_piv);
                float2 node_1219 = (node_3853+(node_7058.g*_FlowSpeed)*float2(0,-0.2));
                float4 _MainTex_var = tex2D(_MainTex,TRANSFORM_TEX(node_1219, _MainTex));
                float3 emissive = _MainTex_var.rgb;
/// Final Color:
                float3 finalColor = diffuse + specular + emissive;
                return fixed4(finalColor,_MainTex_var.a);
            }
            ENDCG
        }
        Pass {
            Name "FORWARD_DELTA"
            Tags {
                "LightMode"="ForwardAdd"
            }
            Blend One One
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDADD
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #pragma multi_compile_fwdadd
            #pragma exclude_renderers d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform float4 _LightColor0;
            uniform float4 _TimeEditor;
            uniform float _FlowSpeed;
            uniform sampler2D _MainTex; uniform float4 _MainTex_ST;
            uniform float _FlowAngle;
            uniform float _node_7125;
            uniform sampler2D _node_9033; uniform float4 _node_9033_ST;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                float3 tangentDir : TEXCOORD3;
                float3 bitangentDir : TEXCOORD4;
                LIGHTING_COORDS(5,6)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.tangentDir = normalize( mul( unity_ObjectToWorld, float4( v.tangent.xyz, 0.0 ) ).xyz );
                o.bitangentDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex );
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float4 _node_9033_var = tex2D(_node_9033,TRANSFORM_TEX(i.uv0, _node_9033));
                float3 normalLocal = _node_9033_var.rgb;
                float3 normalDirection = normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
                float3 lightColor = _LightColor0.rgb;
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
///////// Gloss:
                float gloss = 0.5;
                float specPow = exp2( gloss * 10.0+1.0);
////// Specular:
                float NdotL = max(0, dot( normalDirection, lightDirection ));
                float3 specularColor = float3(_node_7125,_node_7125,_node_7125);
                float3 directSpecular = attenColor * pow(max(0,dot(halfDirection,normalDirection)),specPow)*specularColor;
                float3 specular = directSpecular;
/////// Diffuse:
                NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 directDiffuse = max( 0.0, NdotL) * attenColor;
                float3 diffuseColor = float3(_node_7125,_node_7125,_node_7125);
                float3 diffuse = directDiffuse * diffuseColor;
/// Final Color:
                float3 finalColor = diffuse + specular;
                float4 node_7058 = _Time + _TimeEditor;
                float node_3853_ang = (3.141592654*_FlowAngle);
                float node_3853_spd = 1.0;
                float node_3853_cos = cos(node_3853_spd*node_3853_ang);
                float node_3853_sin = sin(node_3853_spd*node_3853_ang);
                float2 node_3853_piv = float2(0.5,0.5);
                float2 node_3853 = (mul(i.uv0-node_3853_piv,float2x2( node_3853_cos, -node_3853_sin, node_3853_sin, node_3853_cos))+node_3853_piv);
                float2 node_1219 = (node_3853+(node_7058.g*_FlowSpeed)*float2(0,-0.2));
                float4 _MainTex_var = tex2D(_MainTex,TRANSFORM_TEX(node_1219, _MainTex));
                return fixed4(finalColor * _MainTex_var.a,0);
            }
            ENDCG
        }
    }
    FallBack "Mobile/Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
