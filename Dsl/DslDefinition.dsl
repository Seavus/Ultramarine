<?xml version="1.0" encoding="utf-8"?>
<Dsl xmlns:dm0="http://schemas.microsoft.com/VisualStudio/2008/DslTools/Core" dslVersion="1.0.0.0" Id="fa460004-c689-4b79-9838-fd3850db6a1e" Description="Description for Ultramarine.Generators.Language.GeneratorLanguage" Name="GeneratorLanguage" DisplayName="GeneratorLanguage" Namespace="Ultramarine.Generators.Language" ProductName="Ultramarine" CompanyName="Seavus" PackageGuid="253eb726-92cb-4387-9f64-2ca8bbc1e16a" PackageNamespace="Ultramarine.Generators.Language" xmlns="http://schemas.microsoft.com/VisualStudio/2005/DslTools/DslDefinitionModel">
  <Classes>
    <DomainClass Id="998d169c-4479-4c51-afb7-ac84ad68d0a9" Description="The root in which all other elements are embedded. Appears as a diagram." Name="GeneratorModel" DisplayName="Generator Model" Namespace="Ultramarine.Generators.Language">
      <ElementMergeDirectives>
        <ElementMergeDirective>
          <Index>
            <DomainClassMoniker Name="Task" />
          </Index>
          <LinkCreationPaths>
            <DomainPath>GeneratorModelHasTasks.Tasks</DomainPath>
          </LinkCreationPaths>
        </ElementMergeDirective>
      </ElementMergeDirectives>
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
    </DomainClass>
    <DomainClass Id="e88bb8c2-2e3e-4337-9b4a-ba0134771eb0" Description="Description for Ultramarine.Generators.Language.LoadCodeElement" Name="LoadCodeElement" DisplayName="Load Code Element" Namespace="Ultramarine.Generators.Language">
      <BaseClass>
        <DomainClassMoniker Name="Task" />
      </BaseClass>
    </DomainClass>
    <DomainClass Id="c485d0c8-53cb-4700-b9cd-c3df4a47eb15" Description="Description for Ultramarine.Generators.Language.BuildProject" Name="BuildProject" DisplayName="Build Project" Namespace="Ultramarine.Generators.Language">
      <BaseClass>
        <DomainClassMoniker Name="Task" />
      </BaseClass>
      <Properties>
        <DomainProperty Id="2c4ce0b6-c357-421c-a00d-b0e3ba8bec82" Description="Description for Ultramarine.Generators.Language.BuildProject.Project Name" Name="ProjectName" DisplayName="Project Name">
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="6ea6184d-c953-4035-ae6b-27f14e524314" Description="Description for Ultramarine.Generators.Language.BuildProject.Configuration" Name="Configuration" DisplayName="Configuration">
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
      </Properties>
    </DomainClass>
    <DomainClass Id="0a8bec4c-7da8-4fae-91f5-9a87f89b38b1" Description="Description for Ultramarine.Generators.Language.CreateFolder" Name="CreateFolder" DisplayName="Create Folder" Namespace="Ultramarine.Generators.Language">
      <BaseClass>
        <DomainClassMoniker Name="Task" />
      </BaseClass>
      <Properties>
        <DomainProperty Id="5b7b713f-a14e-46f3-a6ee-13c915fbbcc7" Description="Description for Ultramarine.Generators.Language.CreateFolder.Folder Path" Name="FolderPath" DisplayName="Folder Path">
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="3b4e683a-8927-4652-aab5-ee7d46d6f132" Description="Description for Ultramarine.Generators.Language.CreateFolder.Base Path" Name="BasePath" DisplayName="Base Path">
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
      </Properties>
      <ElementMergeDirectives>
        <ElementMergeDirective>
          <Index>
            <DomainClassMoniker Name="Settings" />
          </Index>
          <LinkCreationPaths>
            <DomainPath>CreateFolderHasSetting.Setting</DomainPath>
          </LinkCreationPaths>
        </ElementMergeDirective>
      </ElementMergeDirectives>
    </DomainClass>
    <DomainClass Id="dbf0da59-5949-4c55-a59c-2a0ff2343ea2" Description="Description for Ultramarine.Generators.Language.Settings" Name="Settings" DisplayName="Settings" InheritanceModifier="Sealed" Namespace="Ultramarine.Generators.Language">
      <Properties>
        <DomainProperty Id="bfd881b2-142f-45f0-8a26-b01b4aebdac3" Description="Description for Ultramarine.Generators.Language.Settings.Value" Name="Value" DisplayName="Value">
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
      </Properties>
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
    <DomainRelationship Id="0b9a8be5-4293-4fd4-ab23-9b0d87cd9ab0" Description="Description for Ultramarine.Generators.Language.GeneratorModelHasTasks" Name="GeneratorModelHasTasks" DisplayName="Generator Model Has Tasks" Namespace="Ultramarine.Generators.Language" IsEmbedding="true">
      <Source>
        <DomainRole Id="67029348-434b-4181-8d46-275aca3f819c" Description="Description for Ultramarine.Generators.Language.GeneratorModelHasTasks.GeneratorModel" Name="GeneratorModel" DisplayName="Generator Model" PropertyName="Tasks" PropagatesCopy="PropagatesCopyToLinkAndOppositeRolePlayer" PropertyDisplayName="Tasks">
          <RolePlayer>
            <DomainClassMoniker Name="GeneratorModel" />
          </RolePlayer>
        </DomainRole>
      </Source>
      <Target>
        <DomainRole Id="f0d4bbec-a402-4af6-a1e9-2694d6e98ae4" Description="Description for Ultramarine.Generators.Language.GeneratorModelHasTasks.Task" Name="Task" DisplayName="Task" PropertyName="Generator" Multiplicity="One" PropagatesDelete="true" PropertyDisplayName="Generator">
          <RolePlayer>
            <DomainClassMoniker Name="Task" />
          </RolePlayer>
        </DomainRole>
      </Target>
    </DomainRelationship>
    <DomainRelationship Id="0ae4d88d-d086-4dbd-9ef8-bb70cff9b8d9" Description="Description for Ultramarine.Generators.Language.CompositeTaskReferencesTasked" Name="CompositeTaskReferencesTasked" DisplayName="Composite Task References Tasked" Namespace="Ultramarine.Generators.Language">
      <Source>
        <DomainRole Id="7d858091-54ed-4846-b5a0-31b87d001bd7" Description="Description for Ultramarine.Generators.Language.CompositeTaskReferencesTasked.CompositeTask" Name="CompositeTask" DisplayName="Composite Task" PropertyName="Tasked" PropertyDisplayName="Tasked">
          <RolePlayer>
            <DomainClassMoniker Name="CompositeTask" />
          </RolePlayer>
        </DomainRole>
      </Source>
      <Target>
        <DomainRole Id="6f1c3c60-10b8-40a1-b6d2-3f1fe7b5ca6b" Description="Description for Ultramarine.Generators.Language.CompositeTaskReferencesTasked.Task" Name="Task" DisplayName="Task" PropertyName="CompositeTasked" PropertyDisplayName="Composite Tasked">
          <RolePlayer>
            <DomainClassMoniker Name="Task" />
          </RolePlayer>
        </DomainRole>
      </Target>
    </DomainRelationship>
    <DomainRelationship Id="6d9be41d-8491-4587-a01c-2656c2b7c759" Description="Description for Ultramarine.Generators.Language.CreateFolderHasSetting" Name="CreateFolderHasSetting" DisplayName="Create Folder Has Setting" Namespace="Ultramarine.Generators.Language" IsEmbedding="true">
      <Source>
        <DomainRole Id="2d95806b-94e5-450c-af9d-30917059f048" Description="Description for Ultramarine.Generators.Language.CreateFolderHasSetting.CreateFolder" Name="CreateFolder" DisplayName="Create Folder" PropertyName="Setting" PropagatesCopy="PropagatesCopyToLinkAndOppositeRolePlayer" PropertyDisplayName="Setting">
          <RolePlayer>
            <DomainClassMoniker Name="CreateFolder" />
          </RolePlayer>
        </DomainRole>
      </Source>
      <Target>
        <DomainRole Id="1b25d5e4-8eaf-4663-87a9-0b61688a5cb2" Description="Description for Ultramarine.Generators.Language.CreateFolderHasSetting.Settings" Name="Settings" DisplayName="Settings" PropertyName="CreateFolder" Multiplicity="One" PropagatesDelete="true" PropertyDisplayName="Create Folder">
          <RolePlayer>
            <DomainClassMoniker Name="Settings" />
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
    <GeometryShape Id="58d67238-c826-4929-9037-ad4ca1327d43" Description="Shape used to represent ExampleElements on a Diagram." Name="LoadCodeElementShape" DisplayName="Load Code Element Shape" Namespace="Ultramarine.Generators.Language" FixedTooltipText="Load Code Element Shape" FillColor="234, 234, 236" OutlineColor="113, 111, 110" InitialWidth="2" InitialHeight="0.75" OutlineThickness="0.01" Geometry="Rectangle">
      <Notes>The shape has a text decorator used to display the Name property of the mapped ExampleElement.</Notes>
      <BaseGeometryShape>
        <GeometryShapeMoniker Name="TaskShape" />
      </BaseGeometryShape>
    </GeometryShape>
    <GeometryShape Id="f5e430b0-4664-4db8-bc0c-80dc426c72b6" Description="Description for Ultramarine.Generators.Language.TaskShape" Name="TaskShape" DisplayName="Task Shape" InheritanceModifier="Abstract" Namespace="Ultramarine.Generators.Language" FixedTooltipText="Task Shape" InitialHeight="1" Geometry="Rectangle">
      <ShapeHasDecorators Position="InnerTopCenter" HorizontalOffset="0" VerticalOffset="0">
        <TextDecorator Name="NameDecorator" DisplayName="Name Decorator" DefaultText="NameDecorator" FontStyle="Bold" />
      </ShapeHasDecorators>
      <ShapeHasDecorators Position="InnerTopCenter" HorizontalOffset="0" VerticalOffset="0.1">
        <TextDecorator Name="DescriptionDecorator" DisplayName="Description Decorator" DefaultText="DescriptionDecorator" FontStyle="Italic" />
      </ShapeHasDecorators>
      <ShapeHasDecorators Position="InnerTopRight" HorizontalOffset="0" VerticalOffset="0">
        <ExpandCollapseDecorator Name="ExpandCollapseDecorator" DisplayName="Expand Collapse Decorator" />
      </ShapeHasDecorators>
    </GeometryShape>
    <GeometryShape Id="450ca504-4e61-482d-aad1-c82e46ac7fd4" Description="Description for Ultramarine.Generators.Language.BuildProjectShape" Name="BuildProjectShape" DisplayName="Build Project Shape" Namespace="Ultramarine.Generators.Language" FixedTooltipText="Build Project Shape" InitialHeight="1" Geometry="Rectangle">
      <BaseGeometryShape>
        <GeometryShapeMoniker Name="TaskShape" />
      </BaseGeometryShape>
      <Properties>
        <DomainProperty Id="e9799d3f-5a3c-40ca-8085-18d26a5f4fe3" Description="Description for Ultramarine.Generators.Language.BuildProjectShape.Project Name" Name="ProjectName" DisplayName="Project Name">
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="c2826879-436a-499b-8cc5-af06b863be99" Description="Description for Ultramarine.Generators.Language.BuildProjectShape.Configuration" Name="Configuration" DisplayName="Configuration">
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
      </Properties>
      <ShapeHasDecorators Position="InnerTopLeft" HorizontalOffset="0" VerticalOffset="0">
        <TextDecorator Name="TextDecorator1" DisplayName="Text Decorator1" DefaultText="TextDecorator1" />
      </ShapeHasDecorators>
    </GeometryShape>
    <CompartmentShape Id="753d476b-454e-4ee7-951f-56f8dd2f2581" Description="Description for Ultramarine.Generators.Language.CreateFolderShape" Name="CreateFolderShape" DisplayName="Create Folder Shape" Namespace="Ultramarine.Generators.Language" FixedTooltipText="Create Folder Shape" InitialHeight="1" Geometry="Rectangle">
      <ShapeHasDecorators Position="InnerTopLeft" HorizontalOffset="0" VerticalOffset="0">
        <TextDecorator Name="Name" DisplayName="Name" DefaultText="Name" />
      </ShapeHasDecorators>
      <ShapeHasDecorators Position="InnerTopLeft" HorizontalOffset="0" VerticalOffset="0">
        <TextDecorator Name="Description" DisplayName="Description" DefaultText="Description" />
      </ShapeHasDecorators>
      <Compartment Name="Compartment1" />
    </CompartmentShape>
  </Shapes>
  <Connectors>
    <Connector Id="dab655e0-7fef-4a35-9d0f-6847eb0c9a37" Description="Connector between the ExampleShapes. Represents ExampleRelationships on the Diagram." Name="ConnectedWithConnector" DisplayName="Connected With Connector" Namespace="Ultramarine.Generators.Language" FixedTooltipText="Connected With Connector" Color="113, 111, 110" TargetEndStyle="EmptyArrow" Thickness="0.01" />
  </Connectors>
  <XmlSerializationBehavior Name="GeneratorLanguageSerializationBehavior" Namespace="Ultramarine.Generators.Language">
    <ClassData>
      <XmlClassData TypeName="GeneratorModel" MonikerAttributeName="" SerializeId="true" MonikerElementName="generatorModelMoniker" ElementName="generatorModel" MonikerTypeName="GeneratorModelMoniker">
        <DomainClassMoniker Name="GeneratorModel" />
        <ElementData>
          <XmlRelationshipData UseFullForm="true" RoleElementName="tasks">
            <DomainRelationshipMoniker Name="GeneratorModelHasTasks" />
          </XmlRelationshipData>
        </ElementData>
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
          <XmlRelationshipData UseFullForm="true" RoleElementName="tasked">
            <DomainRelationshipMoniker Name="CompositeTaskReferencesTasked" />
          </XmlRelationshipData>
        </ElementData>
      </XmlClassData>
      <XmlClassData TypeName="LoadCodeElement" MonikerAttributeName="" SerializeId="true" MonikerElementName="loadCodeElementMoniker" ElementName="loadCodeElement" MonikerTypeName="LoadCodeElementMoniker">
        <DomainClassMoniker Name="LoadCodeElement" />
      </XmlClassData>
      <XmlClassData TypeName="ConnectedWith" MonikerAttributeName="" SerializeId="true" MonikerElementName="connectedWithMoniker" ElementName="connectedWith" MonikerTypeName="ConnectedWithMoniker">
        <DomainRelationshipMoniker Name="ConnectedWith" />
      </XmlClassData>
      <XmlClassData TypeName="GeneratorModelHasTasks" MonikerAttributeName="" SerializeId="true" MonikerElementName="generatorModelHasTasksMoniker" ElementName="generatorModelHasTasks" MonikerTypeName="GeneratorModelHasTasksMoniker">
        <DomainRelationshipMoniker Name="GeneratorModelHasTasks" />
      </XmlClassData>
      <XmlClassData TypeName="CompositeTaskReferencesTasked" MonikerAttributeName="" SerializeId="true" MonikerElementName="compositeTaskReferencesTaskedMoniker" ElementName="compositeTaskReferencesTasked" MonikerTypeName="CompositeTaskReferencesTaskedMoniker">
        <DomainRelationshipMoniker Name="CompositeTaskReferencesTasked" />
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
        <ElementData>
          <XmlPropertyData XmlName="projectName">
            <DomainPropertyMoniker Name="BuildProjectShape/ProjectName" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="configuration">
            <DomainPropertyMoniker Name="BuildProjectShape/Configuration" />
          </XmlPropertyData>
        </ElementData>
      </XmlClassData>
      <XmlClassData TypeName="CreateFolderShape" MonikerAttributeName="" SerializeId="true" MonikerElementName="createFolderShapeMoniker" ElementName="createFolderShape" MonikerTypeName="CreateFolderShapeMoniker">
        <CompartmentShapeMoniker Name="CreateFolderShape" />
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
          <XmlRelationshipData UseFullForm="true" RoleElementName="setting">
            <DomainRelationshipMoniker Name="CreateFolderHasSetting" />
          </XmlRelationshipData>
        </ElementData>
      </XmlClassData>
      <XmlClassData TypeName="Settings" MonikerAttributeName="" SerializeId="true" MonikerElementName="settingsMoniker" ElementName="settings" MonikerTypeName="SettingsMoniker">
        <DomainClassMoniker Name="Settings" />
        <ElementData>
          <XmlPropertyData XmlName="value">
            <DomainPropertyMoniker Name="Settings/Value" />
          </XmlPropertyData>
        </ElementData>
      </XmlClassData>
      <XmlClassData TypeName="CreateFolderHasSetting" MonikerAttributeName="" SerializeId="true" MonikerElementName="createFolderHasSettingMoniker" ElementName="createFolderHasSetting" MonikerTypeName="CreateFolderHasSettingMoniker">
        <DomainRelationshipMoniker Name="CreateFolderHasSetting" />
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
    <ConnectionBuilder Name="CompositeTaskReferencesTaskedBuilder">
      <LinkConnectDirective>
        <DomainRelationshipMoniker Name="CompositeTaskReferencesTasked" />
        <SourceDirectives>
          <RolePlayerConnectDirective>
            <AcceptingClass>
              <DomainClassMoniker Name="CompositeTask" />
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
      <DomainClassMoniker Name="GeneratorModel" />
    </Class>
    <ShapeMaps>
      <ShapeMap>
        <DomainClassMoniker Name="LoadCodeElement" />
        <ParentElementPath>
          <DomainPath>GeneratorModelHasTasks.Generator/!GeneratorModel</DomainPath>
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
          <DomainPath>GeneratorModelHasTasks.Generator/!GeneratorModel</DomainPath>
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
      <CompartmentShapeMap>
        <DomainClassMoniker Name="CreateFolder" />
        <ParentElementPath>
          <DomainPath>GeneratorModelHasTasks.Generator/!GeneratorModel</DomainPath>
        </ParentElementPath>
        <DecoratorMap>
          <TextDecoratorMoniker Name="CreateFolderShape/Description" />
          <PropertyDisplayed>
            <PropertyPath>
              <DomainPropertyMoniker Name="Task/Description" />
            </PropertyPath>
          </PropertyDisplayed>
        </DecoratorMap>
        <DecoratorMap>
          <TextDecoratorMoniker Name="CreateFolderShape/Name" />
          <PropertyDisplayed>
            <PropertyPath>
              <DomainPropertyMoniker Name="Task/Name" />
            </PropertyPath>
          </PropertyDisplayed>
        </DecoratorMap>
        <CompartmentShapeMoniker Name="CreateFolderShape" />
        <CompartmentMap>
          <CompartmentMoniker Name="CreateFolderShape/Compartment1" />
          <ElementsDisplayed>
            <DomainPath>CreateFolderHasSetting.Setting/!Settings</DomainPath>
          </ElementsDisplayed>
          <PropertyDisplayed>
            <PropertyPath>
              <DomainPropertyMoniker Name="Settings/Value" />
            </PropertyPath>
          </PropertyDisplayed>
        </CompartmentMap>
      </CompartmentShapeMap>
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
      <DomainClassMoniker Name="GeneratorModel" />
    </RootClass>
    <XmlSerializationDefinition CustomPostLoad="false">
      <XmlSerializationBehaviorMoniker Name="GeneratorLanguageSerializationBehavior" />
    </XmlSerializationDefinition>
    <ToolboxTab TabText="GeneratorLanguage">
      <ElementTool Name="LoadCodeElement" ToolboxIcon="resources\exampleshapetoolbitmap.bmp" Caption="Load CodeElement" Tooltip="Create an ExampleElement" HelpKeyword="CreateExampleClassF1Keyword">
        <DomainClassMoniker Name="LoadCodeElement" />
      </ElementTool>
      <ConnectionTool Name="ExampleRelationship" ToolboxIcon="resources\exampleconnectortoolbitmap.bmp" Caption="ExampleRelationship" Tooltip="Drag between ExampleElements to create an ExampleRelationship" HelpKeyword="ConnectExampleRelationF1Keyword">
        <ConnectionBuilderMoniker Name="GeneratorLanguage/ConnectedWithBuilder" />
      </ConnectionTool>
      <ElementTool Name="BuildProject" ToolboxIcon="Resources\ExampleShapeToolBitmap.bmp" Caption="BuildProject" Tooltip="Build Project" HelpKeyword="BuildProject">
        <DomainClassMoniker Name="BuildProject" />
      </ElementTool>
      <ElementTool Name="CreateFolder" ToolboxIcon="Resources\ExampleShapeToolBitmap.bmp" Caption="Create Folder" Tooltip="Create Folder" HelpKeyword="CreateFolder">
        <DomainClassMoniker Name="CreateFolder" />
      </ElementTool>
    </ToolboxTab>
    <Validation UsesMenu="false" UsesOpen="false" UsesSave="false" UsesLoad="false" />
    <DiagramMoniker Name="GeneratorLanguageDiagram" />
  </Designer>
  <Explorer ExplorerGuid="9ae95886-a985-4bc2-9475-fc20306b55a6" Title="GeneratorLanguage Explorer">
    <ExplorerBehaviorMoniker Name="GeneratorLanguage/GeneratorLanguageExplorer" />
  </Explorer>
</Dsl>