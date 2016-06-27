using UnityEngine;
using UnityEditor;
using ProBuilder2.Common;
using ProBuilder2.EditorCommon;
using ProBuilder2.Interface;
using System.Linq;

namespace ProBuilder2.Actions
{
	public class SmartConnect : pb_MenuAction
	{
		public override pb_IconGroup group { get { return pb_IconGroup.Geometry; } }
		public override Texture2D icon { get { return null; } }
		public override pb_TooltipContent tooltip { get { return _tooltip; } }
		public override bool isProOnly { get { return true; } }

		static readonly pb_TooltipContent _tooltip = new pb_TooltipContent
		(
			"Smart Connect",
			"",
			CMD_ALT, 'E'
		);

		public override bool IsEnabled()
		{
			return pb_Editor.instance != null &&
					pb_Editor.instance.editLevel == EditLevel.Geometry &&
					selection != null &&
					selection.Length > 0 &&
					selection.Any(x => x.SelectedTriangleCount > 1);
		}

		public override pb_ActionResult DoAction()
		{
			switch(pb_Editor.instance.selectionMode)
			{
				case SelectMode.Vertex:
					return pb_Menu_Commands.MenuConnectVertices(selection);

				case SelectMode.Edge:
					return pb_Menu_Commands.MenuConnectEdges(selection);

				default:
					return pb_Menu_Commands.MenuSubdivideFace(selection);
			}
		}
	}
}
