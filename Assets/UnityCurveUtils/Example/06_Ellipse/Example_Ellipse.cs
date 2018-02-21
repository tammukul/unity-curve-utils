﻿using System.Linq;
using UnityEngine;

/// <summary>
/// インボリュート曲線のサンプル
/// </summary>
public class Example_Ellipse : MonoBehaviour
{
	public LineRenderer lineRenderer;

	[Range( -5, 5 )] public float m_a;
	[Range( -5, 5 )] public float m_b;

	private void Update()
	{
		var positions = Enumerable
			.Range( 0, 500 )
			.Select( c => UnityCurveUtils.Ellipse( m_a, m_b, c / 10f ) )
			.Select( c => new Vector3( c.x, c.y ) )
			.ToArray()
		;

		lineRenderer.positionCount = positions.Length;
		lineRenderer.SetPositions( positions );
	}

	private void OnGUI()
	{
		m_a = GUILayout.HorizontalSlider( m_a, -2, 2, GUILayout.Width( 100 ) );
		m_b = GUILayout.HorizontalSlider( m_b, -2, 2, GUILayout.Width( 100 ) );
	}
}