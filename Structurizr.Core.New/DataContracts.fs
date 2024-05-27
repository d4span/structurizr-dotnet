namespace Structurizr

open System
open System.Runtime.Serialization

module DataContracts =

    [<Interface>]
    [<DataContract>]
    type ModelItem =
        [<DataMember(Name = "id", EmitDefaultValue = false)>]
        abstract Id: string with get

        [<DataMember(Name = "tags", EmitDefaultValue = false)>]
        abstract Tags: string list with get

    [<Interface>]
    [<DataContract>]
    type Element =
        inherit ModelItem

        [<DataMember(Name = "name", EmitDefaultValue = false)>]
        abstract Name: string with get

        [<DataMember(Name = "description", EmitDefaultValue = false)>]
        abstract Description: string with get

        [<DataMember(Name = "url", EmitDefaultValue = false)>]
        abstract Url: string with get

        [<DataMember(Name = "relationships", EmitDefaultValue = false)>]
        abstract Relationships: Relationship list with get

        abstract CanonicalName: string with get

    [<Interface>]
    [<DataContract>]
    type GroupableElement =
        inherit Element

        [<DataMember(Name = "group", EmitDefaultValue = false)>]
        abstract Group: string with get

    [<Interface>]
    type StaticStructureElement =
        inherit GroupableElement

    [<Interface>]
    [<DataContract>]
    type Relationship =
          [<DataMember(Name = "description", EmitDefaultValue = false)>]
          abstract Description: string with get
          [<DataMember(Name = "sourceId", EmitDefaultValue = false)>]
          abstract SourceId: string with get
          [<DataMember(Name = "destinationId", EmitDefaultValue = false)>]
          abstract DestinationId: string with get
          [<DataMember(Name = "technology", EmitDefaultValue = false)>]
          abstract Technology: string with get
          [<DataMember(Name = "linkedRelationshipId", EmitDefaultValue = false)>]
          abstract LinkedRelationshipId: string with get
          [<DataMember(Name = "interactionStyle", EmitDefaultValue = false)>]
          abstract InteractionStyle: InteractionStyle option with get
          [<DataMember(Name = "url", EmitDefaultValue = false)>]
          abstract Url: string with get

    [<Interface>]
    [<DataContract>]
    type Person =
        [<DataMember(Name = "location", EmitDefaultValue = true)>]
        abstract Location: Location with get

    [<Interface>]
    [<DataContract>]
    type CodeElement =
          [<DataMember(Name = "role", EmitDefaultValue = true)>]
          abstract Role: CodeElementRole with get
          [<DataMember(Name = "name", EmitDefaultValue = false)>]
          abstract Name: string with get
          [<DataMember(Name = "type", EmitDefaultValue = false)>]
          abstract Type: string with get
          [<DataMember(Name = "description", EmitDefaultValue = false)>]
          abstract Description: string with get
          [<DataMember(Name = "url", EmitDefaultValue = false)>]
          abstract Url: string with get
          [<DataMember(Name = "language", EmitDefaultValue = false)>]
          abstract Language: string with get
          [<DataMember(Name = "category", EmitDefaultValue = false)>]
          abstract Category: string with get
          [<DataMember(Name = "visibility", EmitDefaultValue = false)>]
          abstract Visibility: string with get
          [<DataMember(Name = "size", EmitDefaultValue = true)>]
          abstract Size: int with get

    // [<DataContract>]
    // type Component =
    //     { [<DataMember(Name = "technology", EmitDefaultValue = false)>]
    //       Technology: string
    //       [<DataMember(Name = "size", EmitDefaultValue = true)>]
    //       Size: int
    //       [<DataMember(Name = "code", EmitDefaultValue = false)>]
    //       CodeElements: Set<CodeElement>

    //       Group: string }

    //     interface StaticStructureElement with
    //         member this.Group with get() = this.Group
    //         member this.CanonicalName =


    // [<DataContract>]
    // type Container =
    //     { [<DataMember(Name = "technology", EmitDefaultValue = false)>]
    //       Technology: string
    //       [<DataMember(Name = "components", EmitDefaultValue = false)>]
    //       Components: Set<Component> }

    // [<DataContract>]
    // type SoftwareSystem =
    //     { [<DataMember(Name = "location", EmitDefaultValue = true)>]
    //       Location: Location
    //       [<DataMember(Name = "containers", EmitDefaultValue = false)>]
    //       Containers: Set<Container> }

    // [<DataContract>]
    // type ContainerInstance = { Container: Container }

    // [<DataContract>]
    // type SoftwareSystemInstance = { SoftwareSystem: SoftwareSystem }

    // [<DataContract>]
    // type DeploymentNode =
    //     { [<DataMember(Name = "technology", EmitDefaultValue = false)>]
    //       Technology: string
    //       [<DataMember(Name = "children", EmitDefaultValue = false)>]
    //       Children: Set<DeploymentNode>
    //       [<DataMember(Name = "infrastructureNodes", EmitDefaultValue = false)>]
    //       InfrastructureNodes: Set<DeploymentNode>
    //       [<DataMember(Name = "softwareSystemInstances", EmitDefaultValue = false)>]
    //       SoftwareSystemInstances: Set<SoftwareSystemInstance>
    //       [<DataMember(Name = "containerInstances", EmitDefaultValue = false)>]
    //       ContainerInstances: Set<ContainerInstance> }

    // [<DataContract>]
    // type Model =
    //     { ImpliedRelationshipsStrategy: IImpliedRelationshipsStrategy
    //       IdGenerator: IdGenerator
    //       [<DataMember(Name = "enterprise", EmitDefaultValue = false)>]
    //       Enterprise: Enterprise option
    //       [<DataMember(Name = "people", EmitDefaultValue = false)>]
    //       People: Set<Person>
    //       [<DataMember(Name = "softwareSystems", EmitDefaultValue = false)>]
    //       SoftwareSystems: Set<SoftwareSystem>
    //       [<DataMember(Name = "deploymentNodes", EmitDefaultValue = false)>]
    //       DeploymentNodes: Set<DeploymentNode>
    //       Relationships: Relationship list }

    //     static member Empty =
    //         { ImpliedRelationshipsStrategy = DefaultImpliedRelationshipsStrategy()
    //           IdGenerator = SequentialIntegerIdGeneratorStrategy()
    //           Enterprise = None
    //           People = Set.empty
    //           SoftwareSystems = Set.empty
    //           DeploymentNodes = Set.empty
    //           Relationships = [] }

    [<DataContract>]
    type Perspective =
        { [<DataMember(Name = "name", EmitDefaultValue = false)>]
          Name: string
          [<DataMember(Name = "description", EmitDefaultValue = false)>]
          Description: string }

    [<DataContract>]
    type Enterprise =
        { [<DataMember(Name = "name", EmitDefaultValue = false)>]
          Name: string }

        static member New name =
            if String.IsNullOrWhiteSpace name then
                failwith "Name is required."

            { Name = name }