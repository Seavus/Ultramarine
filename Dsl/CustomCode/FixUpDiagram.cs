using System.Collections.Generic;
using Microsoft.VisualStudio.Modeling;
using Microsoft.VisualStudio.Modeling.Diagrams;

namespace Ultramarine.Generators.Language
{
    partial class FixUpDiagram
    {
        private ModelElement GetParentForCompositeTask(CompositeTask task)
        {
            return task.Parent;
        }
    }

    partial class TaskShape
    {
        protected RectangleD ExpandedBounds;
        public override bool AllowsChildrenToResizeParent => true;
        public override SizeD MinimumResizableSize => this.CalculateMinimumSizeBasedOnChildren();

        protected override void Collapse()
        {
            base.Collapse();
            this.ExpandedBounds = this.Bounds;
            this.Bounds = this.AbsoluteBounds;
            this.AbsoluteBounds = new RectangleD(this.Location, new SizeD(1.5, 0.3));
        }

        protected override void Expand()
        {
            base.Expand();
            this.Bounds = this.ExpandedBounds;
        }

    }

    partial class TaskShape
    {
        
    }
}
