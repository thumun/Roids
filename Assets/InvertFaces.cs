using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// borrowed from here: https://discussions.unity.com/t/how-to-create-a-spherical-skybox/177971/2
// to make spherical skybox
public class InvertFaces : MonoBehaviour
{
	public bool invert = true;
	public bool InvertNormals = true;
	void Start()
	{
		var mf = GetComponent<MeshFilter>();
		if (mf != null)
		{
			var m = Instantiate(mf.sharedMesh);
			Process(m);
			mf.sharedMesh = m;
		}
		var smr = GetComponent<SkinnedMeshRenderer>();
		if (smr != null)
		{
			var m = Instantiate(smr.sharedMesh);
			Process(m);
			smr.sharedMesh = m;
		}
	}

	private void Process(Mesh m)
	{
		int subMeshes = m.subMeshCount;
		for (int i = 0; i < subMeshes; i++)
		{
			if (invert)
			{
				var type = m.GetTopology(i);
				var indices = m.GetIndices(i);
				if (type == MeshTopology.Quads)
				{
					for (int n = 0; n < indices.Length; n += 4)
					{
						int tmp = indices[n];
						indices[n] = indices[n + 3];
						indices[n + 3] = tmp;
						tmp = indices[n + 1];
						indices[n + 1] = indices[n + 2];
						indices[n + 2] = tmp;
					}
				}
				else if (type == MeshTopology.Triangles)
				{
					for (int n = 0; n < indices.Length; n += 3)
					{
						int tmp = indices[n];
						indices[n] = indices[n + 1];
						indices[n + 1] = tmp;
					}
				}
				m.SetIndices(indices, type, i);
			}
		}
		if (InvertNormals)
		{
			var normals = m.normals;
			for (int n = 0; n < normals.Length; n++)
				normals[n] = -normals[n];
			m.normals = normals;
		}
	}
}
