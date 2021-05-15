// =====================================================
// DO NOT EDIT - this file is automatically regenerated.
// =====================================================

using UnityEngine.UIElements;
using UnityEditor.UIElements;
using Improbable.Gdk.Debug.WorkerInspector.Codegen;

namespace Improbable
{
    public class ComponentInterestRenderer : SchemaTypeVisualElement<global::Improbable.ComponentInterest>
    {
        private readonly PaginatedListView<global::Improbable.ComponentInterestRenderer.QueryRenderer, global::Improbable.ComponentInterest.Query> queriesField;

        public ComponentInterestRenderer(string label, uint nest) : base(label)
        {
            queriesField = new PaginatedListView<global::Improbable.ComponentInterestRenderer.QueryRenderer, global::Improbable.ComponentInterest.Query>("Queries", () => {
            var inner = new global::Improbable.ComponentInterestRenderer.QueryRenderer("", nest + 1 + 1);
            return inner; }, (index, data, element) => {
            element.Label = $"Item {index + 1}";
            element.Update(data);
            });
            Container.Add(queriesField);
        }

        public override void Update(global::Improbable.ComponentInterest data)
        {
            queriesField.Update(data.Queries);
        }

        public class QueryRenderer : SchemaTypeVisualElement<global::Improbable.ComponentInterest.Query>
        {
            private readonly global::Improbable.ComponentInterestRenderer.QueryConstraintRenderer constraintField;
            private readonly NullableVisualElement<Toggle, bool> fullSnapshotResultField;
            private readonly PaginatedListView<TextField, uint> resultComponentIdField;
            private readonly NullableVisualElement<TextField, float> frequencyField;

            public QueryRenderer(string label, uint nest) : base(label)
            {
                constraintField = new global::Improbable.ComponentInterestRenderer.QueryConstraintRenderer("Constraint", nest + 1);
                Container.Add(constraintField);

                var fullSnapshotResultInnerField = new Toggle("Value");
                fullSnapshotResultInnerField.labelElement.ShiftRightMargin(nest + 1);
                fullSnapshotResultInnerField.SetEnabled(false);
                fullSnapshotResultField = new NullableVisualElement<Toggle, bool>("Full Snapshot Result", fullSnapshotResultInnerField, (element, data) => { element.value = data; });
                Container.Add(fullSnapshotResultField);

                resultComponentIdField = new PaginatedListView<TextField, uint>("Result Component Id", () => {
                var inner = new TextField("");
                inner.labelElement.ShiftRightMargin(nest + 1);
                inner.SetEnabled(false);
                return inner; }, (index, data, element) => {
                element.label = $"Item {index + 1}";
                element.value = data.ToString();
                });
                Container.Add(resultComponentIdField);

                var frequencyInnerField = new TextField("Value");
                frequencyInnerField.labelElement.ShiftRightMargin(nest + 1);
                frequencyInnerField.SetEnabled(false);
                frequencyField = new NullableVisualElement<TextField, float>("Frequency", frequencyInnerField, (element, data) => { element.value = data.ToString(); });
                Container.Add(frequencyField);
            }

            public override void Update(global::Improbable.ComponentInterest.Query data)
            {
                constraintField.Update(data.Constraint);
                fullSnapshotResultField.Update(data.FullSnapshotResult);
                resultComponentIdField.Update(data.ResultComponentId);
                frequencyField.Update(data.Frequency);
            }
        }

        public class QueryConstraintRenderer : SchemaTypeVisualElement<global::Improbable.ComponentInterest.QueryConstraint>
        {
            private readonly NullableVisualElement<global::Improbable.ComponentInterestRenderer.SphereConstraintRenderer, global::Improbable.ComponentInterest.SphereConstraint> sphereConstraintField;
            private readonly NullableVisualElement<global::Improbable.ComponentInterestRenderer.CylinderConstraintRenderer, global::Improbable.ComponentInterest.CylinderConstraint> cylinderConstraintField;
            private readonly NullableVisualElement<global::Improbable.ComponentInterestRenderer.BoxConstraintRenderer, global::Improbable.ComponentInterest.BoxConstraint> boxConstraintField;
            private readonly NullableVisualElement<global::Improbable.ComponentInterestRenderer.RelativeSphereConstraintRenderer, global::Improbable.ComponentInterest.RelativeSphereConstraint> relativeSphereConstraintField;
            private readonly NullableVisualElement<global::Improbable.ComponentInterestRenderer.RelativeCylinderConstraintRenderer, global::Improbable.ComponentInterest.RelativeCylinderConstraint> relativeCylinderConstraintField;
            private readonly NullableVisualElement<global::Improbable.ComponentInterestRenderer.RelativeBoxConstraintRenderer, global::Improbable.ComponentInterest.RelativeBoxConstraint> relativeBoxConstraintField;
            private readonly NullableVisualElement<TextField, long> entityIdConstraintField;
            private readonly NullableVisualElement<TextField, uint> componentConstraintField;
            private readonly PaginatedListView<global::Improbable.ComponentInterestRenderer.QueryConstraintRenderer, global::Improbable.ComponentInterest.QueryConstraint> andConstraintField;
            private readonly PaginatedListView<global::Improbable.ComponentInterestRenderer.QueryConstraintRenderer, global::Improbable.ComponentInterest.QueryConstraint> orConstraintField;

            public QueryConstraintRenderer(string label, uint nest) : base(label)
            {
                var sphereConstraintInnerField = new global::Improbable.ComponentInterestRenderer.SphereConstraintRenderer("Value", nest + 1 + 1);
                sphereConstraintField = new NullableVisualElement<global::Improbable.ComponentInterestRenderer.SphereConstraintRenderer, global::Improbable.ComponentInterest.SphereConstraint>("Sphere Constraint", sphereConstraintInnerField, (element, data) => { element.Update(data); });
                Container.Add(sphereConstraintField);

                var cylinderConstraintInnerField = new global::Improbable.ComponentInterestRenderer.CylinderConstraintRenderer("Value", nest + 1 + 1);
                cylinderConstraintField = new NullableVisualElement<global::Improbable.ComponentInterestRenderer.CylinderConstraintRenderer, global::Improbable.ComponentInterest.CylinderConstraint>("Cylinder Constraint", cylinderConstraintInnerField, (element, data) => { element.Update(data); });
                Container.Add(cylinderConstraintField);

                var boxConstraintInnerField = new global::Improbable.ComponentInterestRenderer.BoxConstraintRenderer("Value", nest + 1 + 1);
                boxConstraintField = new NullableVisualElement<global::Improbable.ComponentInterestRenderer.BoxConstraintRenderer, global::Improbable.ComponentInterest.BoxConstraint>("Box Constraint", boxConstraintInnerField, (element, data) => { element.Update(data); });
                Container.Add(boxConstraintField);

                var relativeSphereConstraintInnerField = new global::Improbable.ComponentInterestRenderer.RelativeSphereConstraintRenderer("Value", nest + 1 + 1);
                relativeSphereConstraintField = new NullableVisualElement<global::Improbable.ComponentInterestRenderer.RelativeSphereConstraintRenderer, global::Improbable.ComponentInterest.RelativeSphereConstraint>("Relative Sphere Constraint", relativeSphereConstraintInnerField, (element, data) => { element.Update(data); });
                Container.Add(relativeSphereConstraintField);

                var relativeCylinderConstraintInnerField = new global::Improbable.ComponentInterestRenderer.RelativeCylinderConstraintRenderer("Value", nest + 1 + 1);
                relativeCylinderConstraintField = new NullableVisualElement<global::Improbable.ComponentInterestRenderer.RelativeCylinderConstraintRenderer, global::Improbable.ComponentInterest.RelativeCylinderConstraint>("Relative Cylinder Constraint", relativeCylinderConstraintInnerField, (element, data) => { element.Update(data); });
                Container.Add(relativeCylinderConstraintField);

                var relativeBoxConstraintInnerField = new global::Improbable.ComponentInterestRenderer.RelativeBoxConstraintRenderer("Value", nest + 1 + 1);
                relativeBoxConstraintField = new NullableVisualElement<global::Improbable.ComponentInterestRenderer.RelativeBoxConstraintRenderer, global::Improbable.ComponentInterest.RelativeBoxConstraint>("Relative Box Constraint", relativeBoxConstraintInnerField, (element, data) => { element.Update(data); });
                Container.Add(relativeBoxConstraintField);

                var entityIdConstraintInnerField = new TextField("Value");
                entityIdConstraintInnerField.labelElement.ShiftRightMargin(nest + 1);
                entityIdConstraintInnerField.SetEnabled(false);
                entityIdConstraintField = new NullableVisualElement<TextField, long>("Entity Id Constraint", entityIdConstraintInnerField, (element, data) => { element.value = data.ToString(); });
                Container.Add(entityIdConstraintField);

                var componentConstraintInnerField = new TextField("Value");
                componentConstraintInnerField.labelElement.ShiftRightMargin(nest + 1);
                componentConstraintInnerField.SetEnabled(false);
                componentConstraintField = new NullableVisualElement<TextField, uint>("Component Constraint", componentConstraintInnerField, (element, data) => { element.value = data.ToString(); });
                Container.Add(componentConstraintField);

                andConstraintField = new PaginatedListView<global::Improbable.ComponentInterestRenderer.QueryConstraintRenderer, global::Improbable.ComponentInterest.QueryConstraint>("And Constraint", () => {
                var inner = new global::Improbable.ComponentInterestRenderer.QueryConstraintRenderer("", nest + 1 + 1);
                return inner; }, (index, data, element) => {
                element.Label = $"Item {index + 1}";
                element.Update(data);
                });
                Container.Add(andConstraintField);

                orConstraintField = new PaginatedListView<global::Improbable.ComponentInterestRenderer.QueryConstraintRenderer, global::Improbable.ComponentInterest.QueryConstraint>("Or Constraint", () => {
                var inner = new global::Improbable.ComponentInterestRenderer.QueryConstraintRenderer("", nest + 1 + 1);
                return inner; }, (index, data, element) => {
                element.Label = $"Item {index + 1}";
                element.Update(data);
                });
                Container.Add(orConstraintField);
            }

            public override void Update(global::Improbable.ComponentInterest.QueryConstraint data)
            {
                sphereConstraintField.Update(data.SphereConstraint);
                cylinderConstraintField.Update(data.CylinderConstraint);
                boxConstraintField.Update(data.BoxConstraint);
                relativeSphereConstraintField.Update(data.RelativeSphereConstraint);
                relativeCylinderConstraintField.Update(data.RelativeCylinderConstraint);
                relativeBoxConstraintField.Update(data.RelativeBoxConstraint);
                entityIdConstraintField.Update(data.EntityIdConstraint);
                componentConstraintField.Update(data.ComponentConstraint);
                andConstraintField.Update(data.AndConstraint);
                orConstraintField.Update(data.OrConstraint);
            }
        }

        public class SphereConstraintRenderer : SchemaTypeVisualElement<global::Improbable.ComponentInterest.SphereConstraint>
        {
            private readonly global::Improbable.CoordinatesRenderer centerField;
            private readonly TextField radiusField;

            public SphereConstraintRenderer(string label, uint nest) : base(label)
            {
                centerField = new global::Improbable.CoordinatesRenderer("Center", nest + 1);
                Container.Add(centerField);

                radiusField = new TextField("Radius");
                radiusField.labelElement.ShiftRightMargin(nest);
                radiusField.SetEnabled(false);
                Container.Add(radiusField);
            }

            public override void Update(global::Improbable.ComponentInterest.SphereConstraint data)
            {
                centerField.Update(data.Center);
                radiusField.value = data.Radius.ToString();
            }
        }

        public class CylinderConstraintRenderer : SchemaTypeVisualElement<global::Improbable.ComponentInterest.CylinderConstraint>
        {
            private readonly global::Improbable.CoordinatesRenderer centerField;
            private readonly TextField radiusField;

            public CylinderConstraintRenderer(string label, uint nest) : base(label)
            {
                centerField = new global::Improbable.CoordinatesRenderer("Center", nest + 1);
                Container.Add(centerField);

                radiusField = new TextField("Radius");
                radiusField.labelElement.ShiftRightMargin(nest);
                radiusField.SetEnabled(false);
                Container.Add(radiusField);
            }

            public override void Update(global::Improbable.ComponentInterest.CylinderConstraint data)
            {
                centerField.Update(data.Center);
                radiusField.value = data.Radius.ToString();
            }
        }

        public class BoxConstraintRenderer : SchemaTypeVisualElement<global::Improbable.ComponentInterest.BoxConstraint>
        {
            private readonly global::Improbable.CoordinatesRenderer centerField;
            private readonly global::Improbable.EdgeLengthRenderer edgeLengthField;

            public BoxConstraintRenderer(string label, uint nest) : base(label)
            {
                centerField = new global::Improbable.CoordinatesRenderer("Center", nest + 1);
                Container.Add(centerField);

                edgeLengthField = new global::Improbable.EdgeLengthRenderer("Edge Length", nest + 1);
                Container.Add(edgeLengthField);
            }

            public override void Update(global::Improbable.ComponentInterest.BoxConstraint data)
            {
                centerField.Update(data.Center);
                edgeLengthField.Update(data.EdgeLength);
            }
        }

        public class RelativeSphereConstraintRenderer : SchemaTypeVisualElement<global::Improbable.ComponentInterest.RelativeSphereConstraint>
        {
            private readonly TextField radiusField;

            public RelativeSphereConstraintRenderer(string label, uint nest) : base(label)
            {
                radiusField = new TextField("Radius");
                radiusField.labelElement.ShiftRightMargin(nest);
                radiusField.SetEnabled(false);
                Container.Add(radiusField);
            }

            public override void Update(global::Improbable.ComponentInterest.RelativeSphereConstraint data)
            {
                radiusField.value = data.Radius.ToString();
            }
        }

        public class RelativeCylinderConstraintRenderer : SchemaTypeVisualElement<global::Improbable.ComponentInterest.RelativeCylinderConstraint>
        {
            private readonly TextField radiusField;

            public RelativeCylinderConstraintRenderer(string label, uint nest) : base(label)
            {
                radiusField = new TextField("Radius");
                radiusField.labelElement.ShiftRightMargin(nest);
                radiusField.SetEnabled(false);
                Container.Add(radiusField);
            }

            public override void Update(global::Improbable.ComponentInterest.RelativeCylinderConstraint data)
            {
                radiusField.value = data.Radius.ToString();
            }
        }

        public class RelativeBoxConstraintRenderer : SchemaTypeVisualElement<global::Improbable.ComponentInterest.RelativeBoxConstraint>
        {
            private readonly global::Improbable.EdgeLengthRenderer edgeLengthField;

            public RelativeBoxConstraintRenderer(string label, uint nest) : base(label)
            {
                edgeLengthField = new global::Improbable.EdgeLengthRenderer("Edge Length", nest + 1);
                Container.Add(edgeLengthField);
            }

            public override void Update(global::Improbable.ComponentInterest.RelativeBoxConstraint data)
            {
                edgeLengthField.Update(data.EdgeLength);
            }
        }
    }
}
