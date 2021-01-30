Shader "Shaders/OneRawColor"
{
    Properties
    {
        _Color("My Custom Color", Color) = (1, 1, 1, 1)
    }

    SubShader
    {
        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            float4 _Color;

            

            struct VertexShaderInput
            {
                float4 vertex: POSITION;
            };

            struct VertexShaderOutput
            {
                float4 pos: SV_POSITION;
            };

            VertexShaderOutput vert (VertexShaderInput v)
            {
                VertexShaderOutput o;

                o.pos = UnityObjectToClipPos(v.vertex);

                return o;
            };

            float4 frag(VertexShaderOutput i):SV_TARGET
            {
                return _Color;
            };

            ENDCG
        }
    }
}