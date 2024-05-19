namespace Structurizr.Core.New

open System.Runtime.Serialization
open FSharp.Collections
open Structurizr

[<DataContract>]
type Model =
    { ImpliedRelationshipsStrategy: IImpliedRelationshipsStrategy
      IdGenerator: IdGenerator
      [<DataMember(Name = "enterprise", EmitDefaultValue = false)>]
      Enterprise: Enterprise
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
          Enterprise = null
          People = Set.empty
          SoftwareSystems = Set.empty
          DeploymentNodes = Set.empty
          Relationships = [] }

    member _.addRelationship (source: Element) (destination: Element) (description: string) (technology: string) (interactionStyle: Option<InteractionStyle>) (tags: string[]) (createImpliedRelationships: bool) : Option<Relationship> =
      match Option.ofNullable(destination) with
      | None -> failwith "The destination must be specified."
      | Some dest ->
          if isChildOf source dest || isChildOf dest source then
              failwith "Relationships cannot be added between parents and children."
          else
              let relationship = { Source = source; Destination = dest; Description = description; Technology = technology; InteractionStyle = interactionStyle; Tags = tags }
              if addRelationship relationship then
                  if createImpliedRelationships && 
                    ((source :? Person || source :? SoftwareSystem || source :? Container || source :? Component) &&
                      (dest :? Person || dest :? SoftwareSystem || dest :? Container || dest :? Component)) then
                      ImpliedRelationshipsStrategy.createImpliedRelationships relationship
                  Some relationship
              else None

    member private _.IsChildOf first second =
        if first :? Person || second :? Person then false
        else
          let parent = second.Parent

          
