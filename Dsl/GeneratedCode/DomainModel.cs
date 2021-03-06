﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using DslModeling = global::Microsoft.VisualStudio.Modeling;
using DslDesign = global::Microsoft.VisualStudio.Modeling.Design;
using DslDiagrams = global::Microsoft.VisualStudio.Modeling.Diagrams;
namespace Ultramarine.Generators.Language
{
	/// <summary>
	/// DomainModel GeneratorLanguageDomainModel
	/// Description for Ultramarine.Generators.Language.GeneratorLanguage
	/// </summary>
	[DslDesign::DisplayNameResource("Ultramarine.Generators.Language.GeneratorLanguageDomainModel.DisplayName", typeof(global::Ultramarine.Generators.Language.GeneratorLanguageDomainModel), "Ultramarine.Generators.Language.GeneratedCode.DomainModelResx")]
	[DslDesign::DescriptionResource("Ultramarine.Generators.Language.GeneratorLanguageDomainModel.Description", typeof(global::Ultramarine.Generators.Language.GeneratorLanguageDomainModel), "Ultramarine.Generators.Language.GeneratedCode.DomainModelResx")]
	[global::System.CLSCompliant(true)]
	[DslModeling::DependsOnDomainModel(typeof(global::Microsoft.VisualStudio.Modeling.CoreDomainModel))]
	[DslModeling::DependsOnDomainModel(typeof(global::Microsoft.VisualStudio.Modeling.Diagrams.CoreDesignSurfaceDomainModel))]
	[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1506:AvoidExcessiveClassCoupling", Justification = "Generated code.")]
	[DslModeling::DomainObjectId("fa460004-c689-4b79-9838-fd3850db6a1e")]
	public partial class GeneratorLanguageDomainModel : DslModeling::DomainModel
	{
		#region Constructor, domain model Id
	
		/// <summary>
		/// GeneratorLanguageDomainModel domain model Id.
		/// </summary>
		public static readonly global::System.Guid DomainModelId = new global::System.Guid(0xfa460004, 0xc689, 0x4b79, 0x98, 0x38, 0xfd, 0x38, 0x50, 0xdb, 0x6a, 0x1e);
	
		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="store">Store containing the domain model.</param>
		public GeneratorLanguageDomainModel(DslModeling::Store store)
			: base(store, DomainModelId)
		{
			// Call the partial method to allow any required serialization setup to be done.
			this.InitializeSerialization(store);		
		}
		
	
		///<Summary>
		/// Defines a partial method that will be called from the constructor to
		/// allow any necessary serialization setup to be done.
		///</Summary>
		///<remarks>
		/// For a DSL created with the DSL Designer wizard, an implementation of this 
		/// method will be generated in the GeneratedCode\SerializationHelper.cs class.
		///</remarks>
		partial void InitializeSerialization(DslModeling::Store store);
	
	
		#endregion
		#region Domain model reflection
			
		/// <summary>
		/// Gets the list of generated domain model types (classes, rules, relationships).
		/// </summary>
		/// <returns>List of types.</returns>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1506:AvoidExcessiveClassCoupling", Justification = "Generated code.")]	
		protected sealed override global::System.Type[] GetGeneratedDomainModelTypes()
		{
			return new global::System.Type[]
			{
				typeof(Generator),
				typeof(Task),
				typeof(CompositeTask),
				typeof(LoadCodeElement),
				typeof(BuildProject),
				typeof(CreateFolder),
				typeof(CreateProjectItem),
				typeof(LoadProjectItem),
				typeof(ReadProperty),
				typeof(SetVariable),
				typeof(TextTransformation),
				typeof(Iterator),
				typeof(Importer),
				typeof(Connection),
				typeof(Children),
				typeof(GeneratorLanguageDiagram),
				typeof(ConnectedWithConnector),
				typeof(LoadCodeElementShape),
				typeof(TaskShape),
				typeof(BuildProjectShape),
				typeof(CreateFolderShape),
				typeof(CreateProjectItemShape),
				typeof(LoadProjectItemShape),
				typeof(ReadPropertyShape),
				typeof(SetVariableShape),
				typeof(TextTransformationShape),
				typeof(CompositeShape),
				typeof(ImporterShape),
				typeof(global::Ultramarine.Generators.Language.FixUpDiagram),
				typeof(global::Ultramarine.Generators.Language.ConnectorRolePlayerChanged),
			};
		}
		/// <summary>
		/// Gets the list of generated domain properties.
		/// </summary>
		/// <returns>List of property data.</returns>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1506:AvoidExcessiveClassCoupling", Justification = "Generated code.")]	
		protected sealed override DomainMemberInfo[] GetGeneratedDomainProperties()
		{
			return new DomainMemberInfo[]
			{
				new DomainMemberInfo(typeof(Task), "Name", Task.NameDomainPropertyId, typeof(Task.NamePropertyHandler)),
				new DomainMemberInfo(typeof(Task), "Description", Task.DescriptionDomainPropertyId, typeof(Task.DescriptionPropertyHandler)),
				new DomainMemberInfo(typeof(Task), "BaseType", Task.BaseTypeDomainPropertyId, typeof(Task.BaseTypePropertyHandler)),
				new DomainMemberInfo(typeof(LoadCodeElement), "ElementName", LoadCodeElement.ElementNameDomainPropertyId, typeof(LoadCodeElement.ElementNamePropertyHandler)),
				new DomainMemberInfo(typeof(LoadCodeElement), "ElementType", LoadCodeElement.ElementTypeDomainPropertyId, typeof(LoadCodeElement.ElementTypePropertyHandler)),
				new DomainMemberInfo(typeof(LoadCodeElement), "ElementAccess", LoadCodeElement.ElementAccessDomainPropertyId, typeof(LoadCodeElement.ElementAccessPropertyHandler)),
				new DomainMemberInfo(typeof(LoadCodeElement), "ElementOverride", LoadCodeElement.ElementOverrideDomainPropertyId, typeof(LoadCodeElement.ElementOverridePropertyHandler)),
				new DomainMemberInfo(typeof(LoadCodeElement), "TypeOf", LoadCodeElement.TypeOfDomainPropertyId, typeof(LoadCodeElement.TypeOfPropertyHandler)),
				new DomainMemberInfo(typeof(BuildProject), "ProjectName", BuildProject.ProjectNameDomainPropertyId, typeof(BuildProject.ProjectNamePropertyHandler)),
				new DomainMemberInfo(typeof(BuildProject), "Configuration", BuildProject.ConfigurationDomainPropertyId, typeof(BuildProject.ConfigurationPropertyHandler)),
				new DomainMemberInfo(typeof(CreateFolder), "FolderPath", CreateFolder.FolderPathDomainPropertyId, typeof(CreateFolder.FolderPathPropertyHandler)),
				new DomainMemberInfo(typeof(CreateFolder), "BasePath", CreateFolder.BasePathDomainPropertyId, typeof(CreateFolder.BasePathPropertyHandler)),
				new DomainMemberInfo(typeof(CreateProjectItem), "ItemName", CreateProjectItem.ItemNameDomainPropertyId, typeof(CreateProjectItem.ItemNamePropertyHandler)),
				new DomainMemberInfo(typeof(CreateProjectItem), "FolderPath", CreateProjectItem.FolderPathDomainPropertyId, typeof(CreateProjectItem.FolderPathPropertyHandler)),
				new DomainMemberInfo(typeof(CreateProjectItem), "LinkedWith", CreateProjectItem.LinkedWithDomainPropertyId, typeof(CreateProjectItem.LinkedWithPropertyHandler)),
				new DomainMemberInfo(typeof(CreateProjectItem), "ProjectName", CreateProjectItem.ProjectNameDomainPropertyId, typeof(CreateProjectItem.ProjectNamePropertyHandler)),
				new DomainMemberInfo(typeof(CreateProjectItem), "Overwrite", CreateProjectItem.OverwriteDomainPropertyId, typeof(CreateProjectItem.OverwritePropertyHandler)),
				new DomainMemberInfo(typeof(LoadProjectItem), "ProjectName", LoadProjectItem.ProjectNameDomainPropertyId, typeof(LoadProjectItem.ProjectNamePropertyHandler)),
				new DomainMemberInfo(typeof(LoadProjectItem), "ItemName", LoadProjectItem.ItemNameDomainPropertyId, typeof(LoadProjectItem.ItemNamePropertyHandler)),
				new DomainMemberInfo(typeof(LoadProjectItem), "LinkedWith", LoadProjectItem.LinkedWithDomainPropertyId, typeof(LoadProjectItem.LinkedWithPropertyHandler)),
				new DomainMemberInfo(typeof(ReadProperty), "PropertyName", ReadProperty.PropertyNameDomainPropertyId, typeof(ReadProperty.PropertyNamePropertyHandler)),
				new DomainMemberInfo(typeof(SetVariable), "VariableName", SetVariable.VariableNameDomainPropertyId, typeof(SetVariable.VariableNamePropertyHandler)),
				new DomainMemberInfo(typeof(SetVariable), "VariableValue", SetVariable.VariableValueDomainPropertyId, typeof(SetVariable.VariableValuePropertyHandler)),
				new DomainMemberInfo(typeof(SetVariable), "ParentTask", SetVariable.ParentTaskDomainPropertyId, typeof(SetVariable.ParentTaskPropertyHandler)),
				new DomainMemberInfo(typeof(TextTransformation), "FileName", TextTransformation.FileNameDomainPropertyId, typeof(TextTransformation.FileNamePropertyHandler)),
				new DomainMemberInfo(typeof(TextTransformation), "ProjectName", TextTransformation.ProjectNameDomainPropertyId, typeof(TextTransformation.ProjectNamePropertyHandler)),
				new DomainMemberInfo(typeof(TextTransformation), "Parameters", TextTransformation.ParametersDomainPropertyId, typeof(TextTransformation.ParametersPropertyHandler)),
				new DomainMemberInfo(typeof(Importer), "Path", Importer.PathDomainPropertyId, typeof(Importer.PathPropertyHandler)),
				new DomainMemberInfo(typeof(Importer), "ProjectName", Importer.ProjectNameDomainPropertyId, typeof(Importer.ProjectNamePropertyHandler)),
			};
		}
		/// <summary>
		/// Gets the list of generated domain roles.
		/// </summary>
		/// <returns>List of role data.</returns>
		protected sealed override DomainRolePlayerInfo[] GetGeneratedDomainRoles()
		{
			return new DomainRolePlayerInfo[]
			{
				new DomainRolePlayerInfo(typeof(Connection), "ConnectedTask", Connection.ConnectedTaskDomainRoleId),
				new DomainRolePlayerInfo(typeof(Connection), "TargetTask", Connection.TargetTaskDomainRoleId),
				new DomainRolePlayerInfo(typeof(Children), "CompositeTask", Children.CompositeTaskDomainRoleId),
				new DomainRolePlayerInfo(typeof(Children), "Task", Children.TaskDomainRoleId),
			};
		}
		#endregion
		#region Factory methods
		private static global::System.Collections.Generic.Dictionary<global::System.Type, int> createElementMap;
	
		/// <summary>
		/// Creates an element of specified type.
		/// </summary>
		/// <param name="partition">Partition where element is to be created.</param>
		/// <param name="elementType">Element type which belongs to this domain model.</param>
		/// <param name="propertyAssignments">New element property assignments.</param>
		/// <returns>Created element.</returns>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1506:AvoidExcessiveClassCoupling", Justification = "Generated code.")]	
		public sealed override DslModeling::ModelElement CreateElement(DslModeling::Partition partition, global::System.Type elementType, DslModeling::PropertyAssignment[] propertyAssignments)
		{
			if (elementType == null) throw new global::System.ArgumentNullException("elementType");
	
			if (createElementMap == null)
			{
				createElementMap = new global::System.Collections.Generic.Dictionary<global::System.Type, int>(26);
				createElementMap.Add(typeof(Generator), 0);
				createElementMap.Add(typeof(LoadCodeElement), 1);
				createElementMap.Add(typeof(BuildProject), 2);
				createElementMap.Add(typeof(CreateFolder), 3);
				createElementMap.Add(typeof(CreateProjectItem), 4);
				createElementMap.Add(typeof(LoadProjectItem), 5);
				createElementMap.Add(typeof(ReadProperty), 6);
				createElementMap.Add(typeof(SetVariable), 7);
				createElementMap.Add(typeof(TextTransformation), 8);
				createElementMap.Add(typeof(Iterator), 9);
				createElementMap.Add(typeof(Importer), 10);
				createElementMap.Add(typeof(GeneratorLanguageDiagram), 11);
				createElementMap.Add(typeof(ConnectedWithConnector), 12);
				createElementMap.Add(typeof(LoadCodeElementShape), 13);
				createElementMap.Add(typeof(BuildProjectShape), 14);
				createElementMap.Add(typeof(CreateFolderShape), 15);
				createElementMap.Add(typeof(CreateProjectItemShape), 16);
				createElementMap.Add(typeof(LoadProjectItemShape), 17);
				createElementMap.Add(typeof(ReadPropertyShape), 18);
				createElementMap.Add(typeof(SetVariableShape), 19);
				createElementMap.Add(typeof(TextTransformationShape), 20);
				createElementMap.Add(typeof(CompositeShape), 21);
				createElementMap.Add(typeof(ImporterShape), 22);
			}
			int index;
			if (!createElementMap.TryGetValue(elementType, out index))
			{
				// construct exception error message		
				string exceptionError = string.Format(
								global::System.Globalization.CultureInfo.CurrentCulture,
								global::Ultramarine.Generators.Language.GeneratorLanguageDomainModel.SingletonResourceManager.GetString("UnrecognizedElementType"),
								elementType.Name);
				throw new global::System.ArgumentException(exceptionError, "elementType");
			}
			switch (index)
			{
				case 0: return new Generator(partition, propertyAssignments);
				case 1: return new LoadCodeElement(partition, propertyAssignments);
				case 2: return new BuildProject(partition, propertyAssignments);
				case 3: return new CreateFolder(partition, propertyAssignments);
				case 4: return new CreateProjectItem(partition, propertyAssignments);
				case 5: return new LoadProjectItem(partition, propertyAssignments);
				case 6: return new ReadProperty(partition, propertyAssignments);
				case 7: return new SetVariable(partition, propertyAssignments);
				case 8: return new TextTransformation(partition, propertyAssignments);
				case 9: return new Iterator(partition, propertyAssignments);
				case 10: return new Importer(partition, propertyAssignments);
				case 11: return new GeneratorLanguageDiagram(partition, propertyAssignments);
				case 12: return new ConnectedWithConnector(partition, propertyAssignments);
				case 13: return new LoadCodeElementShape(partition, propertyAssignments);
				case 14: return new BuildProjectShape(partition, propertyAssignments);
				case 15: return new CreateFolderShape(partition, propertyAssignments);
				case 16: return new CreateProjectItemShape(partition, propertyAssignments);
				case 17: return new LoadProjectItemShape(partition, propertyAssignments);
				case 18: return new ReadPropertyShape(partition, propertyAssignments);
				case 19: return new SetVariableShape(partition, propertyAssignments);
				case 20: return new TextTransformationShape(partition, propertyAssignments);
				case 21: return new CompositeShape(partition, propertyAssignments);
				case 22: return new ImporterShape(partition, propertyAssignments);
				default: return null;
			}
		}
	
		private static global::System.Collections.Generic.Dictionary<global::System.Type, int> createElementLinkMap;
	
		/// <summary>
		/// Creates an element link of specified type.
		/// </summary>
		/// <param name="partition">Partition where element is to be created.</param>
		/// <param name="elementLinkType">Element link type which belongs to this domain model.</param>
		/// <param name="roleAssignments">List of relationship role assignments for the new link.</param>
		/// <param name="propertyAssignments">New element property assignments.</param>
		/// <returns>Created element link.</returns>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
		public sealed override DslModeling::ElementLink CreateElementLink(DslModeling::Partition partition, global::System.Type elementLinkType, DslModeling::RoleAssignment[] roleAssignments, DslModeling::PropertyAssignment[] propertyAssignments)
		{
			if (elementLinkType == null) throw new global::System.ArgumentNullException("elementLinkType");
			if (roleAssignments == null) throw new global::System.ArgumentNullException("roleAssignments");
	
			if (createElementLinkMap == null)
			{
				createElementLinkMap = new global::System.Collections.Generic.Dictionary<global::System.Type, int>(2);
				createElementLinkMap.Add(typeof(Connection), 0);
				createElementLinkMap.Add(typeof(Children), 1);
			}
			int index;
			if (!createElementLinkMap.TryGetValue(elementLinkType, out index))
			{
				// construct exception error message
				string exceptionError = string.Format(
								global::System.Globalization.CultureInfo.CurrentCulture,
								global::Ultramarine.Generators.Language.GeneratorLanguageDomainModel.SingletonResourceManager.GetString("UnrecognizedElementLinkType"),
								elementLinkType.Name);
				throw new global::System.ArgumentException(exceptionError, "elementLinkType");
			
			}
			switch (index)
			{
				case 0: return new Connection(partition, roleAssignments, propertyAssignments);
				case 1: return new Children(partition, roleAssignments, propertyAssignments);
				default: return null;
			}
		}
		#endregion
		#region Resource manager
		
		private static global::System.Resources.ResourceManager resourceManager;
		
		/// <summary>
		/// The base name of this model's resources.
		/// </summary>
		public const string ResourceBaseName = "Ultramarine.Generators.Language.GeneratedCode.DomainModelResx";
		
		/// <summary>
		/// Gets the DomainModel's ResourceManager. If the ResourceManager does not already exist, then it is created.
		/// </summary>
		public override global::System.Resources.ResourceManager ResourceManager
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return GeneratorLanguageDomainModel.SingletonResourceManager;
			}
		}
	
		/// <summary>
		/// Gets the Singleton ResourceManager for this domain model.
		/// </summary>
		public static global::System.Resources.ResourceManager SingletonResourceManager
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				if (GeneratorLanguageDomainModel.resourceManager == null)
				{
					GeneratorLanguageDomainModel.resourceManager = new global::System.Resources.ResourceManager(ResourceBaseName, typeof(GeneratorLanguageDomainModel).Assembly);
				}
				return GeneratorLanguageDomainModel.resourceManager;
			}
		}
		#endregion
		#region Copy/Remove closures
		/// <summary>
		/// CopyClosure cache
		/// </summary>
		private static DslModeling::IElementVisitorFilter copyClosure;
		/// <summary>
		/// DeleteClosure cache
		/// </summary>
		private static DslModeling::IElementVisitorFilter removeClosure;
		/// <summary>
		/// Returns an IElementVisitorFilter that corresponds to the ClosureType.
		/// </summary>
		/// <param name="type">closure type</param>
		/// <param name="rootElements">collection of root elements</param>
		/// <returns>IElementVisitorFilter or null</returns>
		public override DslModeling::IElementVisitorFilter GetClosureFilter(DslModeling::ClosureType type, global::System.Collections.Generic.ICollection<DslModeling::ModelElement> rootElements)
		{
			switch (type)
			{
				case DslModeling::ClosureType.CopyClosure:
					return GeneratorLanguageDomainModel.CopyClosure;
				case DslModeling::ClosureType.DeleteClosure:
					return GeneratorLanguageDomainModel.DeleteClosure;
			}
			return base.GetClosureFilter(type, rootElements);
		}
		/// <summary>
		/// CopyClosure cache
		/// </summary>
		private static DslModeling::IElementVisitorFilter CopyClosure
		{
			get
			{
				// Incorporate all of the closures from the models we extend
				if (GeneratorLanguageDomainModel.copyClosure == null)
				{
					DslModeling::ChainingElementVisitorFilter copyFilter = new DslModeling::ChainingElementVisitorFilter();
					copyFilter.AddFilter(new GeneratorLanguageCopyClosure());
					copyFilter.AddFilter(new DslModeling::CoreCopyClosure());
					copyFilter.AddFilter(new DslDiagrams::CoreDesignSurfaceCopyClosure());
					
					GeneratorLanguageDomainModel.copyClosure = copyFilter;
				}
				return GeneratorLanguageDomainModel.copyClosure;
			}
		}
		/// <summary>
		/// DeleteClosure cache
		/// </summary>
		private static DslModeling::IElementVisitorFilter DeleteClosure
		{
			get
			{
				// Incorporate all of the closures from the models we extend
				if (GeneratorLanguageDomainModel.removeClosure == null)
				{
					DslModeling::ChainingElementVisitorFilter removeFilter = new DslModeling::ChainingElementVisitorFilter();
					removeFilter.AddFilter(new GeneratorLanguageDeleteClosure());
					removeFilter.AddFilter(new DslModeling::CoreDeleteClosure());
					removeFilter.AddFilter(new DslDiagrams::CoreDesignSurfaceDeleteClosure());
		
					GeneratorLanguageDomainModel.removeClosure = removeFilter;
				}
				return GeneratorLanguageDomainModel.removeClosure;
			}
		}
		#endregion
		#region Diagram rule helpers
		/// <summary>
		/// Enables rules in this domain model related to diagram fixup for the given store.
		/// If diagram data will be loaded into the store, this method should be called first to ensure
		/// that the diagram behaves properly.
		/// </summary>
		public static void EnableDiagramRules(DslModeling::Store store)
		{
			if(store == null) throw new global::System.ArgumentNullException("store");
			
			DslModeling::RuleManager ruleManager = store.RuleManager;
			ruleManager.EnableRule(typeof(global::Ultramarine.Generators.Language.FixUpDiagram));
			ruleManager.EnableRule(typeof(global::Ultramarine.Generators.Language.ConnectorRolePlayerChanged));
		}
		
		/// <summary>
		/// Disables rules in this domain model related to diagram fixup for the given store.
		/// </summary>
		public static void DisableDiagramRules(DslModeling::Store store)
		{
			if(store == null) throw new global::System.ArgumentNullException("store");
			
			DslModeling::RuleManager ruleManager = store.RuleManager;
			ruleManager.DisableRule(typeof(global::Ultramarine.Generators.Language.FixUpDiagram));
			ruleManager.DisableRule(typeof(global::Ultramarine.Generators.Language.ConnectorRolePlayerChanged));
		}
		#endregion
	}
		
	#region Copy/Remove closure classes
	/// <summary>
	/// Remove closure visitor filter
	/// </summary>
	[global::System.CLSCompliant(true)]
	public partial class GeneratorLanguageDeleteClosure : GeneratorLanguageDeleteClosureBase, DslModeling::IElementVisitorFilter
	{
		/// <summary>
		/// Constructor
		/// </summary>
		public GeneratorLanguageDeleteClosure() : base()
		{
		}
	}
	
	/// <summary>
	/// Base class for remove closure visitor filter
	/// </summary>
	[global::System.CLSCompliant(true)]
	public partial class GeneratorLanguageDeleteClosureBase : DslModeling::IElementVisitorFilter
	{
		/// <summary>
		/// DomainRoles
		/// </summary>
		private global::System.Collections.Specialized.HybridDictionary domainRoles;
		/// <summary>
		/// Constructor
		/// </summary>
		public GeneratorLanguageDeleteClosureBase()
		{
			#region Initialize DomainData Table
			DomainRoles.Add(global::Ultramarine.Generators.Language.Children.TaskDomainRoleId, true);
			#endregion
		}
		/// <summary>
		/// Called to ask the filter if a particular relationship from a source element should be included in the traversal
		/// </summary>
		/// <param name="walker">ElementWalker that is traversing the model</param>
		/// <param name="sourceElement">Model Element playing the source role</param>
		/// <param name="sourceRoleInfo">DomainRoleInfo of the role that the source element is playing in the relationship</param>
		/// <param name="domainRelationshipInfo">DomainRelationshipInfo for the ElementLink in question</param>
		/// <param name="targetRelationship">Relationship in question</param>
		/// <returns>Yes if the relationship should be traversed</returns>
		public virtual DslModeling::VisitorFilterResult ShouldVisitRelationship(DslModeling::ElementWalker walker, DslModeling::ModelElement sourceElement, DslModeling::DomainRoleInfo sourceRoleInfo, DslModeling::DomainRelationshipInfo domainRelationshipInfo, DslModeling::ElementLink targetRelationship)
		{
			return DslModeling::VisitorFilterResult.Yes;
		}
		/// <summary>
		/// Called to ask the filter if a particular role player should be Visited during traversal
		/// </summary>
		/// <param name="walker">ElementWalker that is traversing the model</param>
		/// <param name="sourceElement">Model Element playing the source role</param>
		/// <param name="elementLink">Element Link that forms the relationship to the role player in question</param>
		/// <param name="targetDomainRole">DomainRoleInfo of the target role</param>
		/// <param name="targetRolePlayer">Model Element that plays the target role in the relationship</param>
		/// <returns></returns>
		public virtual DslModeling::VisitorFilterResult ShouldVisitRolePlayer(DslModeling::ElementWalker walker, DslModeling::ModelElement sourceElement, DslModeling::ElementLink elementLink, DslModeling::DomainRoleInfo targetDomainRole, DslModeling::ModelElement targetRolePlayer)
		{
			if (targetDomainRole == null) throw new global::System.ArgumentNullException("targetDomainRole");
			return this.DomainRoles.Contains(targetDomainRole.Id) ? DslModeling::VisitorFilterResult.Yes : DslModeling::VisitorFilterResult.DoNotCare;
		}
		/// <summary>
		/// DomainRoles
		/// </summary>
		private global::System.Collections.Specialized.HybridDictionary DomainRoles
		{
			get
			{
				if (this.domainRoles == null)
				{
					this.domainRoles = new global::System.Collections.Specialized.HybridDictionary();
				}
				return this.domainRoles;
			}
		}
	
	}
	/// <summary>
	/// Copy closure visitor filter
	/// </summary>
	[global::System.CLSCompliant(true)]
	public partial class GeneratorLanguageCopyClosure : GeneratorLanguageCopyClosureBase, DslModeling::IElementVisitorFilter
	{
		/// <summary>
		/// Constructor
		/// </summary>
		public GeneratorLanguageCopyClosure() : base()
		{
		}
	}
	/// <summary>
	/// Base class for copy closure visitor filter
	/// </summary>
	[global::System.CLSCompliant(true)]
	public partial class GeneratorLanguageCopyClosureBase : DslModeling::CopyClosureFilter, DslModeling::IElementVisitorFilter
	{
		/// <summary>
		/// Constructor
		/// </summary>
		public GeneratorLanguageCopyClosureBase():base()
		{
		}
	}
	#endregion
		
}

