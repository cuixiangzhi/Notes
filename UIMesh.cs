using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class UIMesh : MonoBehaviour 
{
	public Mesh mMesh;
	public MeshRenderer mMeshRender;
	public MeshFilter mMeshFilter;
	public Font mFont;
	public Texture mTexture;
	public Material mMat;

	public void OnEnable()
	{
		mMesh = new Mesh();
		Vector3[] vertex = new Vector3[]
		{
			new Vector3(0,0,0),
			new Vector3(0,4,0),
			new Vector3(4,4,0),
			new Vector3(4,0,0)
		};
		int[] triangle = new int[]
		{
			0,1,2,
			2,3,0
		};
		Vector2[] uvs = new Vector2[]
		{
			new Vector2(0,0),
			new Vector2(0,0.5f),
			new Vector2(0.5f,0.5f),
			new Vector2(0.5f,0)
		};
		mMesh.vertices = vertex;
		mMesh.triangles = triangle;
		mMesh.uv = uvs;

		var go = new GameObject("UIMesh");
		mMeshFilter = go.AddComponent<MeshFilter>();
		mMeshFilter.mesh = mMesh;
		mMeshRender = go.AddComponent<MeshRenderer>();
		mMeshRender.shadowCastingMode = ShadowCastingMode.Off;
		mMeshRender.receiveShadows = false;
		mMeshRender.lightProbeUsage = LightProbeUsage.Off;
		mMeshRender.reflectionProbeUsage = ReflectionProbeUsage.Off;
		mMeshRender.allowOcclusionWhenDynamic = false;
		mMeshRender.motionVectorGenerationMode = MotionVectorGenerationMode.ForceNoMotion;
		mMeshRender.sharedMaterial = mMat;
		Font.textureRebuilt += OnFontReBuilt;
		OnFontReBuilt(mFont);
	}

	void OnFontReBuilt(Font font)
	{
		mFont.RequestCharactersInTexture("哈哈姓名版测试版测试坎坎坷坷扩啊实打实大师大人达尔富婆癌发生偏差vas",40,FontStyle.Normal);
		mMat.mainTexture = mFont.material.mainTexture;
		mMat.mainTextureOffset = mFont.material.mainTextureOffset;
		mMat.mainTextureScale = mFont.material.mainTextureScale;
	}
}
