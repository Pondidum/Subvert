using System;
using Spark;

namespace Subvert.Spark
{
	public abstract class SubvertSparkView : SparkViewBase
	{
	}

	public class SubvertSparkView<TViewModel> : SubvertSparkView, ISettableModel where TViewModel : class
	{
		private readonly Guid _id;

		public override Guid GeneratedViewId { get { return _id; } }
		public TViewModel Model { get; private set; }

		public SubvertSparkView()
		{
			_id = Guid.NewGuid();
		}

		public override void Render()
		{
			RenderView(Output);
		}

		public void SetModel(object model)
		{
			Model = (TViewModel)model;
		}
	}
}
