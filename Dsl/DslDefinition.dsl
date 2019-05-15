<?xml version="1.0" encoding="utf-8"?>
<Dsl xmlns:dm0="http://schemas.microsoft.com/VisualStudio/2008/DslTools/Core" dslVersion="1.0.0.0" Id="fa460004-c689-4b79-9838-fd3850db6a1e" Description="Description for Ultramarine.Generators.Language.GeneratorLanguage" Name="GeneratorLanguage" DisplayName="GeneratorLanguage" Namespace="Ultramarine.Generators.Language" ProductName="Ultramarine" CompanyName="Seavus" PackageGuid="253eb726-92cb-4387-9f64-2ca8bbc1e16a" PackageNamespace="Ultramarine.Generators.Language" xmlns="http://schemas.microsoft.com/VisualStudio/2005/DslTools/DslDefinitionModel">
  <Classes>
    <DomainClass Id="998d169c-4479-4c51-afb7-ac84ad68d0a9" Description="The root in which all other elements are embedded. Appears as a diagram." Name="Generator" DisplayName="Generator" Namespace="Ultramarine.Generators.Language">
      <BaseClass>
        <DomainClassMoniker Name="CompositeTask" />
      </BaseClass>
    </DomainClass>
    <DomainClass Id="eb42e64f-0ae3-4a9b-9435-7bc6dee5d967" Description="Description for Ultramarine.Generators.Language.Task" Name="Task" DisplayName="Task" InheritanceModifier="Abstract" Namespace="Ultramarine.Generators.Language">
      <Properties>
        <DomainProperty Id="8a36f86e-184d-4bbe-b86b-5b8f2c5de493" Description="Description for Ultramarine.Generators.Language.Task.Name" Name="Name" DisplayName="Name" IsElementName="true">
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="2bafcdc0-ca91-45b0-ad72-8cdd1dc8a35b" Description="Description for Ultramarine.Generators.Language.Task.Description" Name="Description" DisplayName="Description">
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
      </Properties>
    </DomainClass>
    <DomainClass Id="44a54f0c-0084-44e3-b7b9-1e8f0f4ef3cc" Description="Description for Ultramarine.Generators.Language.CompositeTask" Name="CompositeTask" DisplayName="Composite Task" InheritanceModifier="Abstract" Namespace="Ultramarine.Generators.Language">
      <BaseClass>
        <DomainClassMoniker Name="Task" />
      </BaseClass>
      <ElementMergeDirectives>
        <ElementMergeDirective>
          <Index>
            <DomainClassMoniker Name="Task" />
          </Index>
          <LinkCreationPaths>
            <DomainPath>Children.Tasks</DomainPath>
          </LinkCreationPaths>
        </ElementMergeDirective>
      </ElementMergeDirectives>
    </DomainClass>
    <DomainClass Id="e88bb8c2-2e3e-4337-9b4a-ba0134771eb0" Description="Description for Ultramarine.Generators.Language.LoadCodeElement" Name="LoadCodeElement" DisplayName="Load Code Element" Namespace="Ultramarine.Generators.Language">
      <BaseClass>
        <DomainClassMoniker Name="Task" />
      </BaseClass>
      <Properties>
        <DomainProperty Id="3bbe6d15-5211-403e-8cad-4f065140ae21" Description="Description for Ultramarine.Generators.Language.LoadCodeElement.Element Name" Name="ElementName" DisplayName="Element Name" Category="Settings">
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="8427b3e8-364c-4296-bfe7-47567c7b1efd" Description="Description for Ultramarine.Generators.Language.LoadCodeElement.Element Type" Name="ElementType" DisplayName="Element Type" Category="Settings">
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="c743c13e-f643-464a-a943-d643a4bf040a" Description="Description for Ultramarine.Generators.Language.LoadCodeElement.Element Access" Name="ElementAccess" DisplayName="Element Access" Category="Settings">
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="84636b5c-8348-4063-b1a8-48516cccb759" Description="Description for Ultramarine.Generators.Language.LoadCodeElement.Element Override" Name="ElementOverride" DisplayName="Element Override" Category="Settings">
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="f8bd1678-2988-4bb2-a5a9-05128fdf9188" Description="Description for Ultramarine.Generators.Language.LoadCodeElement.Type Of" Name="TypeOf" DisplayName="Type Of" Category="Settings">
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
      </Properties>
    </DomainClass>
    <DomainClass Id="c485d0c8-53cb-4700-b9cd-c3df4a47eb15" Description="Description for Ultramarine.Generators.Language.BuildProject" Name="BuildProject" DisplayName="Build Project" Namespace="Ultramarine.Generators.Language">
      <BaseClass>
        <DomainClassMoniker Name="Task" />
      </BaseClass>
      <Properties>
        <DomainProperty Id="2c4ce0b6-c357-421c-a00d-b0e3ba8bec82" Description="Name of the project to build" Name="ProjectName" DisplayName="Project name" Category="Settings">
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="6ea6184d-c953-4035-ae6b-27f14e524314" Description="Project configuration to build" Name="Configuration" DisplayName="Configuration" DefaultValue="Debug" Category="Settings">
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
      </Properties>
    </DomainClass>
    <DomainClass Id="40bc53f4-bbd4-477a-9afe-d9c3e3ca8e63" Description="Description for Ultramarine.Generators.Language.CreateFolder" Name="CreateFolder" DisplayName="Create Folder" Namespace="Ultramarine.Generators.Language">
      <BaseClass>
        <DomainClassMoniker Name="Task" />
      </BaseClass>
      <Properties>
        <DomainProperty Id="0bd209e8-d065-4beb-a785-b4b43ea4223a" Description="Description for Ultramarine.Generators.Language.CreateFolder.Folder Path" Name="FolderPath" DisplayName="Folder Path" Category="Settings">
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="360efd74-a299-49c0-88f4-f01f345b2387" Description="Description for Ultramarine.Generators.Language.CreateFolder.Base Path" Name="BasePath" DisplayName="Base Path" Category="Settings">
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
      </Properties>
    </DomainClass>
    <DomainClass Id="82ab47c8-1755-4e0d-b939-2f5aa4eb8e33" Description="Description for Ultramarine.Generators.Language.CreateProjectItem" Name="CreateProjectItem" DisplayName="Create Project Item" Namespace="Ultramarine.Generators.Language">
      <BaseClass>
        <DomainClassMoniker Name="Task" />
      </BaseClass>
      <Properties>
        <DomainProperty Id="739ebe60-22b8-4209-819b-937af6c3274a" Description="Description for Ultramarine.Generators.Language.CreateProjectItem.Item Name" Name="ItemName" DisplayName="Item Name" Category="Settings">
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="38d4fe11-243a-4767-a37c-dec047d5515b" Description="Description for Ultramarine.Generators.Language.CreateProjectItem.Folder Path" Name="FolderPath" DisplayName="Folder Path" Category="Settings">
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="a814346f-0fb9-465e-b6ff-e3d5df39a9b3" Description="Description for Ultramarine.Generators.Language.CreateProjectItem.Linked With" Name="LinkedWith" DisplayName="Linked With" Category="Settings">
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="af1ceb4a-ec36-437c-b810-8fb31e5e374b" Description="Description for Ultramarine.Generators.Language.CreateProjectItem.Project Name" Name="ProjectName" DisplayName="Project Name" Category="Settings">
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="7bcd5863-138d-4692-ba1a-09b6dda26285" Description="Description for Ultramarine.Generators.Language.CreateProjectItem.Overwrite" Name="Overwrite" DisplayName="Overwrite" Category="Settings">
          <Type>
            <ExternalTypeMoniker Name="/System/Boolean" />
          </Type>
        </DomainProperty>
      </Properties>
    </DomainClass>
    <DomainClass Id="feaf6d65-bedd-4b04-91c5-d0226176c21a" Description="Description for Ultramarine.Generators.Language.LoadProjectItem" Name="LoadProjectItem" DisplayName="Load Project Item" Namespace="Ultramarine.Generators.Language">
      <BaseClass>
        <DomainClassMoniker Name="Task" />
      </BaseClass>
      <Properties>
        <DomainProperty Id="d2100451-3c56-434a-8c7f-b6935b11c65a" Description="Description for Ultramarine.Generators.Language.LoadProjectItem.Project Name" Name="ProjectName" DisplayName="Project Name">
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="6b3c9a64-adab-4d9f-be52-3e27a3194852" Description="Description for Ultramarine.Generators.Language.LoadProjectItem.Item Name" Name="ItemName" DisplayName="Item Name">
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="d82e00ed-cdd4-4d86-8d4b-340f7944fb46" Description="Description for Ultramarine.Generators.Language.LoadProjectItem.Linked With" Name="LinkedWith" DisplayName="Linked With">
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
      </Properties>
    </DomainClass>
    <DomainClass Id="2a2726ef-e0e8-4b0d-a8f2-37d2f7d03b4c" Description="Description for Ultramarine.Generators.Language.ReadProperty" Name="ReadProperty" DisplayName="Read Property" Namespace="Ultramarine.Generators.Language">
      <BaseClass>
        <DomainClassMoniker Name="Task" />
      </BaseClass>
      <Properties>
        <DomainProperty Id="47796921-bf6b-49db-8e5c-248c3408e0f4" Description="Description for Ultramarine.Generators.Language.ReadProperty.Property Name" Name="PropertyName" DisplayName="Property Name">
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
      </Properties>
    </DomainClass>
    <DomainClass Id="9e35266d-2d6f-4d1c-9ea2-40677ffdaee1" Description="Description for Ultramarine.Generators.Language.SetVariable" Name="SetVariable" DisplayName="Set Variable" Namespace="Ultramarine.Generators.Language">
      <BaseClass>
        <DomainClassMoniker Name="Task" />
      </BaseClass>
      <Properties>
        <DomainProperty Id="9f4ba5ed-94b9-460c-a912-ba7642b0db2e" Description="Description for Ultramarine.Generators.Language.SetVariable.Variable Name" Name="VariableName" DisplayName="Variable Name">
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="509a5ec0-99b0-48f9-a9b0-2cba1dc37855" Description="Description for Ultramarine.Generators.Language.SetVariable.Variable Value" Name="VariableValue" DisplayName="Variable Value">
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="9417475f-713c-4983-a481-af96ebf0e123" Description="Description for Ultramarine.Generators.Language.SetVariable.Parent Task" Name="ParentTask" DisplayName="Parent Task">
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
      </Properties>
    </DomainClass>
    <DomainClass Id="cf3a6e86-268d-4c5d-85e5-54f790a850c5" Description="Description for Ultramarine.Generators.Language.TextTransformation" Name="TextTransformation" DisplayName="Text Transformation" Namespace="Ultramarine.Generators.Language">
      <BaseClass>
        <DomainClassMoniker Name="Task" />
      </BaseClass>
      <Properties>
        <DomainProperty Id="0ec6bd04-5eab-4522-9888-e68def811753" Description="Description for Ultramarine.Generators.Language.TextTransformation.File Name" Name="FileName" DisplayName="File Name">
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="62ae3e3d-ad13-4bee-91d7-a5d4191ede17" Description="Description for Ultramarine.Generators.Language.TextTransformation.Project Name" Name="ProjectName" DisplayName="Project Name">
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="3fbda026-81a0-408e-bb53-4fc02d257317" Description="Description for Ultramarine.Generators.Language.TextTransformation.Parameters" Name="Parameters" DisplayName="Parameters">
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
      </Properties>
    </DomainClass>
    <DomainClass Id="0f981f24-ba7b-496f-aa88-c64c5c8c9a90" Description="Description for Ultramarine.Generators.Language.Iterator" Name="Iterator" DisplayName="Iterator" Namespace="Ultramarine.Generators.Language">
      <BaseClass>
        <DomainClassMoniker Name="CompositeTask" />
      </BaseClass>
    </DomainClass>
  </Classes>
  <Relationships>
    <DomainRelationship Id="190a9443-8fc2-4c0d-9f96-284b404f4f02" Description="Description for Ultramarine.Generators.Language.ConnectedWith" Name="ConnectedWith" DisplayName="Connected With" Namespace="Ultramarine.Generators.Language">
      <Source>
        <DomainRole Id="612cd04d-891f-4238-853a-42d3043d2950" Description="Description for Ultramarine.Generators.Language.ConnectedWith.ConnectedTask" Name="ConnectedTask" DisplayName="Connected Task" PropertyName="TargetTask" Multiplicity="ZeroOne" PropertyDisplayName="Target Task">
          <RolePlayer>
            <DomainClassMoniker Name="Task" />
          </RolePlayer>
        </DomainRole>
      </Source>
      <Target>
        <DomainRole Id="aac64dbc-d054-4374-8d09-cf143ba2017b" Description="Description for Ultramarine.Generators.Language.ConnectedWith.TargetTask" Name="TargetTask" DisplayName="Target Task" PropertyName="ConnectedTasked" PropertyDisplayName="Connected Tasked">
          <RolePlayer>
            <DomainClassMoniker Name="Task" />
          </RolePlayer>
        </DomainRole>
      </Target>
    </DomainRelationship>
    <DomainRelationship Id="11653440-f9a0-4749-a4d5-f01ac7ba4a7b" Description="Description for Ultramarine.Generators.Language.Children" Name="Children" DisplayName="Children" Namespace="Ultramarine.Generators.Language" IsEmbedding="true">
      <Source>
        <DomainRole Id="c9435b94-9cb4-48f4-afc9-0944201baa28" Description="Description for Ultramarine.Generators.Language.Children.CompositeTask" Name="CompositeTask" DisplayName="Composite Task" PropertyName="Tasks" PropagatesCopy="PropagatesCopyToLinkAndOppositeRolePlayer" PropertyDisplayName="Tasks">
          <RolePlayer>
            <DomainClassMoniker Name="CompositeTask" />
          </RolePlayer>
        </DomainRole>
      </Source>
      <Target>
        <DomainRole Id="5b59018b-041e-4314-85bc-fa5f2838fcf2" Description="Description for Ultramarine.Generators.Language.Children.Task" Name="Task" DisplayName="Task" PropertyName="Parent" Multiplicity="One" PropagatesDelete="true" PropertyDisplayName="Parent">
          <RolePlayer>
            <DomainClassMoniker Name="Task" />
          </RolePlayer>
        </DomainRole>
      </Target>
    </DomainRelationship>
  </Relationships>
  <Types>
    <ExternalType Name="DateTime" Namespace="System" />
    <ExternalType Name="String" Namespace="System" />
    <ExternalType Name="Int16" Namespace="System" />
    <ExternalType Name="Int32" Namespace="System" />
    <ExternalType Name="Int64" Namespace="System" />
    <ExternalType Name="UInt16" Namespace="System" />
    <ExternalType Name="UInt32" Namespace="System" />
    <ExternalType Name="UInt64" Namespace="System" />
    <ExternalType Name="SByte" Namespace="System" />
    <ExternalType Name="Byte" Namespace="System" />
    <ExternalType Name="Double" Namespace="System" />
    <ExternalType Name="Single" Namespace="System" />
    <ExternalType Name="Guid" Namespace="System" />
    <ExternalType Name="Boolean" Namespace="System" />
    <ExternalType Name="Char" Namespace="System" />
  </Types>
  <Shapes>
    <GeometryShape Id="58d67238-c826-4929-9037-ad4ca1327d43" Description="Shape used to represent ExampleElements on a Diagram." Name="LoadCodeElementShape" DisplayName="Load Code Element Shape" Namespace="Ultramarine.Generators.Language" FixedTooltipText="Load Code Element Shape" FillColor="255, 153, 204" OutlineColor="113, 111, 110" InitialWidth="2" InitialHeight="0.75" OutlineThickness="0.01" Geometry="Rectangle">
      <Notes>The shape has a text decorator used to display the Name property of the mapped ExampleElement.</Notes>
      <BaseGeometryShape>
        <GeometryShapeMoniker Name="TaskShape" />
      </BaseGeometryShape>
    </GeometryShape>
    <GeometryShape Id="f5e430b0-4664-4db8-bc0c-80dc426c72b6" Description="Description for Ultramarine.Generators.Language.TaskShape" Name="TaskShape" DisplayName="Task Shape" InheritanceModifier="Abstract" Namespace="Ultramarine.Generators.Language" FixedTooltipText="Task Shape" FillColor="234, 234, 236" OutlineColor="Silver" InitialWidth="1.2" InitialHeight="0.75" Geometry="RoundedRectangle">
      <ShapeHasDecorators Position="InnerTopCenter" HorizontalOffset="0" VerticalOffset="0">
        <TextDecorator Name="NameDecorator" DisplayName="Name" DefaultText="Name" FontStyle="Bold" />
      </ShapeHasDecorators>
      <ShapeHasDecorators Position="Center" HorizontalOffset="0" VerticalOffset="0">
        <TextDecorator Name="DescriptionDecorator" DisplayName="Description Decorator" DefaultText="DescriptionDecorator" FontStyle="Italic" />
      </ShapeHasDecorators>
      <ShapeHasDecorators Position="InnerTopRight" HorizontalOffset="0" VerticalOffset="0">
        <ExpandCollapseDecorator Name="ExpanderDecorator" DisplayName="Expander Decorator" />
      </ShapeHasDecorators>
      <ShapeHasDecorators Position="InnerTopCenter" HorizontalOffset="0" VerticalOffset="0.12">
        <TextDecorator Name="TypeDecorator" DisplayName="Type" DefaultText="Type" />
      </ShapeHasDecorators>
    </GeometryShape>
    <GeometryShape Id="450ca504-4e61-482d-aad1-c82e46ac7fd4" Description="Description for Ultramarine.Generators.Language.BuildProjectShape" Name="BuildProjectShape" DisplayName="Build Project Shape" Namespace="Ultramarine.Generators.Language" FixedTooltipText="Build Project Shape" FillColor="215, 220, 230" OutlineColor="Silver" InitialHeight="1" Geometry="RoundedRectangle">
      <BaseGeometryShape>
        <GeometryShapeMoniker Name="TaskShape" />
      </BaseGeometryShape>
    </GeometryShape>
    <GeometryShape Id="2cf43689-bcb0-4e2f-9239-b3cbc86a4c64" Description="Description for Ultramarine.Generators.Language.CreateFolderShape" Name="CreateFolderShape" DisplayName="Create Folder Shape" Namespace="Ultramarine.Generators.Language" FixedTooltipText="Create Folder Shape" InitialHeight="1" Geometry="Rectangle">
      <BaseGeometryShape>
        <GeometryShapeMoniker Name="TaskShape" />
      </BaseGeometryShape>
    </GeometryShape>
    <GeometryShape Id="883ab655-c59b-4963-99e5-2edfdb58bbd8" Description="Description for Ultramarine.Generators.Language.CreateProjectItemShape" Name="CreateProjectItemShape" DisplayName="Create Project Item Shape" Namespace="Ultramarine.Generators.Language" FixedTooltipText="Create Project Item Shape" InitialHeight="1" Geometry="Rectangle">
      <BaseGeometryShape>
        <GeometryShapeMoniker Name="TaskShape" />
      </BaseGeometryShape>
    </GeometryShape>
    <GeometryShape Id="857210ba-a7b4-4fca-9f1c-4a337520227a" Description="Description for Ultramarine.Generators.Language.LoadProjectItemShape" Name="LoadProjectItemShape" DisplayName="Load Project Item Shape" Namespace="Ultramarine.Generators.Language" FixedTooltipText="Load Project Item Shape" InitialHeight="1" Geometry="Rectangle">
      <BaseGeometryShape>
        <GeometryShapeMoniker Name="TaskShape" />
      </BaseGeometryShape>
    </GeometryShape>
    <GeometryShape Id="9ba526a8-3267-41f5-a7b1-767e66ee3463" Description="Description for Ultramarine.Generators.Language.ReadPropertyShape" Name="ReadPropertyShape" DisplayName="Read Property Shape" Namespace="Ultramarine.Generators.Language" FixedTooltipText="Read Property Shape" InitialHeight="1" Geometry="Rectangle">
      <BaseGeometryShape>
        <GeometryShapeMoniker Name="TaskShape" />
      </BaseGeometryShape>
    </GeometryShape>
    <GeometryShape Id="a7fab263-fe32-4091-a1b1-db97327d3be5" Description="Description for Ultramarine.Generators.Language.SetVariableShape" Name="SetVariableShape" DisplayName="Set Variable Shape" Namespace="Ultramarine.Generators.Language" FixedTooltipText="Set Variable Shape" InitialHeight="1" Geometry="Rectangle">
      <BaseGeometryShape>
        <GeometryShapeMoniker Name="TaskShape" />
      </BaseGeometryShape>
    </GeometryShape>
    <GeometryShape Id="ae5903c3-0190-4edd-a9dd-7175f9c738ab" Description="Description for Ultramarine.Generators.Language.TextTransformationShape" Name="TextTransformationShape" DisplayName="Text Transformation Shape" Namespace="Ultramarine.Generators.Language" FixedTooltipText="Text Transformation Shape" InitialHeight="1" Geometry="Rectangle">
      <BaseGeometryShape>
        <GeometryShapeMoniker Name="TaskShape" />
      </BaseGeometryShape>
    </GeometryShape>
    <GeometryShape Id="0d385b92-226f-4b28-a27f-ad784ccb5864" Description="Description for Ultramarine.Generators.Language.CompositeShape" Name="CompositeShape" DisplayName="Composite Shape" Namespace="Ultramarine.Generators.Language" FixedTooltipText="Composite Shape" InitialHeight="1" Geometry="Rectangle">
      <BaseGeometryShape>
        <GeometryShapeMoniker Name="TaskShape" />
      </BaseGeometryShape>
    </GeometryShape>
  </Shapes>
  <Connectors>
    <Connector Id="dab655e0-7fef-4a35-9d0f-6847eb0c9a37" Description="Connector between the ExampleShapes. Represents ExampleRelationships on the Diagram." Name="ConnectedWithConnector" DisplayName="Connected With Connector" Namespace="Ultramarine.Generators.Language" FixedTooltipText="Connected With Connector" Color="113, 111, 110" TargetEndStyle="EmptyArrow" Thickness="0.01" />
  </Connectors>
  <XmlSerializationBehavior Name="GeneratorLanguageSerializationBehavior" Namespace="Ultramarine.Generators.Language">
    <ClassData>
      <XmlClassData TypeName="Generator" MonikerAttributeName="" SerializeId="true" MonikerElementName="generatorMoniker" ElementName="generator" MonikerTypeName="GeneratorMoniker">
        <DomainClassMoniker Name="Generator" />
      </XmlClassData>
      <XmlClassData TypeName="LoadCodeElementShape" MonikerAttributeName="" SerializeId="true" MonikerElementName="loadCodeElementShapeMoniker" ElementName="loadCodeElementShape" MonikerTypeName="LoadCodeElementShapeMoniker">
        <GeometryShapeMoniker Name="LoadCodeElementShape" />
      </XmlClassData>
      <XmlClassData TypeName="ConnectedWithConnector" MonikerAttributeName="" SerializeId="true" MonikerElementName="connectedWithConnectorMoniker" ElementName="connectedWithConnector" MonikerTypeName="ConnectedWithConnectorMoniker">
        <ConnectorMoniker Name="ConnectedWithConnector" />
      </XmlClassData>
      <XmlClassData TypeName="GeneratorLanguageDiagram" MonikerAttributeName="" SerializeId="true" MonikerElementName="generatorLanguageDiagramMoniker" ElementName="generatorLanguageDiagram" MonikerTypeName="GeneratorLanguageDiagramMoniker">
        <DiagramMoniker Name="GeneratorLanguageDiagram" />
      </XmlClassData>
      <XmlClassData TypeName="Task" MonikerAttributeName="" SerializeId="true" MonikerElementName="taskMoniker" ElementName="task" MonikerTypeName="TaskMoniker">
        <DomainClassMoniker Name="Task" />
        <ElementData>
          <XmlPropertyData XmlName="name">
            <DomainPropertyMoniker Name="Task/Name" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="description">
            <DomainPropertyMoniker Name="Task/Description" />
          </XmlPropertyData>
          <XmlRelationshipData UseFullForm="true" RoleElementName="targetTask">
            <DomainRelationshipMoniker Name="ConnectedWith" />
          </XmlRelationshipData>
        </ElementData>
      </XmlClassData>
      <XmlClassData TypeName="CompositeTask" MonikerAttributeName="" SerializeId="true" MonikerElementName="compositeTaskMoniker" ElementName="compositeTask" MonikerTypeName="CompositeTaskMoniker">
        <DomainClassMoniker Name="CompositeTask" />
        <ElementData>
          <XmlRelationshipData UseFullForm="true" RoleElementName="tasks">
            <DomainRelationshipMoniker Name="Children" />
          </XmlRelationshipData>
        </ElementData>
      </XmlClassData>
      <XmlClassData TypeName="LoadCodeElement" MonikerAttributeName="" SerializeId="true" MonikerElementName="loadCodeElementMoniker" ElementName="loadCodeElement" MonikerTypeName="LoadCodeElementMoniker">
        <DomainClassMoniker Name="LoadCodeElement" />
        <ElementData>
          <XmlPropertyData XmlName="elementName">
            <DomainPropertyMoniker Name="LoadCodeElement/ElementName" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="elementType">
            <DomainPropertyMoniker Name="LoadCodeElement/ElementType" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="elementAccess">
            <DomainPropertyMoniker Name="LoadCodeElement/ElementAccess" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="elementOverride">
            <DomainPropertyMoniker Name="LoadCodeElement/ElementOverride" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="typeOf">
            <DomainPropertyMoniker Name="LoadCodeElement/TypeOf" />
          </XmlPropertyData>
        </ElementData>
      </XmlClassData>
      <XmlClassData TypeName="ConnectedWith" MonikerAttributeName="" SerializeId="true" MonikerElementName="connectedWithMoniker" ElementName="connectedWith" MonikerTypeName="ConnectedWithMoniker">
        <DomainRelationshipMoniker Name="ConnectedWith" />
      </XmlClassData>
      <XmlClassData TypeName="BuildProject" MonikerAttributeName="" SerializeId="true" MonikerElementName="buildProjectMoniker" ElementName="buildProject" MonikerTypeName="BuildProjectMoniker">
        <DomainClassMoniker Name="BuildProject" />
        <ElementData>
          <XmlPropertyData XmlName="projectName">
            <DomainPropertyMoniker Name="BuildProject/ProjectName" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="configuration">
            <DomainPropertyMoniker Name="BuildProject/Configuration" />
          </XmlPropertyData>
        </ElementData>
      </XmlClassData>
      <XmlClassData TypeName="TaskShape" MonikerAttributeName="" SerializeId="true" MonikerElementName="taskShapeMoniker" ElementName="taskShape" MonikerTypeName="TaskShapeMoniker">
        <GeometryShapeMoniker Name="TaskShape" />
      </XmlClassData>
      <XmlClassData TypeName="BuildProjectShape" MonikerAttributeName="" SerializeId="true" MonikerElementName="buildProjectShapeMoniker" ElementName="buildProjectShape" MonikerTypeName="BuildProjectShapeMoniker">
        <GeometryShapeMoniker Name="BuildProjectShape" />
      </XmlClassData>
      <XmlClassData TypeName="CreateFolderShape" MonikerAttributeName="" SerializeId="true" MonikerElementName="createFolderShapeMoniker" ElementName="createFolderShape" MonikerTypeName="CreateFolderShapeMoniker">
        <GeometryShapeMoniker Name="CreateFolderShape" />
      </XmlClassData>
      <XmlClassData TypeName="CreateFolder" MonikerAttributeName="" SerializeId="true" MonikerElementName="createFolderMoniker" ElementName="createFolder" MonikerTypeName="CreateFolderMoniker">
        <DomainClassMoniker Name="CreateFolder" />
        <ElementData>
          <XmlPropertyData XmlName="folderPath">
            <DomainPropertyMoniker Name="CreateFolder/FolderPath" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="basePath">
            <DomainPropertyMoniker Name="CreateFolder/BasePath" />
          </XmlPropertyData>
        </ElementData>
      </XmlClassData>
      <XmlClassData TypeName="CreateProjectItem" MonikerAttributeName="" SerializeId="true" MonikerElementName="createProjectItemMoniker" ElementName="createProjectItem" MonikerTypeName="CreateProjectItemMoniker">
        <DomainClassMoniker Name="CreateProjectItem" />
        <ElementData>
          <XmlPropertyData XmlName="itemName">
            <DomainPropertyMoniker Name="CreateProjectItem/ItemName" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="folderPath">
            <DomainPropertyMoniker Name="CreateProjectItem/FolderPath" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="linkedWith">
            <DomainPropertyMoniker Name="CreateProjectItem/LinkedWith" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="projectName">
            <DomainPropertyMoniker Name="CreateProjectItem/ProjectName" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="overwrite">
            <DomainPropertyMoniker Name="CreateProjectItem/Overwrite" />
          </XmlPropertyData>
        </ElementData>
      </XmlClassData>
      <XmlClassData TypeName="CreateProjectItemShape" MonikerAttributeName="" SerializeId="true" MonikerElementName="createProjectItemShapeMoniker" ElementName="createProjectItemShape" MonikerTypeName="CreateProjectItemShapeMoniker">
        <GeometryShapeMoniker Name="CreateProjectItemShape" />
      </XmlClassData>
      <XmlClassData TypeName="LoadProjectItem" MonikerAttributeName="" SerializeId="true" MonikerElementName="loadProjectItemMoniker" ElementName="loadProjectItem" MonikerTypeName="LoadProjectItemMoniker">
        <DomainClassMoniker Name="LoadProjectItem" />
        <ElementData>
          <XmlPropertyData XmlName="projectName">
            <DomainPropertyMoniker Name="LoadProjectItem/ProjectName" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="itemName">
            <DomainPropertyMoniker Name="LoadProjectItem/ItemName" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="linkedWith">
            <DomainPropertyMoniker Name="LoadProjectItem/LinkedWith" />
          </XmlPropertyData>
        </ElementData>
      </XmlClassData>
      <XmlClassData TypeName="LoadProjectItemShape" MonikerAttributeName="" SerializeId="true" MonikerElementName="loadProjectItemShapeMoniker" ElementName="loadProjectItemShape" MonikerTypeName="LoadProjectItemShapeMoniker">
        <GeometryShapeMoniker Name="LoadProjectItemShape" />
      </XmlClassData>
      <XmlClassData TypeName="ReadProperty" MonikerAttributeName="" SerializeId="true" MonikerElementName="readPropertyMoniker" ElementName="readProperty" MonikerTypeName="ReadPropertyMoniker">
        <DomainClassMoniker Name="ReadProperty" />
        <ElementData>
          <XmlPropertyData XmlName="propertyName">
            <DomainPropertyMoniker Name="ReadProperty/PropertyName" />
          </XmlPropertyData>
        </ElementData>
      </XmlClassData>
      <XmlClassData TypeName="ReadPropertyShape" MonikerAttributeName="" SerializeId="true" MonikerElementName="readPropertyShapeMoniker" ElementName="readPropertyShape" MonikerTypeName="ReadPropertyShapeMoniker">
        <GeometryShapeMoniker Name="ReadPropertyShape" />
      </XmlClassData>
      <XmlClassData TypeName="SetVariable" MonikerAttributeName="" SerializeId="true" MonikerElementName="setVariableMoniker" ElementName="setVariable" MonikerTypeName="SetVariableMoniker">
        <DomainClassMoniker Name="SetVariable" />
        <ElementData>
          <XmlPropertyData XmlName="variableName">
            <DomainPropertyMoniker Name="SetVariable/VariableName" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="variableValue">
            <DomainPropertyMoniker Name="SetVariable/VariableValue" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="parentTask">
            <DomainPropertyMoniker Name="SetVariable/ParentTask" />
          </XmlPropertyData>
        </ElementData>
      </XmlClassData>
      <XmlClassData TypeName="SetVariableShape" MonikerAttributeName="" SerializeId="true" MonikerElementName="setVariableShapeMoniker" ElementName="setVariableShape" MonikerTypeName="SetVariableShapeMoniker">
        <GeometryShapeMoniker Name="SetVariableShape" />
      </XmlClassData>
      <XmlClassData TypeName="TextTransformation" MonikerAttributeName="" SerializeId="true" MonikerElementName="textTransformationMoniker" ElementName="textTransformation" MonikerTypeName="TextTransformationMoniker">
        <DomainClassMoniker Name="TextTransformation" />
        <ElementData>
          <XmlPropertyData XmlName="fileName">
            <DomainPropertyMoniker Name="TextTransformation/FileName" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="projectName">
            <DomainPropertyMoniker Name="TextTransformation/ProjectName" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="parameters">
            <DomainPropertyMoniker Name="TextTransformation/Parameters" />
          </XmlPropertyData>
        </ElementData>
      </XmlClassData>
      <XmlClassData TypeName="TextTransformationShape" MonikerAttributeName="" SerializeId="true" MonikerElementName="textTransformationShapeMoniker" ElementName="textTransformationShape" MonikerTypeName="TextTransformationShapeMoniker">
        <GeometryShapeMoniker Name="TextTransformationShape" />
      </XmlClassData>
      <XmlClassData TypeName="Iterator" MonikerAttributeName="" SerializeId="true" MonikerElementName="iteratorMoniker" ElementName="iterator" MonikerTypeName="IteratorMoniker">
        <DomainClassMoniker Name="Iterator" />
      </XmlClassData>
      <XmlClassData TypeName="Children" MonikerAttributeName="" SerializeId="true" MonikerElementName="childrenMoniker" ElementName="children" MonikerTypeName="ChildrenMoniker">
        <DomainRelationshipMoniker Name="Children" />
      </XmlClassData>
      <XmlClassData TypeName="CompositeShape" MonikerAttributeName="" SerializeId="true" MonikerElementName="compositeShapeMoniker" ElementName="compositeShape" MonikerTypeName="CompositeShapeMoniker">
        <GeometryShapeMoniker Name="CompositeShape" />
      </XmlClassData>
    </ClassData>
  </XmlSerializationBehavior>
  <ExplorerBehavior Name="GeneratorLanguageExplorer" />
  <ConnectionBuilders>
    <ConnectionBuilder Name="ConnectedWithBuilder">
      <LinkConnectDirective>
        <DomainRelationshipMoniker Name="ConnectedWith" />
        <SourceDirectives>
          <RolePlayerConnectDirective>
            <AcceptingClass>
              <DomainClassMoniker Name="Task" />
            </AcceptingClass>
          </RolePlayerConnectDirective>
        </SourceDirectives>
        <TargetDirectives>
          <RolePlayerConnectDirective>
            <AcceptingClass>
              <DomainClassMoniker Name="Task" />
            </AcceptingClass>
          </RolePlayerConnectDirective>
        </TargetDirectives>
      </LinkConnectDirective>
    </ConnectionBuilder>
  </ConnectionBuilders>
  <Diagram Id="3ccf8b1b-babe-4fd9-b228-5c88a4ed854e" Description="Description for Ultramarine.Generators.Language.GeneratorLanguageDiagram" Name="GeneratorLanguageDiagram" DisplayName="Minimal Language Diagram" Namespace="Ultramarine.Generators.Language">
    <Class>
      <DomainClassMoniker Name="Generator" />
    </Class>
    <ShapeMaps>
      <ShapeMap>
        <DomainClassMoniker Name="LoadCodeElement" />
        <ParentElementPath>
          <DomainPath>Children.Parent/!CompositeTask</DomainPath>
        </ParentElementPath>
        <DecoratorMap>
          <TextDecoratorMoniker Name="TaskShape/NameDecorator" />
          <PropertyDisplayed>
            <PropertyPath>
              <DomainPropertyMoniker Name="Task/Name" />
            </PropertyPath>
          </PropertyDisplayed>
        </DecoratorMap>
        <DecoratorMap>
          <TextDecoratorMoniker Name="TaskShape/DescriptionDecorator" />
          <PropertyDisplayed>
            <PropertyPath>
              <DomainPropertyMoniker Name="Task/Description" />
            </PropertyPath>
          </PropertyDisplayed>
        </DecoratorMap>
        <GeometryShapeMoniker Name="LoadCodeElementShape" />
      </ShapeMap>
      <ShapeMap>
        <DomainClassMoniker Name="BuildProject" />
        <ParentElementPath>
          <DomainPath>Children.Parent/!CompositeTask</DomainPath>
        </ParentElementPath>
        <DecoratorMap>
          <TextDecoratorMoniker Name="TaskShape/DescriptionDecorator" />
          <PropertyDisplayed>
            <PropertyPath>
              <DomainPropertyMoniker Name="Task/Description" />
            </PropertyPath>
          </PropertyDisplayed>
        </DecoratorMap>
        <DecoratorMap>
          <TextDecoratorMoniker Name="TaskShape/NameDecorator" />
          <PropertyDisplayed>
            <PropertyPath>
              <DomainPropertyMoniker Name="Task/Name" />
            </PropertyPath>
          </PropertyDisplayed>
        </DecoratorMap>
        <GeometryShapeMoniker Name="BuildProjectShape" />
      </ShapeMap>
      <ShapeMap>
        <DomainClassMoniker Name="CreateFolder" />
        <ParentElementPath>
          <DomainPath>Children.Parent/!CompositeTask</DomainPath>
        </ParentElementPath>
        <DecoratorMap>
          <TextDecoratorMoniker Name="TaskShape/NameDecorator" />
          <PropertyDisplayed>
            <PropertyPath>
              <DomainPropertyMoniker Name="Task/Name" />
            </PropertyPath>
          </PropertyDisplayed>
        </DecoratorMap>
        <DecoratorMap>
          <TextDecoratorMoniker Name="TaskShape/DescriptionDecorator" />
          <PropertyDisplayed>
            <PropertyPath>
              <DomainPropertyMoniker Name="Task/Description" />
            </PropertyPath>
          </PropertyDisplayed>
        </DecoratorMap>
        <GeometryShapeMoniker Name="CreateFolderShape" />
      </ShapeMap>
      <ShapeMap>
        <DomainClassMoniker Name="CreateProjectItem" />
        <ParentElementPath>
          <DomainPath>Children.Parent/!CompositeTask</DomainPath>
        </ParentElementPath>
        <DecoratorMap>
          <TextDecoratorMoniker Name="TaskShape/NameDecorator" />
          <PropertyDisplayed>
            <PropertyPath>
              <DomainPropertyMoniker Name="Task/Name" />
            </PropertyPath>
          </PropertyDisplayed>
        </DecoratorMap>
        <DecoratorMap>
          <TextDecoratorMoniker Name="TaskShape/DescriptionDecorator" />
          <PropertyDisplayed>
            <PropertyPath>
              <DomainPropertyMoniker Name="CreateProjectItem/FolderPath" />
            </PropertyPath>
          </PropertyDisplayed>
        </DecoratorMap>
        <GeometryShapeMoniker Name="CreateProjectItemShape" />
      </ShapeMap>
      <ShapeMap>
        <DomainClassMoniker Name="LoadProjectItem" />
        <ParentElementPath>
          <DomainPath>Children.Parent/!CompositeTask</DomainPath>
        </ParentElementPath>
        <DecoratorMap>
          <TextDecoratorMoniker Name="TaskShape/DescriptionDecorator" />
          <PropertyDisplayed>
            <PropertyPath>
              <DomainPropertyMoniker Name="Task/Description" />
            </PropertyPath>
          </PropertyDisplayed>
        </DecoratorMap>
        <DecoratorMap>
          <TextDecoratorMoniker Name="TaskShape/NameDecorator" />
          <PropertyDisplayed>
            <PropertyPath>
              <DomainPropertyMoniker Name="Task/Name" />
            </PropertyPath>
          </PropertyDisplayed>
        </DecoratorMap>
        <GeometryShapeMoniker Name="LoadProjectItemShape" />
      </ShapeMap>
      <ShapeMap>
        <DomainClassMoniker Name="ReadProperty" />
        <ParentElementPath>
          <DomainPath>Children.Parent/!CompositeTask</DomainPath>
        </ParentElementPath>
        <DecoratorMap>
          <TextDecoratorMoniker Name="TaskShape/DescriptionDecorator" />
          <PropertyDisplayed>
            <PropertyPath>
              <DomainPropertyMoniker Name="Task/Description" />
            </PropertyPath>
          </PropertyDisplayed>
        </DecoratorMap>
        <DecoratorMap>
          <TextDecoratorMoniker Name="TaskShape/NameDecorator" />
          <PropertyDisplayed>
            <PropertyPath>
              <DomainPropertyMoniker Name="Task/Name" />
            </PropertyPath>
          </PropertyDisplayed>
        </DecoratorMap>
        <GeometryShapeMoniker Name="ReadPropertyShape" />
      </ShapeMap>
      <ShapeMap>
        <DomainClassMoniker Name="SetVariable" />
        <ParentElementPath>
          <DomainPath>Children.Parent/!CompositeTask</DomainPath>
        </ParentElementPath>
        <DecoratorMap>
          <TextDecoratorMoniker Name="TaskShape/NameDecorator" />
          <PropertyDisplayed>
            <PropertyPath>
              <DomainPropertyMoniker Name="Task/Name" />
            </PropertyPath>
          </PropertyDisplayed>
        </DecoratorMap>
        <DecoratorMap>
          <TextDecoratorMoniker Name="TaskShape/DescriptionDecorator" />
          <PropertyDisplayed>
            <PropertyPath>
              <DomainPropertyMoniker Name="Task/Description" />
            </PropertyPath>
          </PropertyDisplayed>
        </DecoratorMap>
        <GeometryShapeMoniker Name="SetVariableShape" />
      </ShapeMap>
      <ShapeMap>
        <DomainClassMoniker Name="TextTransformation" />
        <ParentElementPath>
          <DomainPath>Children.Parent/!CompositeTask</DomainPath>
        </ParentElementPath>
        <DecoratorMap>
          <TextDecoratorMoniker Name="TaskShape/NameDecorator" />
          <PropertyDisplayed>
            <PropertyPath>
              <DomainPropertyMoniker Name="Task/Name" />
            </PropertyPath>
          </PropertyDisplayed>
        </DecoratorMap>
        <DecoratorMap>
          <TextDecoratorMoniker Name="TaskShape/DescriptionDecorator" />
          <PropertyDisplayed>
            <PropertyPath>
              <DomainPropertyMoniker Name="Task/Description" />
            </PropertyPath>
          </PropertyDisplayed>
        </DecoratorMap>
        <GeometryShapeMoniker Name="TextTransformationShape" />
      </ShapeMap>
      <ShapeMap HasCustomParentElement="true">
        <DomainClassMoniker Name="CompositeTask" />
        <ParentElementPath>
          <DomainPath />
        </ParentElementPath>
        <DecoratorMap>
          <TextDecoratorMoniker Name="TaskShape/NameDecorator" />
          <PropertyDisplayed>
            <PropertyPath>
              <DomainPropertyMoniker Name="Task/Name" />
            </PropertyPath>
          </PropertyDisplayed>
        </DecoratorMap>
        <DecoratorMap>
          <TextDecoratorMoniker Name="TaskShape/DescriptionDecorator" />
          <PropertyDisplayed>
            <PropertyPath>
              <DomainPropertyMoniker Name="Task/Description" />
            </PropertyPath>
          </PropertyDisplayed>
        </DecoratorMap>
        <GeometryShapeMoniker Name="CompositeShape" />
      </ShapeMap>
    </ShapeMaps>
    <ConnectorMaps>
      <ConnectorMap>
        <ConnectorMoniker Name="ConnectedWithConnector" />
        <DomainRelationshipMoniker Name="ConnectedWith" />
      </ConnectorMap>
    </ConnectorMaps>
  </Diagram>
  <Designer CopyPasteGeneration="CopyPasteOnly" FileExtension="ugen" EditorGuid="d2ea36cb-2ed1-4ccc-81c2-e69de04d530e">
    <RootClass>
      <DomainClassMoniker Name="Generator" />
    </RootClass>
    <XmlSerializationDefinition CustomPostLoad="false">
      <XmlSerializationBehaviorMoniker Name="GeneratorLanguageSerializationBehavior" />
    </XmlSerializationDefinition>
    <ToolboxTab TabText="GeneratorLanguage">
      <ConnectionTool Name="ConnectedWithRelationship" ToolboxIcon="resources\exampleconnectortoolbitmap.bmp" Caption="ConnectedWith" Tooltip="Drag between ExampleElements to create an ExampleRelationship" HelpKeyword="ConnectExampleRelationF1Keyword">
        <ConnectionBuilderMoniker Name="GeneratorLanguage/ConnectedWithBuilder" />
      </ConnectionTool>
      <ElementTool Name="BuildProject" ToolboxIcon="Resources\ExampleShapeToolBitmap.bmp" Caption="BuildProject" Tooltip="Build Project" HelpKeyword="BuildProject">
        <DomainClassMoniker Name="BuildProject" />
      </ElementTool>
      <ElementTool Name="CreateFolder" ToolboxIcon="Resources\ExampleShapeToolBitmap.bmp" Caption="CreateFolder" Tooltip="Create Folder" HelpKeyword="CreateFolder">
        <DomainClassMoniker Name="CreateFolder" />
      </ElementTool>
      <ElementTool Name="CreateProjectItem" ToolboxIcon="Resources\ExampleShapeToolBitmap.bmp" Caption="CreateProjectItem" Tooltip="Create Project Item" HelpKeyword="CreateProjectItem">
        <DomainClassMoniker Name="CreateProjectItem" />
      </ElementTool>
      <ElementTool Name="LoadCodeElement" ToolboxIcon="resources\exampleshapetoolbitmap.bmp" Caption="Load CodeElement" Tooltip="Create an ExampleElement" HelpKeyword="CreateExampleClassF1Keyword">
        <DomainClassMoniker Name="LoadCodeElement" />
      </ElementTool>
      <ElementTool Name="LoadProjectItem" ToolboxIcon="Resources\ExampleShapeToolBitmap.bmp" Caption="LoadProjectItem" Tooltip="Load Project Item" HelpKeyword="LoadProjectItem">
        <DomainClassMoniker Name="LoadProjectItem" />
      </ElementTool>
      <ElementTool Name="ReadProperty" ToolboxIcon="Resources\ExampleShapeToolBitmap.bmp" Caption="ReadProperty" Tooltip="Read Property" HelpKeyword="ReadProperty">
        <DomainClassMoniker Name="ReadProperty" />
      </ElementTool>
      <ElementTool Name="SetVariable" ToolboxIcon="Resources\ExampleShapeToolBitmap.bmp" Caption="SetVariable" Tooltip="Set Variable" HelpKeyword="SetVariable">
        <DomainClassMoniker Name="SetVariable" />
      </ElementTool>
      <ElementTool Name="Iterator" ToolboxIcon="Resources\ExampleShapeToolBitmap.bmp" Caption="Iterator" Tooltip="Iterator" HelpKeyword="Iterator">
        <DomainClassMoniker Name="Iterator" />
      </ElementTool>
      <ElementTool Name="TextTransformation" ToolboxIcon="Resources\ExampleShapeToolBitmap.bmp" Caption="TextTransformation" Tooltip="Text Transformation" HelpKeyword="TextTransformation">
        <DomainClassMoniker Name="TextTransformation" />
      </ElementTool>
    </ToolboxTab>
    <Validation UsesMenu="false" UsesOpen="false" UsesSave="false" UsesLoad="false" />
    <DiagramMoniker Name="GeneratorLanguageDiagram" />
  </Designer>
  <Explorer ExplorerGuid="9ae95886-a985-4bc2-9475-fc20306b55a6" Title="GeneratorLanguage Explorer">
    <ExplorerBehaviorMoniker Name="GeneratorLanguage/GeneratorLanguageExplorer" />
  </Explorer>
</Dsl>