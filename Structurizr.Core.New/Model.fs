namespace Structurizr.Core.New

open System
open System.Runtime.Serialization
open FSharp.Collections
open Structurizr

type Location =
    | Unspecified
    | Internal
    | External

[<DataContract>]
type ModelItem =
    [<DataMember(Name = "id", EmitDefaultValue = false)>]
    abstract Id: string

    [<DataMember(Name = "tags", EmitDefaultValue = false)>]
    abstract Tags: string list

[<DataContract>]
type Element =
    inherit ModelItem

    [<DataMember(Name = "name", EmitDefaultValue = false)>]
    abstract Name: string

    [<DataMember(Name = "description", EmitDefaultValue = false)>]
    abstract Description: string

    [<DataMember(Name = "url", EmitDefaultValue = false)>]
    abstract Url: string

    [<DataMember(Name = "relationships", EmitDefaultValue = false)>]
    abstract Relationships: Relationship list

    abstract CanonicalName: string

[<DataContract>]
type GroupableElement =
    inherit Element

    [<DataMember(Name = "group", EmitDefaultValue = false)>]
    abstract Group: string with get

type StaticStructureElement =
    inherit GroupableElement

[<DataContract>]
type Enterprise =
    { [<DataMember(Name = "name", EmitDefaultValue = false)>]
      Name: string }

    static member New name =
        if String.IsNullOrWhiteSpace name then
            failwith "Name is required."

        { Name = name }

[<DataContract>]
type Perspective =
    { [<DataMember(Name = "name", EmitDefaultValue = false)>]
      Name: string
      [<DataMember(Name = "description", EmitDefaultValue = false)>]
      Description: string }

[<DataContract>]
type Relationship =
    { [<DataMember(Name = "description", EmitDefaultValue = false)>]
      Description: string
      [<DataMember(Name = "sourceId", EmitDefaultValue = false)>]
      SourceId: string
      [<DataMember(Name = "destinationId", EmitDefaultValue = false)>]
      DestinationId: string
      Source: Element
      Destination: Element
      [<DataMember(Name = "technology", EmitDefaultValue = false)>]
      Technology: string
      [<DataMember(Name = "linkedRelationshipId", EmitDefaultValue = false)>]
      LinkedRelationshipId: string
      [<DataMember(Name = "interactionStyle", EmitDefaultValue = false)>]
      InteractionStyle: InteractionStyle option
      [<DataMember(Name = "url", EmitDefaultValue = false)>]
      Url: string }

[<DataContract>]
type Person =
    { [<DataMember(Name = "location", EmitDefaultValue = true)>]
      Location: Location }

    static member New location = { Location = location }

[<DataContract>]
type CodeElement =
    { [<DataMember(Name = "role", EmitDefaultValue = true)>]
      Role: CodeElementRole
      [<DataMember(Name = "name", EmitDefaultValue = false)>]
      Name: string
      [<DataMember(Name = "type", EmitDefaultValue = false)>]
      Type: string
      [<DataMember(Name = "description", EmitDefaultValue = false)>]
      Description: string
      [<DataMember(Name = "url", EmitDefaultValue = false)>]
      Url: string
      [<DataMember(Name = "language", EmitDefaultValue = false)>]
      Language: string
      [<DataMember(Name = "category", EmitDefaultValue = false)>]
      Category: string
      [<DataMember(Name = "visibility", EmitDefaultValue = false)>]
      Visibility: string
      [<DataMember(Name = "size", EmitDefaultValue = true)>]
      Size: int }

[<DataContract>]
type Component =
    { [<DataMember(Name = "technology", EmitDefaultValue = false)>]
      Technology: string
      [<DataMember(Name = "size", EmitDefaultValue = true)>]
      Size: int
      [<DataMember(Name = "code", EmitDefaultValue = false)>]
      CodeElements: Set<CodeElement>
      
      Group: string }

    interface StaticStructureElement with
        member this.Group with get() = this.Group
        member this.CanonicalName =
            

[<DataContract>]
type Container =
    { [<DataMember(Name = "technology", EmitDefaultValue = false)>]
      Technology: string
      [<DataMember(Name = "components", EmitDefaultValue = false)>]
      Components: Set<Component> }

[<DataContract>]
type SoftwareSystem =
    { [<DataMember(Name = "location", EmitDefaultValue = true)>]
      Location: Location
      [<DataMember(Name = "containers", EmitDefaultValue = false)>]
      Containers: Set<Container> }

[<DataContract>]
type ContainerInstance = { Container: Container }

[<DataContract>]
type SoftwareSystemInstance = { SoftwareSystem: SoftwareSystem }

[<DataContract>]
type DeploymentNode =
    { [<DataMember(Name = "technology", EmitDefaultValue = false)>]
      Technology: string
      [<DataMember(Name = "children", EmitDefaultValue = false)>]
      Children: Set<DeploymentNode>
      [<DataMember(Name = "infrastructureNodes", EmitDefaultValue = false)>]
      InfrastructureNodes: Set<DeploymentNode>
      [<DataMember(Name = "softwareSystemInstances", EmitDefaultValue = false)>]
      SoftwareSystemInstances: Set<SoftwareSystemInstance>
      [<DataMember(Name = "containerInstances", EmitDefaultValue = false)>]
      ContainerInstances: Set<ContainerInstance> }

[<DataContract>]
type Model =
    { ImpliedRelationshipsStrategy: IImpliedRelationshipsStrategy
      IdGenerator: IdGenerator
      [<DataMember(Name = "enterprise", EmitDefaultValue = false)>]
      Enterprise: Enterprise option
      [<DataMember(Name = "people", EmitDefaultValue = false)>]
      People: Set<Person>
      [<DataMember(Name = "softwareSystems", EmitDefaultValue = false)>]
      SoftwareSystems: Set<SoftwareSystem>
      [<DataMember(Name = "deploymentNodes", EmitDefaultValue = false)>]
      DeploymentNodes: Set<DeploymentNode>
      Relationships: Relationship list }

    static member Empty =
        { ImpliedRelationshipsStrategy = DefaultImpliedRelationshipsStrategy()
          IdGenerator = SequentialIntegerIdGeneratorStrategy()
          Enterprise = None
          People = Set.empty
          SoftwareSystems = Set.empty
          DeploymentNodes = Set.empty
          Relationships = [] }
