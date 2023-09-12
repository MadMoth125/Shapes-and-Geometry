using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class Triangle : Shape
{
	[Range(0.1f, 10.0f)]
	public float legWidth = 1.0f;
	[Range(0.1f, 10.0f)]
	public float legHeight = 1.0f;
	public float Hypotenuse { get; protected set; }
	private Vector3 LegWidthVector => new(legWidth, 0f, 0f);
	private Vector3 LegHeightVector => new(0f, legHeight, 0f);

	public bool autoOffset = false;
	
	private void Start()
	{
		InitMesh();
		GenerateTriangle();
	}

	private void Update()
	{
		GenerateTriangle();
	}

	public override float GetShapeArea()
	{
		Area = (legWidth * legHeight) / 2;
		return Area;
	}

	public override float GetShapePerimeter()
	{
		Perimeter = legWidth + legHeight + GetHypotenuse();
		return Perimeter;
	}
	
	public float GetHypotenuse()
	{
		Hypotenuse = Mathf.Sqrt(Mathf.Pow(legWidth, 2) + Mathf.Pow(legHeight, 2));
		return Hypotenuse;
	}
	
	#region Mesh Generation
	
	// Variables for the mesh
	private MeshFilter _meshFilter;
	private Mesh _mesh;
	private Vector3 _meshOffset;
	
	// Variables for the mesh data
	private Vector3[] _vertices;
	private int[] _triangles;
	private Vector3[] _normals;
	private Vector2[] _uv;
	
	private void InitMesh()
	{
		// Get/create mesh components
		_meshFilter = GetComponent<MeshFilter>();
		_mesh = new Mesh();
		_meshFilter.mesh = _mesh;
		
		_vertices = new Vector3[3]; // Define vertices for the triangle
		
		_triangles = new int[3] { 0, 1, 2 }; // Define triangles (clockwise order)
		
		_normals = new Vector3[3]; // Define normals (assuming all face outward)
		
		_uv = new Vector2[3]; // Define UV coordinates
	}
	
	private void GenerateTriangle()
	{
		UpdateVerts();
		UpdateNormals();
		UpdateUVs();

		// Assign data to the mesh
		_mesh.vertices = _vertices;
		_mesh.triangles = _triangles;
		_mesh.normals = _normals;
		_mesh.uv = _uv;
	}
	
	private void UpdateVerts()
	{
		if (autoOffset)
		{
			_meshOffset.x = legWidth / 2;
			_meshOffset.y = legHeight / 2;
			_meshOffset.z = 0f;
		}
		else
		{
			_meshOffset = Vector3.zero;
		}
		
		_vertices[0] = Vector3.zero; // Vertex at the origin
		
		_vertices[1] = LegWidthVector; // Vertex at the end of the legWidth
		
		_vertices[2] = LegHeightVector; // Vertex at the end of the legHeight

		for (int i = 0; i < _vertices.Length; i++)
		{
			_vertices[i] -= _meshOffset;
		}
	}

	private void UpdateNormals()
	{
		for (int i = 0; i < 3; i++)
		{
			_normals[i] = -Vector3.forward;
		}
	}
	
	private void UpdateUVs()
	{
		_uv[0] = new Vector2(0, 0);
		_uv[1] = new Vector2(1, 0);
		_uv[2] = new Vector2(0, 1);
	}
	#endregion
	
}
