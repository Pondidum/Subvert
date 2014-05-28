using System;
using System.IO;

namespace Subvert.Spark
{
	internal interface ISettableModel
	{
		void SetModel(Object model);
		void RenderView(TextWriter writer);
	}
}
